namespace VectorViewer.Services.Conversion
{
    using System;
    using System.Linq;
    using Converters.Base;
    using Utils;

    public class PrimitiveConverterFactory : IPrimitiveConverterFactory
    {
        private readonly Func<IPrimitiveConverter[]> _getConverters;
        
        public PrimitiveConverterFactory(
            Func<IPrimitiveConverter[]> getConverters)
        {
            _getConverters = getConverters;
        }
        
        public IPrimitiveConverter GetConverter(string primitiveType)
        {
            if (primitiveType.IsNullOrWhiteSpace())
                throw new ArgumentNullException(Resources.Primitive_Type_Not_Supplied);

            var converter = _getConverters().SingleOrDefault(c => c.Type.ToString().Equals(primitiveType, StringComparison.CurrentCultureIgnoreCase));
            if (converter == null)
                throw new Exception(string.Format(Resources.Converter_Not_Registered, primitiveType));

            return converter;
        }
    }
}