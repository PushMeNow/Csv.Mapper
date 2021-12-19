using System.Collections.Generic;
using System.Text.RegularExpressions;
using Csv.Mapper.Interface;

namespace Csv.Mapper.Services
{
    public class Splitter : ISplitter
    {
        private const string SplitPattern = @"(?:^|,)(?=[^""]|("")?)""?((?(1)[^""]*|[^,""]*))""?(?=,|$)";

        private readonly Regex _splitRegex = new(SplitPattern);
        
        public IEnumerable<string> Split(string line)
        {
            return _splitRegex.Split(line);
        }
    }
}