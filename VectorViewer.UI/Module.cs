namespace VectorViewer.UI
{
    using Commands.Base;
    using Commands.Impl;
    using Interfaces;
    using LightInject;
    using Primitives.Base;
    using Primitives.Factory;
    using Primitives.Impl;
    using PrimitivesViewModel;

    public class Module : ICompositionRoot
    {
        /// <inheritdoc />
        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<IPrimitiveViewModel, LineViewModel>(nameof(LineViewModel));
            serviceRegistry.Register<IPrimitiveViewModel, CircleViewModel>(nameof(CircleViewModel));
            serviceRegistry.Register<IPrimitiveViewModel, TriangleViewModel>(nameof(TriangleViewModel));

            serviceRegistry.Register<IPrimitiveViewModelFactory, PrimitiveViewModelFactory>();

            serviceRegistry.Register<ISelectFileCommand, SelectFileCommand>();
            serviceRegistry.Register<IDrawCommand, DrawCommand>();
            serviceRegistry.Register<IClearCommand, ClearCommand>();

            serviceRegistry.Register<IPrimitivesViewModel, PrimitivesViewModel.PrimitivesViewModel>();
            serviceRegistry.Register<IMainWindow, MainWindow>();
        }
    }
}