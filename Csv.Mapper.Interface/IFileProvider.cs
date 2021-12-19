using System.IO;

namespace Csv.Mapper.Interface
{
    public interface IFileProvider
    {
        Stream GetCsv();
    }
}