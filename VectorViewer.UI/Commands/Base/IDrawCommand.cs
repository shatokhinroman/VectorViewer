namespace VectorViewer.UI.Commands.Base
{
    using System;
    using System.Collections.Generic;
    using Primitives.Base;

    public interface IDrawCommand : IVectorViewerCommand
    {
        IDrawCommand Initialize(Action<IEnumerable<IPrimitiveViewModel>> setPrimitives, Func<bool> canDraw);
    }
}