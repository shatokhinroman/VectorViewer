namespace VectorViewer.UI.Primitives.Base
{
    using Model.Primitives.Base;
    using System.Windows.Media;
    using Model.Positions;
    using Model.Primitives;
    using Utils;

    public abstract class PrimitiveViewModelBase : IPrimitiveViewModel
    {
        public abstract PrimitiveTypes Type { get; }
        
        public abstract Position GetPosition();

        protected Primitive Primitive;

        public virtual Brush Stroke => Primitive.Color.ToBrush();

        public virtual Brush Fill => Primitive.Color != default ? Primitive.Color.ToBrush() : Brushes.Transparent;

        public virtual IPrimitiveViewModel Initialize(Primitive primitive)
        {
            Primitive = primitive;
            return this;
        }
    }
}