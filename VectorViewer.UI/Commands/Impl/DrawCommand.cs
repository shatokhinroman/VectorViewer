namespace VectorViewer.UI.Commands.Impl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Base;
    using Primitives.Base;
    using Primitives.Factory;
    using Services.Primitives;
    using VectorViewer.Utils;

    public class DrawCommand : CommandBase, IDrawCommand
    {
        private readonly IPrimitiveService _primitiveService;

        private readonly IPrimitiveViewModelFactory _primitiveViewModelFactory;

        public DrawCommand(
            IPrimitiveService primitiveService,
            IPrimitiveViewModelFactory primitiveViewModelFactory)
        {
            _primitiveService = primitiveService;
            _primitiveViewModelFactory = primitiveViewModelFactory;
        }

        public Action<IEnumerable<IPrimitiveViewModel>> SetPrimitives { get; private set; }

        public Func<bool> CanDraw { get; private set; }

        /// <inheritdoc />
        /// TODO show error messages
        public override void Execute(object parameter)
        {
            var filePath = parameter as string;
            if (filePath.IsNullOrWhiteSpace())
                return;

            var primitives = _primitiveService.GetPrimitives(filePath);
            if (primitives.IsEmptyCollection())
                return;

            var failedPrimitives = primitives.Where(p => !p.Key.Success);
            if (failedPrimitives.Any())
                return;

            var viewModels = primitives
                .Select(p => _primitiveViewModelFactory.CreatePrimitiveViewModel(p.Value))
                .ToList();

            SetPrimitives(viewModels);
        }

        /// <inheritdoc />
        public override bool CanExecute(object parameter) => CanDraw();

        public IDrawCommand Initialize(Action<IEnumerable<IPrimitiveViewModel>> setPrimitives, Func<bool> canDraw)
        {
            SetPrimitives = setPrimitives;
            CanDraw = canDraw;

            return this;
        }
    }
}