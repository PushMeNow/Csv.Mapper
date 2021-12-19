using System.Collections.Generic;

namespace Csv.Mapper.Interface
{
    public interface ISplitter
    {
        IEnumerable<string> Split(string line);
    }
}