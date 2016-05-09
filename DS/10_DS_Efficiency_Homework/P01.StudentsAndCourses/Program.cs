namespace DictionaryExtensions.StudentsAndCourses
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            const string filePath = "../../students.txt";

            var courses = new SortedDictionary<string, SortedSet<Student>>();

            using (var reader = new StreamReader(filePath))
            {
                var line = reader.ReadLine();

                while (!string.IsNullOrEmpty(line))
                {
                    var studentParams = line.Split('|').Select(x => x.Trim()).ToArray();
                    var firstName = studentParams[0];
                    var lastName = studentParams[1];
                    var course = studentParams[2];
                    var student = new Student(firstName, lastName, course);

                    courses.EnsureKeyExists(course);
                    courses.AppendValueToKey(course, student);

                    line = reader.ReadLine();
                }
            }

            foreach (var course in courses)
            {
                Console.WriteLine("{0}: {1}", course.Key, string.Join(", ", course.Value));
            }
        }
    }
}
