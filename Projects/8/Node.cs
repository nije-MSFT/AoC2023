namespace AoC2023_8
{
    public class Node
    {
        public string Name { get; }

        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(string name)
        {
            Name = name;
        }

        public Node (string name, Node left,  Node right)
        {
            Name = name;
            Left = left;
            Right = right;
        }
    }
}
