namespace VectorViewer.Model.Positions
{
    public class Position
    {
        public Position(double left, double top, double right, double bottom) : this()
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
        }

        private Position()
        {
        }

        public double Left { get; internal set; }

        public double Top { get; internal set; }

        public double Right { get; internal set; }

        public double Bottom { get; internal set; }
    }
}