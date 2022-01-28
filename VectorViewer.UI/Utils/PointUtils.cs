namespace VectorViewer.UI.Utils
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using Point = System.Windows.Point;
    
    public static class PointUtils
    {
        public static Point ToPoint(this PointF pointF)
        {
            return new Point(pointF.X, pointF.Y);
        }

        public static System.Windows.Media.PointCollection ToPointCollection(this IEnumerable<PointF> points)
        {
            return new System.Windows.Media.PointCollection(points.Select(ToPoint));
        }
    }
}