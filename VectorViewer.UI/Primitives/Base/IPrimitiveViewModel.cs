namespace VectorViewer.UI.Primitives.Base
{
    using Model.Positions;
    using Model.Primitives;
    using Model.Primitives.Base;

    public interface IPrimitiveViewModel
    {
        PrimitiveTypes Type { get; }

        IPrimitiveViewModel Initialize(Primitive primitive);

        Position GetPosition();
    }
}