namespace VectorViewer.Model.Exceptions
{
    using System;

    public class UnsupportedPrimitiveException : Exception
    {
        public UnsupportedPrimitiveException(string unsupportedTypeName) :
            base(string.Format(Resources.UnsupportedPrimitiveException, unsupportedTypeName))
        {
        }

        private UnsupportedPrimitiveException()
        {
        }
    }
}