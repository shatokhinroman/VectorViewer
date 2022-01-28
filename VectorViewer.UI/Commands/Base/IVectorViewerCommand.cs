namespace VectorViewer.UI.Commands.Base
{
    using System.ComponentModel;
    using System.Windows.Input;

    public interface IVectorViewerCommand : ICommand
    {
        void RaiseCanExecuteChanged(object sender, PropertyChangedEventArgs eventArgs);
    }
}