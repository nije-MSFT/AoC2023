﻿namespace AoC2023_8
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

            var allResultingSteps = new List<long>();
            var allCurrentNodes = new List<Node>();

            allCurrentNodes
                .AddRange(allNodes.Values.Where(x => x.Name.EndsWith('A')));

            foreach (var node in allCurrentNodes)
            {
                allResultingSteps.Add(NumberOfSteps(node, steps));
            }

            foreach (var path in allResultingSteps)
            {
                Console.WriteLine(path);
                primeFactors(path);
            }

            Console.WriteLine($"Part 1: {totalPart1}");
            Console.WriteLine($"Part 2: {totalPart2}");
        }

        public static void primeFactors(long n)
        {
            // Print the number of 2s that divide n 
            while (n % 2 == 0)
            {
                Console.Write(2 + " ");
                n /= 2;
            }

            // n must be odd at this point. So we can 
            // skip one element (Note i = i +2) 
            for (int i = 3; i <= Math.Sqrt(n); i += 2)
            {
                // While i divides n, print i and divide n 
                while (n % i == 0)
                {
                    Console.Write(i + " ");
                    n /= i;
                }
            }

            // This condition is to handle the case when 
            // n is a prime number greater than 2 
            if (n > 2)
                Console.Write(n);
            Console.Write('\n');
        }

        public static long NumberOfSteps(Node startingNode, string steps)
        {
            long totalSteps = 0;
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
