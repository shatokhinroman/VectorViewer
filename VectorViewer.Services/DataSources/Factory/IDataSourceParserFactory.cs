namespace VectorViewer.Services.DataSources.Factory
{
    using Parsers;

    public interface IDataSourceParserFactory
    {
        IPrimitiveDataSourceParser GetDataSourceParser(string filePath);
    }
}