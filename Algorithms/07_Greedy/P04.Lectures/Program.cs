using System;
using System.Collections.Generic;

class BestLecturesSchedule
{
    static void Main()
    {
        Console.Write("Lectures: ");
        int numberOfLectures = int.Parse(Console.ReadLine());
        var lectures = new dynamic[numberOfLectures];
        for (int i = 0; i < numberOfLectures; i++)
        {
            var currentLine = Console.ReadLine()
                .Split(new char[] { ':', ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);
            lectures[i] = new
            {
                Name = currentLine[0],
                Start = int.Parse(currentLine[1]),
                Finish = int.Parse(currentLine[2])
            };
        }

        Array.Sort(lectures, (a, b) => a.Finish.CompareTo(b.Finish));
        var result = new Dictionary<string, string>();
        var lastSelectedLecture = lectures[0];
        result.Add(lastSelectedLecture.Start + "-" + lastSelectedLecture.Finish, lastSelectedLecture.Name);

        foreach (var lecture in lectures)
        {
            if (lecture.Start >= lastSelectedLecture.Finish)
            {
                result.Add(lecture.Start + "-" + lecture.Finish, lecture.Name);
                lastSelectedLecture = lecture;
            }
        }

        Console.WriteLine();
        Console.WriteLine("Lectures ({0}):", result.Count);
        foreach (var res in result)
        {
            Console.WriteLine("{0} -> {1}", res.Key, res.Value);
        }
    }
}