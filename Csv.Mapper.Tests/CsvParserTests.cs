using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Csv.Mapper.Tests.Fixtures;
using Xunit;

namespace Csv.Mapper.Tests
{
    public class CsvParserTests
    {
        [Fact]
        public async Task GetLines_OK()
        {
            var fixture = new CsvParserFixture("ok-test-csv-parser.csv");
            var lines = await fixture.Service
                                     .GetLines()
                                     .ToArrayAsync();

            Assert.Single(lines);
            var fist = lines[0];
            Assert.Equal("test,1.2,case", fist);
        }
    }
}