namespace VectorViewer.UI.Utils
{
    using System.Windows.Media;
    using Brush = System.Windows.Media;

    public static class ColorUtils
    {
        public static Brush.Brush ToBrush(this System.Drawing.Color color)
        {
            return new SolidColorBrush(Color.FromArgb(color.A, color.R, color.G, color.B));
        }
    }
}