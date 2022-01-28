namespace VectorViewer.Services.Conversion.Converters.Base
{
    using System;
    using System.Drawing;
    using System.Globalization;
    using System.Linq;
    using Model.Exceptions;
    using Model.Primitives;
    using Model.Primitives.Base;
    using Model.Serialization;
    using Model.Settings;

    public abstract class PrimitiveConverterBase : IPrimitiveConverter
    {
        public abstract PrimitiveTypes Type { get; }

        public abstract Primitive Convert(PrimitiveDto dto);

        protected virtual void CheckDto(PrimitiveDto dto)
        {
            var primitiveType = dto?.Type;

            if (!string.Equals(primitiveType, Type.ToString(), StringComparison.CurrentCultureIgnoreCase))
                throw new UnsupportedPrimitiveException(primitiveType);
        }

        protected PointF ParsePoint(string s)
        {
            var coordinates = s.Split(Settings.ValuesSeparator);
            return new PointF(float.Parse(coordinates[0]), float.Parse(coordinates[1]));
        }

        protected float ParseDot(string s)
        {
            var cultureInfo = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            cultureInfo.NumberFormat.CurrencyDecimalSeparator = Settings.CurrencyDecimalSeparator;

            return float.Parse(s, NumberStyles.Any, cultureInfo);
        }

        protected Color ParseColor(string s)
        {
            int TryParseColor(string source)
            {
                int.TryParse(source, out var fragment);
                return fragment;
            }

            var colors = s.Split(Settings.ValuesSeparator).Select(TryParseColor).ToList();

            switch (colors.Count)
            {
                case 3:
                    return Color.FromArgb(colors[0], colors[1], colors[2]);
                case 4:
                    return Color.FromArgb(colors[0], colors[1], colors[2], colors[3]);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}