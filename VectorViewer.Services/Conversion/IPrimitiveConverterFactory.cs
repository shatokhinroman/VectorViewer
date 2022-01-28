namespace VectorViewer.Services.Conversion
{
    using Converters.Base;

    public interface IPrimitiveConverterFactory
    {
        IPrimitiveConverter GetConverter(string primitiveType);
    }
}