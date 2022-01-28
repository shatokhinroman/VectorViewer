namespace VectorViewer.Services.Conversion.Converters.Impl
{
    using Base;
    using Model.Primitives;
    using Model.Primitives.Base;
    using Model.Primitives.Impl;
    using Model.Serialization;

    public class LineConverter : PrimitiveConverterBase
    {
        public override PrimitiveTypes Type => PrimitiveTypes.Line;

        public override Primitive Convert(PrimitiveDto dto)
        {
            base.CheckDto(dto);

            return new Line
            {
                A = ParsePoint(dto.A),
                B = ParsePoint(dto.B),
                Color = ParseColor(dto.Color)
            };
        }
    }
}