namespace VectorViewer.Model.Positions
{
    using System;
    using System.Collections.Generic;

    public static class PositionExtensions
    {
        public static bool IsInsideOf(this Position @this, Position that) =>
            @this.Left >= that.Left &&
            @this.Right <= that.Right &&
            @this.Top <= that.Top &&
            @this.Bottom >= that.Bottom;

        public static Position ToCartesian(this Position @this)
        {
            var xCenter = @this.Right / 2;
            var yCenter = @this.Bottom / 2;

            @this.Left -= xCenter;
            @this.Right -= xCenter;
            @this.Top = 0 - (@this.Top -= yCenter);
            @this.Bottom = 0 - (@this.Bottom-= yCenter);

            return @this;
        }

        public static double GetScaleFor(this Position @this, Position that, double defaultScale)
        {
            var scale = defaultScale;

            if (@this.IsInsideOf(that))
                return scale;

            var comparisonPairs = new[]
            {
                new KeyValuePair<double, double>(@this.Left, that.Left),
                new KeyValuePair<double, double>(@this.Top, that.Top),
                new KeyValuePair<double, double>(@this.Right, that.Right),
                new KeyValuePair<double, double>(@this.Bottom, that.Bottom)
            };

            foreach (var pair in comparisonPairs)
            {
                if (Math.Abs(pair.Key) == 0)
                    continue;

                var currentScale = Math.Abs(pair.Value) / Math.Abs(pair.Key);
                if (currentScale >= scale)
                    continue;

                scale = currentScale;
            }

            return scale;
        }
    }
}