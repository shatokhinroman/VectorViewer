namespace VectorViewer.Model.Primitives.Impl
{
    using System.Drawing;
    using Base;

    public class Line : Primitive
    {
        public override PrimitiveTypes Type => PrimitiveTypes.Line;
        
        public PointF A { get; set; }
        
        public PointF B { get; set; }
    }
}