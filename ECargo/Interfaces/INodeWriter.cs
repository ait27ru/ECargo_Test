using System.Threading.Tasks;

namespace ECargo.Interfaces
{
    public interface INodeWriter
    {
        Task WriteToFileAsync(Node node, string filePath);
    }
}