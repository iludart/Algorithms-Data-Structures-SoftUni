using System;
using System.Collections.Generic;

class Salaries
{
    static List<int>[] graph;
    static HashSet<int> visited;
    static Dictionary<int, int> salaries;

    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        graph = new List<int>[n];
        visited = new HashSet<int>();
        salaries = new Dictionary<int, int>();

        // reading the graph
        for (int index = 0; index < graph.Length; index++)
        {
            graph[index] = new List<int>();
            var line = Console.ReadLine().ToCharArray();
            for (int ch = 0; ch < line.Length; ch++)
            {
                if (line[ch] == 'Y')
                {
                    graph[index].Add(ch);
                }
            }
        }

        var totalSalaries = DFS();
        Console.WriteLine(totalSalaries);
    }

    private static int DFS()
    {
        var totalSalaries = 0;

        for (int vertex = 0; vertex < graph.Length; vertex++)
        {
            if (!visited.Contains(vertex))
            {
                DFSVisit(vertex);
            }

            totalSalaries += salaries[vertex];
        }

        return totalSalaries;
    }


    private static void DFSVisit(int vertex)
    {
        visited.Add(vertex);

        if (graph[vertex].Count == 0)
        {
            salaries[vertex] = 1;
        }
        else
        {
            int vertexSalary = 0;

            foreach (var child in graph[vertex])
            {
                if (!visited.Contains(child))
                {
                    DFSVisit(child);
                }

                vertexSalary += salaries[child];
            }

            salaries[vertex] = vertexSalary;
        }
    }
}
