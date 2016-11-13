using System;
using System.Text;
using ECargo.Interfaces;

namespace ECargo.Describer
{
    public class NodeDescriber : INodeDescriber
    {
        private readonly StringBuilder _builder;
        private readonly string _identString;

        public NodeDescriber()
        {
            _identString = "    ";
            _builder = new StringBuilder();
        }

        public string Describe(Node node)
        {
            _builder.Clear();

            AppendDescription(node, string.Empty);

            return _builder.ToString();
        }

        private void AppendDescription(Node node, string indent)
        {
            _builder.Append($@"{indent}new {node.GetType().Name}(""{node.Name}""");

            var nextLevelIndent = _identString + indent;

            foreach (var child in Utils.GetNodeChildren(node))
            {
                _builder.Append("," + Environment.NewLine);
                AppendDescription(child, nextLevelIndent);
            }

            _builder.Append(")");
        }
    }
}