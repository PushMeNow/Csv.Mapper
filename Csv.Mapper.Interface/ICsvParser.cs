using System.Collections.Generic;

namespace Csv.Mapper.Interface
{
    public interface ICsvParser
    {
        IAsyncEnumerable<IEnumerable<string>> GetColumnValues();

        IAsyncEnumerable<string> GetLines();
    }
}