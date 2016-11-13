using System.Collections.Generic;

namespace ECargo
{
    public class ManyChildrenNode : Node
    {
        public ManyChildrenNode(string name, params Node[] children) : base(name)
        {
            Children = children;
        }

        public IEnumerable<Node> Children { get; }
    }
}