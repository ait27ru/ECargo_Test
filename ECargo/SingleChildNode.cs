namespace ECargo
{
    public class SingleChildNode : Node
    {
        public SingleChildNode(string name, Node child) : base(name)
        {
            Child = child;
        }

        public Node Child { get; }
    }
}