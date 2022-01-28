namespace VectorViewer.UI.Primitives.Factory
{
    using System;
    using System.Linq;
    using Base;
    using Model.Primitives.Base;

    public class PrimitiveViewModelFactory : IPrimitiveViewModelFactory
    {
        private readonly Func<IPrimitiveViewModel[]> _getPrimitiveViewModels;

        public PrimitiveViewModelFactory(
            Func<IPrimitiveViewModel[]> primitiveViewModels)
        {
            _getPrimitiveViewModels = primitiveViewModels;
        }

        public IPrimitiveViewModel CreatePrimitiveViewModel(Primitive primitive)
        {
            return _getPrimitiveViewModels().SingleOrDefault(p => p.Type == primitive.Type)?.Initialize(primitive);
        }
    }
}