namespace VectorViewer.Model.Primitives.Impl
{
    using System.Drawing;
    using Base;
    using Interfaces;

    public class Circle : Primitive, IFillable
    {
        public override PrimitiveTypes Type => PrimitiveTypes.Circle;

        public bool IsFilled { get; set; }

        public PointF Center { get; set; }
        
        public float Radius { get; set; }
    }
}