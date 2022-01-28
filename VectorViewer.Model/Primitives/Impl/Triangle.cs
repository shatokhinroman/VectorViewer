namespace VectorViewer.Model.Primitives.Impl
{
    using System.Drawing;
    using Base;
    using Interfaces;

    public class Triangle : Primitive, IFillable
    {
        public override PrimitiveTypes Type => PrimitiveTypes.Triangle;

        public PointF A { get; set; }

        public PointF B { get; set; }

        public PointF C { get; set; }

        public bool IsFilled { get; set; }
    }
}