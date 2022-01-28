namespace VectorViewer.Services.Conversion.Converters.Impl
{
    using Base;
    using Model.Primitives;
    using Model.Primitives.Base;
    using Model.Primitives.Impl;
    using Model.Serialization;

    public class TriangleConverter : PrimitiveConverterBase
    {
        public override PrimitiveTypes Type => PrimitiveTypes.Triangle;

        public override Primitive Convert(PrimitiveDto dto)
        {
            base.CheckDto(dto);

            return new Triangle
            {
                A = ParsePoint(dto.A),
                B = ParsePoint(dto.B),
                C = ParsePoint(dto.C),
                IsFilled = dto.Filled,
                Color = ParseColor(dto.Color)
            };
        }
    }
}