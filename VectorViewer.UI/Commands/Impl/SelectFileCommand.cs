namespace VectorViewer.UI.Commands.Impl
{
    using System;
    using Base;
    using Microsoft.Win32;

    public class SelectFileCommand : CommandBase, ISelectFileCommand
    {
        public Action<string> SetFilePath { get; private set; }

        /// <inheritdoc />
        public override void Execute(object parameter)
        {
            var dialog = new OpenFileDialog
            {
                DefaultExt = ".json",
                //// TODO get available extensions from parsers
                Filter = "JSON Files (*.json)|*.json|All files (*.*)|*.*"
            };

            if (dialog.ShowDialog() == true)
                SetFilePath(dialog.FileName);
        }

        /// <inheritdoc />
        public override bool CanExecute(object parameter) => true;

        public ISelectFileCommand Initialize(Action<string> setFilePath)
        {
            SetFilePath = setFilePath;
            return this;
        }
    }
}