using System.Linq;
using ECargo.Describer;
using ECargo.Interfaces;

namespace ECargo.Transformer
{
    public class NodeTransformer : INodeTransformer
    {
        public Node Transform(Node node)
        {
            return MakeTransformation(node);
        }

        private Node MakeTransformation(Node node)
        {
            var nodeChildren = Utils.GetNodeChildren(node).ToArray();
            var childrenNum = nodeChildren.Count();

            Node convertedNode;

            switch (childrenNum)
            {
                case 0:
                    convertedNode = new NoChildrenNode(node.Name);
                    break;

                case 1:
                    convertedNode = new SingleChildNode(node.Name,
                        MakeTransformation(nodeChildren[0]));
                    break;

                case 2:
                    convertedNode = new TwoChildrenNode(node.Name,
                        MakeTransformation(nodeChildren[0]),
                        MakeTransformation(nodeChildren[1]));
                    break;

                default:
                    convertedNode = new ManyChildrenNode(node.Name,
                        nodeChildren
                            .Select(MakeTransformation)
                            .ToArray());
                    break;
            }

            return convertedNode;
        }
    }
}