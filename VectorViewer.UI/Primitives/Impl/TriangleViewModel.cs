namespace VectorViewer.UI.Primitives.Impl
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Media;
    using Base;
    using Model.Positions;
    using Model.Primitives;
    using Model.Primitives.Base;
    using Model.Primitives.Impl;
    using Utils;

    public class TriangleViewModel : PrimitiveViewModelBase
    {
        private Triangle _triangle;

        public override PrimitiveTypes Type => PrimitiveTypes.Triangle;

        public PointCollection PointCollection => Points.ToPointCollection();

        private List<PointF> Points => new List<PointF>
        {
            _triangle.A,
            _triangle.B,
            _triangle.C
        };

        /// <inheritdoc />
        public override Position GetPosition()
        {
            var left = Points.Select(p => p.X).OrderBy(x => x).First();
            var top = Points.Select(p => p.Y).OrderBy(x => x).Last();
            var right = Points.Select(p => p.X).OrderBy(x => x).Last();
            var bottom = Points.Select(p => p.Y).OrderBy(x => x).First();

            return new Position(left, top, right, bottom);
        }

        public override IPrimitiveViewModel Initialize(Primitive primitive)
        {
            base.Initialize(primitive);

            _triangle = primitive as Triangle;
            return this;
        }
    }
}