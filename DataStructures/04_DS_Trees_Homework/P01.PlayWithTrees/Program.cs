namespace P01.PlayWithTrees
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using _04_DS_Trees_Homework;

    public class Program
    {
        private static readonly Dictionary<int, Tree<int>> nodeByValue = new Dictionary<int, Tree<int>>();
        private static List<int> currentPath = new List<int>();
        private static List<int> currentSubtree = new List<int>();
        private static readonly Stack<int> stack = new Stack<int>();

        static void Main()
        {
            ReadTreeFromConsole();
            var root = GetRootNode();
            var leafNodes = GetLeafNodes().Select(x => x.Value).ToList().OrderBy(x => x);
            var middleNodesValues = GetMiddleNodes().Select(x => x.Value).ToList().OrderBy(x => x);

            Console.WriteLine("Root node: {0}", root.Value);
            Console.WriteLine("Leaf nodes: {0}", string.Join(", ", leafNodes));
            Console.WriteLine("Middle nodes: {0}", string.Join(", ", middleNodesValues));

            stack.Clear();
            currentPath.Clear();
            RecursiveFindLongestPath(root);
            var longestPath = currentPath.Reverse<int>();
            Console.WriteLine("Longest path: {0} (length = {1})", string.Join(" -> ", longestPath), longestPath.Count());

            stack.Clear();
            currentPath.Clear();
            var p = int.Parse(Console.ReadLine());
            Console.WriteLine("Paths of sum {0}: ", p);
            RecursiveFindPathsWithGivenSum(root, p);

            stack.Clear();
            currentPath.Clear();
            var s = int.Parse(Console.ReadLine());
            Console.WriteLine("Subtrees of sum {0}: ", s);
            RecursiveFindSubtreesWithGivenSum(root, s);
        }

        private static void RecursiveFindSubtreesWithGivenSum(Tree<int> node, int sum)
        {
            int currentTreeSum = GetSubtreeSum(node);
            if (currentTreeSum == sum)
            {
                currentSubtree.Clear();
                GetSubtreePreOrder(node);
                Console.WriteLine(string.Join(" + ", currentSubtree));
            }

            foreach (var child in node.Children)
            {
                RecursiveFindSubtreesWithGivenSum(child, sum);
            }
        }

        private static int GetSubtreeSum(Tree<int> node)
        {
            var currentSum = node.Value;
            foreach (var child in node.Children)
            {
                currentSum += GetSubtreeSum(child);
            }

            return currentSum;
        }

        private static void RecursiveFindPathsWithGivenSum(Tree<int> node, int sum)
        {
            stack.Push(node.Value);
            if (stack.Sum() == sum)
            {
                var reversedCurrentPath = stack.Reverse<int>();
                Console.WriteLine(string.Join(" -> ", reversedCurrentPath));
            }

            foreach (var child in node.Children)
            {
                RecursiveFindPathsWithGivenSum(child, sum);
            }

            stack.Pop();
        }

        private static void RecursiveFindLongestPath(Tree<int> node)
        {
            stack.Push(node.Value);
            if (stack.Count > currentPath.Count)
            {
                currentPath = stack.ToList();
            }

            foreach (var child in node.Children)
            {
                RecursiveFindLongestPath(child);
            }

            stack.Pop();
        }

        private static IList<Tree<int>> GetLeafNodes()
        {
            var result = nodeByValue.Values.Where(t => t.Children.Count == 0).ToList();
            return result;
        }

        private static IList<Tree<int>> GetMiddleNodes()
        {
            var result = nodeByValue.Values.Where(x => x.Parent != null && x.Children.Count != 0).ToList();
            return result;
        }

        private static void ReadTreeFromConsole()
        {
            var numberOfNodes = int.Parse(Console.ReadLine());
            for (int i = 1; i < numberOfNodes; i++)
            {
                var edge = Console.ReadLine().Split(' ');
                var parentValue = int.Parse(edge[0]);
                var parent = GetNodeByValue(parentValue);

                var childValue = int.Parse(edge[1]);
                var child = GetNodeByValue(childValue);

                parent.Children.Add(child);
                child.Parent = parent;
            }
        }

        private static Tree<int> GetNodeByValue(int value)
        {
            if (!nodeByValue.ContainsKey(value))
            {
                nodeByValue[value] = new Tree<int>(value);
            }

            return nodeByValue[value];
        }

        static Tree<int> GetRootNode()
        {
            var result = nodeByValue.Values.FirstOrDefault(x => x.Parent == null);
            return result;
        }

        static void GetSubtreePreOrder(Tree<int> subtree)
        {
            currentSubtree.Add(subtree.Value);
            foreach (var child in subtree.Children)
            {
                GetSubtreePreOrder(child);
            }
        }
    }
}
