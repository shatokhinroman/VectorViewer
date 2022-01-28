namespace VectorViewer.UI.Primitives.Factory
{
    using Base;
    using Model.Primitives.Base;

    public interface IPrimitiveViewModelFactory
    {
        IPrimitiveViewModel CreatePrimitiveViewModel(Primitive primitive);
    }
}