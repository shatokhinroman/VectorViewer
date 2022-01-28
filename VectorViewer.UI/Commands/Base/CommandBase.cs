namespace VectorViewer.UI.Commands.Base
{
    using System;
    using System.ComponentModel;

    public abstract class CommandBase
    {
        /// <inheritdoc />
        public event EventHandler CanExecuteChanged;

        /// <inheritdoc />
        public abstract bool CanExecute(object parameter);

        /// <inheritdoc />
        public abstract void Execute(object parameter);

        /// <inheritdoc />
        public void RaiseCanExecuteChanged(object sender, PropertyChangedEventArgs eventArgs) => CanExecuteChanged?.Invoke(sender, eventArgs);
    }
}