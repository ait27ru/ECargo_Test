using System;
using System.Collections.Generic;
using System.Linq;

namespace ECargo.Describer
{
    public static class Utils
    {
        public static IEnumerable<Node> GetNodeChildren(Node node)
        {
            var noChildrenNode = node as NoChildrenNode;
            var list = new List<Node>();

            if (noChildrenNode != null)
            {
                return list;
            }

            var singleChildNode = node as SingleChildNode;

            if (singleChildNode != null)
            {
                list.Add(singleChildNode.Child);
                return list;
            }

            var twoChildrenNode = node as TwoChildrenNode;

            if (twoChildrenNode != null)
            {
                list.Add(twoChildrenNode.FirstChild);
                list.Add(twoChildrenNode.SecondChild);
                return list;
            }

            var manyChildrenNode = node as ManyChildrenNode;

            if (manyChildrenNode != null)
            {
                return manyChildrenNode.Children.Select(c => c);
            }

            throw new NotSupportedException($"Nodes of {node.GetType()} type are not supported.");
        }
    }
}