using System;

namespace _00_DS_CollectionsLab
{
    using System.Globalization;
    using System.Threading;
    using Wintellect.PowerCollections;

    public class Program
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var events = new OrderedMultiDictionary<DateTime, string>(true);
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string eventEntry = Console.ReadLine();
                string[] tokens = eventEntry.Split('|');
                string eventName = tokens[0].Trim();
                DateTime eventTime = DateTime.Parse(tokens[1].Trim());
                events.Add(eventTime, eventName);
            }

            var numberOfDates = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfDates; i++)
            {
                var dates = Console.ReadLine();
                var tokens = dates.Split('|');
                var start = DateTime.Parse(tokens[0].Trim());
                var end = DateTime.Parse(tokens[1].Trim());
                var eventsRange = events.Range(start, true, end, true);

                Console.WriteLine(eventsRange.Values.Count);
                foreach (var e in eventsRange)
                {
                    foreach (var eventName in e.Value)
                    {
                        Console.WriteLine("{0} | {1}", eventName, e.Key);
                    }
                }
            }
        }
    }
}
