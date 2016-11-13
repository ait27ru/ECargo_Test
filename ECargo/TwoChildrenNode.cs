namespace ECargo
{
    public class TwoChildrenNode : Node
    {
        public TwoChildrenNode(string name, Node first, Node second) : base(name)
        {
            FirstChild = first;
            SecondChild = second;
        }

        public Node FirstChild { get; }
        public Node SecondChild { get; }
    }
}