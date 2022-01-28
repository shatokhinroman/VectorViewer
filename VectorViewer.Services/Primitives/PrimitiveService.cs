namespace VectorViewer.Services.Primitives
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Conversion;
    using DataSources.Factory;
    using Model.OperationResult;
    using Model.Primitives.Base;
    using Model.Serialization;
    using Utils;

    public class PrimitiveService : IPrimitiveService
    {
        private readonly IDataSourceParserFactory _dataSourceParserFactory;

        private readonly IPrimitiveConverterFactory _primitiveConverterFactory;

        public PrimitiveService(
            IDataSourceParserFactory dataSourceParserFactory,
            IPrimitiveConverterFactory primitiveConverterFactory)
        {
            _dataSourceParserFactory = dataSourceParserFactory;
            _primitiveConverterFactory = primitiveConverterFactory;
        }

        public Dictionary<OperationResult, Primitive> GetPrimitives(string filePath)
        {
            var dataSourceParser = _dataSourceParserFactory.GetDataSourceParser(filePath);
            if (dataSourceParser == null)
                throw new Exception(string.Format(Resources.No_Data_Source_Parser_Registered, filePath));

            var primitiveDtos = dataSourceParser.GetDataSource(filePath);
            if (primitiveDtos.IsEmptyCollection())
                return new Dictionary<OperationResult, Primitive>();

            return primitiveDtos.Select(GetPrimitive).ToDictionary(x => x.Key, x => x.Value);
        }

        private KeyValuePair<OperationResult, Primitive> GetPrimitive(PrimitiveDto primitiveDto)
        {
            if (primitiveDto == null)
                return new KeyValuePair<OperationResult, Primitive>(new OperationResult(Resources.Failed_To_Get_Dto), null);

            var primitiveType = primitiveDto.Type;
            if (primitiveType.IsNullOrWhiteSpace())
                return new KeyValuePair<OperationResult, Primitive>(new OperationResult(Resources.Primitive_Type_Not_Specified), null);
                
            var converter = _primitiveConverterFactory.GetConverter(primitiveType);
            if (converter == null)
                return new KeyValuePair<OperationResult, Primitive>(new OperationResult(string.Format(Resources.No_Converter_Registered_For_Type, primitiveType)), null);

            var primitive = converter.Convert(primitiveDto);
            if (primitive == null)
                return new KeyValuePair<OperationResult, Primitive>(new OperationResult(Resources.Failed_To_Convert_Primitive), null);

            return new KeyValuePair<OperationResult, Primitive>(new OperationResult(), primitive);
        }
    }
}