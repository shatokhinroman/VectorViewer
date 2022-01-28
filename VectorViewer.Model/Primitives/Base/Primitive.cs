namespace VectorViewer.Model.Primitives.Base
{
    using System.Drawing;
    using Interfaces;

    public abstract class Primitive : IColored
    {
        public abstract PrimitiveTypes Type { get; }
        
        public Color Color { get; set; }
    }
}