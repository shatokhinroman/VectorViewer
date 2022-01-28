namespace VectorViewer.UI.Primitives.Impl
{
    using Base;
    using Model.Positions;
    using Model.Primitives;
    using Model.Primitives.Base;
    using Model.Primitives.Impl;

    public class LineViewModel : PrimitiveViewModelBase
    {
        private Line _line;

        public override PrimitiveTypes Type => PrimitiveTypes.Line;

        public float X1 => _line.A.X;

        public float Y1 => _line.A.Y;

        public float X2 => _line.B.X;

        public float Y2 => _line.B.Y;

        private float Left => X1 <= X2 ? X1 : X2;

        private float Top => Y1 >= Y2 ? Y1 : Y2;

        private float Right => X1 >= X2 ? X1 : X2;

        private float Bottom => Y1 <= Y2 ? Y2 : Y1;

        /// <inheritdoc />
        public override Position GetPosition() => new Position(Left, Top, Right, Bottom);

        public override IPrimitiveViewModel Initialize(Primitive primitive)
        {
            base.Initialize(primitive);
            _line = primitive as Line;

            return this;
        }
    }
}