namespace VectorViewer.Tests
{
    using System.Linq;
    using NUnit.Framework;
    using Services.Conversion;
    using Services.Conversion.Converters.Base;
    using Services.Conversion.Converters.Impl;
    using Services.DataSources.Factory;
    using Services.DataSources.Parsers;
    using Services.Primitives;

    public class Tests
    {
        private IPrimitiveService _primitiveService;
        
        [SetUp]
        public void Setup()
        {
            _primitiveService = new PrimitiveService(
                new DataSourceParserFactory(() => new IPrimitiveDataSourceParser[]
                {
                    new JsonDataSourceParser()
                }),
                new PrimitiveConverterFactory(() => new IPrimitiveConverter[]
                {
                    new LineConverter(),
                    new CircleConverter(),
                    new TriangleConverter()
                }));
        }

        [Test]
        public void Test1()
        {
            const string defaultFilePath = @"C:\Users\r\Desktop\default.json";

            var primitives = _primitiveService.GetPrimitives(defaultFilePath);

            Assert.NotNull(primitives);
            Assert.True(primitives.Keys.All(k => k.Success));
            Assert.NotNull(primitives.Values);
        }
    }
}