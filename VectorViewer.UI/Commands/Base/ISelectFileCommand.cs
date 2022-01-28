namespace VectorViewer.UI.Commands.Base
{
    using System;

    public interface ISelectFileCommand : IVectorViewerCommand
    {
        ISelectFileCommand Initialize(Action<string> setFilePath);
    }
}