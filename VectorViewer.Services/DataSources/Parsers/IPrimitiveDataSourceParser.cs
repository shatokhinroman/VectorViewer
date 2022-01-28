namespace VectorViewer.Services.DataSources.Parsers
{
    using System.Collections.Generic;
    using Model.Serialization;

    public interface IPrimitiveDataSourceParser
    {
        string FileExtension { get; }

        List<PrimitiveDto> GetDataSource(string filePath);
    }
}