namespace VectorViewer.UI.Primitives.Impl
{
    using System.Drawing;
    using VectorViewer.Model.Primitives.Impl;
    
    using Base;
    using Model.Positions;
    using Model.Primitives;
    using Model.Primitives.Base;

    public class CircleViewModel : PrimitiveViewModelBase
    {
        private Circle _circle;

        public override PrimitiveTypes Type => PrimitiveTypes.Circle;
        
        public PointF Center => _circle.Center;

        public float Radius => _circle.Radius;

        public float Top => Center.Y + Radius;
        
        public float Left => Center.X - Radius;

        public float Height => Diameter;

        public float Width => Diameter;

        public float Diameter => Radius * 2;

        /// <inheritdoc />
        public override Position GetPosition() => new Position(Left, Top, Left + Diameter, Top - Diameter);

        public override IPrimitiveViewModel Initialize(Primitive primitive)
        {
            base.Initialize(primitive);

            _circle = primitive as Circle;

            return this;
        }
    }
}