namespace VectorViewer.Services.Conversion.Converters.Base
{
    using Model.Primitives;
    using Model.Primitives.Base;
    using Model.Serialization;

    public interface IPrimitiveConverter
    {
        PrimitiveTypes Type { get; }

        Primitive Convert(PrimitiveDto dto);
    }
}