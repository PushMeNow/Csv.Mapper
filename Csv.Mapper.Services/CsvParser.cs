using System.Collections.Generic;
using System.IO;
using Csv.Mapper.Interface;
using Dawn;

namespace Csv.Mapper.Services
{
    public class CsvParser : ICsvParser
    {
        private readonly IFileProvider _fileProvider;
        private readonly ISplitter _splitter;

        public CsvParser(IFileProvider fileProvider, ISplitter splitter)
        {
            Guard.Argument(fileProvider, nameof(fileProvider))
                 .NotNull();
            Guard.Argument(splitter, nameof(splitter))
                 .NotNull();
            
            _fileProvider = fileProvider;
            _splitter = splitter;
        }
        
        public async IAsyncEnumerable<IEnumerable<string>> GetColumnValues()
        {
            await foreach (var line in GetLines())
            {
                yield return _splitter.Split(line);
            }
        }

        public async IAsyncEnumerable<string> GetLines()
        {
            await using var csvStream = _fileProvider.GetCsv();
            var reader = new StreamReader(csvStream);

            while (!reader.EndOfStream)
            {
                yield return await reader.ReadLineAsync();
            }
        }
    }
}