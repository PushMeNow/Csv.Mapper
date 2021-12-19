using System.IO;
using Csv.Mapper.Interface;
using Csv.Mapper.Services;
using Moq;

namespace Csv.Mapper.Tests.Fixtures
{
    internal class CsvParserFixture : FixtureBase<ICsvParser>
    {
        private readonly string _fileName;

        public CsvParserFixture(string fileName)
        {
            _fileName = fileName;
        }

        protected override ICsvParser CreateService()
        {
            var mockedFileProvider = new Mock<IFileProvider>();
            mockedFileProvider.Setup(q => q.GetCsv())
                              .Returns(File.OpenRead(Path.Combine(Directory.GetCurrentDirectory(), "Data", _fileName)));

            return new CsvParser(mockedFileProvider.Object, new Splitter());
        }
    }
}