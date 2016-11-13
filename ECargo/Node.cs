namespace ECargo
{
    public abstract class Node
    {
        protected Node(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}