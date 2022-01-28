namespace VectorViewer.Services.DataSources.Parsers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Model.Exceptions;
    using Model.Serialization;
    using Newtonsoft.Json;

    public class JsonDataSourceParser : IPrimitiveDataSourceParser
    {
        public string FileExtension => @".json";

        public List<PrimitiveDto> GetDataSource(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException(string.Format(Resources.JsonDataSourceParser_file_not_found, filePath));

            if (!Path.GetExtension(filePath).Equals(FileExtension, StringComparison.CurrentCultureIgnoreCase))
                throw new UnsupportedFileFormatException(expected: FileExtension);

            using (var file = File.OpenText(filePath))
            {
                var serializer = new JsonSerializer();
                return ((IEnumerable<PrimitiveDto>)serializer.Deserialize(file, typeof(IEnumerable<PrimitiveDto>))).ToList();
            }
        }
    }
}  