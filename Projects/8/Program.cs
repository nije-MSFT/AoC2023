namespace AoC2023_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var inputLines = File.ReadAllLines(".\\Input.txt");

            var allNodes = new Dictionary<string, Node>();
            var steps = inputLines[0];

            long totalPart1 = 0;
            int totalPart2 = 0;

            foreach (var line in inputLines.Skip(2))
            {
                var nodeName = line
                    .Split('=')[0]
                    .Trim();

                var leftName = line
                    .Split('=')[1]
                    .Split(',')[0]
                    .Trim()
                    .Substring(1, 3);

                var rightName = line
                    .Split('=')[1]
                    .Split(',')[1]
                    .Trim()
                    .Substring(0, 3);


                Node node;

                if (allNodes.TryGetValue(nodeName, out Node? value))
                {
                    node = value;
                }
                else
                {
                    node = new Node(nodeName);
                    allNodes.Add(nodeName, node);
                }

                if (allNodes.TryGetValue(leftName, out Node? value2))
                {
                    node.Left = value2;
                }
                else
                {
                    node.Left = new Node(leftName);
                    allNodes.Add(leftName, node.Left);
                }

                if (allNodes.TryGetValue(rightName, out Node? value3))
                {
                    node.Right = value3;
                }
                else
                {
                    node.Right = new Node(rightName);
                    allNodes.Add(rightName, node.Right);
                }
            }

            var currentNode = allNodes["AAA"];

            totalPart1 = NumberOfSteps(allNodes["AAA"], steps);

            var allResultingSteps = new List<int>();
            var allCurrentNodes = new List<Node>();

            allCurrentNodes
                .AddRange(allNodes.Values.Where(x => x.Name.EndsWith('A')));

            foreach (var node in allCurrentNodes)
            {
                allResultingSteps.Add(NumberOfSteps(node, steps));
            }

            var allFactors = new List<int>();

            foreach (var path in allResultingSteps)
            {
                Console.WriteLine(path);
                allFactors.AddRange(primeFactors(path));
            }

            Console.WriteLine($"Part 1: {totalPart1}");
            Console.WriteLine($"Part 2: {totalPart2}");
        }

        public static List<int> primeFactors(int n)
        {
            var primeFactors = new List<int>();

            while (n % 2 == 0)
            {
                primeFactors.Add(2);
                n /= 2;
            }

            for (int i = 3; i <= Math.Sqrt(n); i += 2)
            {
                while (n % i == 0)
                {
                    primeFactors.Add(i);
                    n /= i;
                }
            }

            if (n > 2)
                primeFactors.Add(n);

            return primeFactors;
        }

        public static int NumberOfSteps(Node startingNode, string steps)
        {
            int totalSteps = 0;
            int stepPosition = 0;

            Node currentNode = startingNode;

            while (!currentNode.Name.EndsWith("Z"))
            {
                if (steps[stepPosition] == 'L')
                {
                    currentNode = currentNode.Left;
                }
                else
                {
                    currentNode = currentNode.Right;
                }

                totalSteps++;
                stepPosition++;

                if (stepPosition == steps.Length)
                {
                    stepPosition = 0;
                }
            }

            return totalSteps;
        }
    }
}
