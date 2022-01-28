namespace VectorViewer.Services.DataSources.Factory
{
    using System;
    using System.IO;
    using System.Linq;
    using Parsers;
    using Utils;

    public class DataSourceParserFactory : IDataSourceParserFactory
    {
        private readonly Func<IPrimitiveDataSourceParser[]> _getDataSourceParsers;

        public DataSourceParserFactory(
            Func<IPrimitiveDataSourceParser[]> getDataSourceParsers)
        {
            _getDataSourceParsers = getDataSourceParsers;
        }

        public IPrimitiveDataSourceParser GetDataSourceParser(string filePath)
        {
            if (filePath.IsNullOrWhiteSpace())
                return null;

            var extension = Path.GetExtension(filePath);
            if (extension.IsNullOrWhiteSpace())
                return null;

            return _getDataSourceParsers().SingleOrDefault(p => p.FileExtension == extension);
        }
    }
}