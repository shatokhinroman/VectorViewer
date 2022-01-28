namespace VectorViewer.UI.PrimitivesViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Windows;

    using Commands.Base;
    using Model.Positions;
    using Primitives.Base;
    using Utils;
    using VectorViewer.Utils;

    public class PrimitivesViewModel : IPrimitivesViewModel, INotifyPropertyChanged
    {
        private const double DefaultScale = 1;

        private Window _window;

        private List<IVectorViewerCommand> _commands;

        public PrimitivesViewModel(
            ISelectFileCommand selectFileCommand,
            IDrawCommand drawCommand,
            IClearCommand clearCommand)
        {
            SelectFileCommand = selectFileCommand;
            DrawCommand = drawCommand;
            ClearCommand = clearCommand;
        }

        /// <inheritdoc />
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<IPrimitiveViewModel> Primitives { get; private set; }

        public string FilePath { get; set; }

        public double ScaleX => Scale;

        public double ScaleY => Scale;

        public double Scale { get; private set; }

        public string ScaleText => Math.Round(Scale, digits: 3).ToString(CultureInfo.InvariantCulture);

        public ISelectFileCommand SelectFileCommand { get; }

        public IDrawCommand DrawCommand { get; }

        public IClearCommand ClearCommand { get; }

        #region Methods

        public IPrimitivesViewModel Initialize(Window window)
        {
            Scale = DefaultScale;

            _window = window;
            _commands = new List<IVectorViewerCommand>
            {
                SelectFileCommand.Initialize(SetFilePath),
                DrawCommand.Initialize(SetPrimitives, CanDraw),
                ClearCommand.Initialize(Clear, CanClear)
            };

            PropertyChanged += OnPropertyChanged;
            return this;
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            _commands?.ForEach(c => c.RaiseCanExecuteChanged(sender, e));
        }

        private void SetScale()
        {
            Scale = GetScale();

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ScaleX)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ScaleY)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ScaleText)));
        }

        private double GetScale()
        {
            if (Primitives.IsEmptyCollection())
                return DefaultScale;

            var windowPosition = _window.GetAbsolutePosition().ToCartesian();

            var validPrimitives = Primitives
                .Where(p => p.GetPosition().IsInsideOf(windowPosition))
                .ToList();

            if (validPrimitives.Count == Primitives.Count)
                return DefaultScale;

            var notValidPrimitives = Primitives.Except(validPrimitives);
            var scale = notValidPrimitives
                .Select(p => p.GetPosition().GetScaleFor(windowPosition, DefaultScale))
                .OrderBy(p => p)
                .First();

            return scale == 0 ? DefaultScale : scale;
        }

        #endregion

        #region Commands

        private void SetFilePath(string value)
        {
            FilePath = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FilePath)));
        }

        private bool CanDraw() => !FilePath.IsNullOrWhiteSpace() && File.Exists(FilePath);

        private void SetPrimitives(IEnumerable<IPrimitiveViewModel> primitives)
        {
            Primitives = primitives.ToObservableCollection();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Primitives)));

            SetScale();
        }

        private bool CanClear() => !FilePath.IsNullOrWhiteSpace() || !Primitives.IsEmptyCollection();

        private void Clear()
        {
            SetFilePath(string.Empty);
            SetPrimitives(Enumerable.Empty<IPrimitiveViewModel>());
        }

        #endregion
    }
}