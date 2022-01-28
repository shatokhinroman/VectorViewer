namespace VectorViewer.Model.Exceptions
{
    using System;

    public class UnsupportedFileFormatException : Exception
    {
        public UnsupportedFileFormatException(string expected) : 
            base(string.Format(Resources.UnsupportedFileFormatException_Expected, expected))
        {
        }

        private UnsupportedFileFormatException()
        {
        }
    }
}