using System;
using System.Collections.Generic;
using System.Linq;

class ProcessorScheduling
{
    static void Main()
    {
        Console.Write("Tasks: ");
        int tasksCount = int.Parse(Console.ReadLine());
        var tasks = new dynamic[tasksCount];
        for (int i = 0; i < tasksCount; i++)
        {
            var taskParams = Console.ReadLine().Split('-').Select(int.Parse).ToList();
            tasks[i] = new
            {
                TaskNumber = i + 1,
                Value = taskParams[0],
                Deadline = taskParams[1]
            };
        }

        Array.Sort(tasks, (a, b) => b.Value.CompareTo(a.Value));
        List<dynamic> optimalShedule = new List<dynamic>();
        int totalValue = 0;

        foreach (dynamic task in tasks)
        {
            if (CanAddTask(new List<dynamic>(optimalShedule), task))
            {
                optimalShedule.Add(task);
                totalValue += task.Value;
            }
        }
        var result = optimalShedule
            .OrderBy(e => e.Deadline)
            .ThenByDescending(e => e.Value);

        Console.WriteLine("Optimal schedule: {0}", string.Join(" -> ",
            result.Select(e => e.TaskNumber)));
        Console.WriteLine("Total value: {0}", totalValue);
    }

    private static bool CanAddTask(List<dynamic> shedule, dynamic taskToAdd)
    {
        shedule.Add(taskToAdd);
        var currentShedule = shedule.OrderBy(e => e.Deadline).ToList();
        return !currentShedule.Where((task, i) => task.Deadline < i + 1).Any();
    }
}