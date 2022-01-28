namespace VectorViewer.Services
{
    using Conversion;
    using Conversion.Converters.Base;
    using Conversion.Converters.Impl;

    using DataSources.Factory;
    using DataSources.Parsers;
    using LightInject;
    using Primitives;

    public class Module : ICompositionRoot
    {
        /// <inheritdoc />
        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<IPrimitiveConverter, LineConverter>(nameof(LineConverter));
            serviceRegistry.Register<IPrimitiveConverter, CircleConverter>(nameof(CircleConverter));
            serviceRegistry.Register<IPrimitiveConverter, TriangleConverter>(nameof(TriangleConverter));
        
            serviceRegistry.Register<IPrimitiveConverterFactory, PrimitiveConverterFactory>();
        
            serviceRegistry.Register<IPrimitiveDataSourceParser, JsonDataSourceParser>();
            serviceRegistry.Register<IDataSourceParserFactory, DataSourceParserFactory>();
        
            serviceRegistry.Register<IPrimitiveService, PrimitiveService>();
        }
    }
}