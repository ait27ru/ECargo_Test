using System.IO;
using System.Threading.Tasks;
using ECargo.Interfaces;

namespace ECargo.Writer
{
    public class NodeWriter : INodeWriter
    {
        private readonly INodeDescriber _describer;

        public NodeWriter(INodeDescriber describer)
        {
            _describer = describer;
        }

        public async Task WriteToFileAsync(Node node, string filePath)
        {
            using (var writer = File.CreateText(filePath))
            {
                var description = await GetNodeDescriptionAsync(node);
                await writer.WriteAsync(description);
            }
        }

        private Task<string> GetNodeDescriptionAsync(Node node)
        {
            var result = Task.FromResult(_describer.Describe(node));
            return result;
        }
    }
}