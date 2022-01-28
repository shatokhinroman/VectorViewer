namespace VectorViewer.UI.Commands.Base
{
    using System;

    public interface IClearCommand : IVectorViewerCommand
    {
        IClearCommand Initialize(Action clear, Func<bool> canClear);
    }
}