namespace VectorViewer.Services.Conversion.Converters.Impl
{
    using Base;
    using Model.Primitives;
    using Model.Primitives.Base;
    using Model.Primitives.Impl;
    using Model.Serialization;

    public class CircleConverter : PrimitiveConverterBase
    {
        public override PrimitiveTypes Type => PrimitiveTypes.Circle;

        public override Primitive Convert(PrimitiveDto dto)
        {
            base.CheckDto(dto);

            return new Circle
            {
                Center = ParsePoint(dto.Center),
                Radius = ParseDot(dto.Radius),
                IsFilled = dto.Filled,
                Color = ParseColor(dto.Color)
            };
        }
    }
}