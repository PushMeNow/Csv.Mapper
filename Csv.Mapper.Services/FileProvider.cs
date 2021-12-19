using System;
using System.IO;
using Csv.Mapper.Interface;
using Dawn;

namespace Csv.Mapper.Services
{
    public class FileProvider : IFileProvider
    {
        private readonly IPathProvider _pathProvider;

        public FileProvider(IPathProvider pathProvider)
        {
            Guard.Argument(pathProvider, nameof(pathProvider))
                 .NotNull();

            _pathProvider = pathProvider;
        }

        public Stream GetCsv()
        {
            var path = _pathProvider.GetPath();

            Guard.Argument(path, nameof(path))
                 .NotWhiteSpace();

            var currentEx = Path.GetExtension(path); 
            if (currentEx != "csv")
            {
                throw new FormatException($"Argument {nameof(path)} has to have extension 'csv'. Current extension {currentEx}");
            }

            return File.OpenRead(path);
        }
    }
}