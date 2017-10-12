namespace P05.Sorting
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Sorting
    {
        static void Main()
        {
            var numberCount = int.Parse(Console.ReadLine());
            var numbers =
                Console.ReadLine()
                    .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            var flipCount = int.Parse(Console.ReadLine());

            var stepCount = FindStepsNeededBFS(numbers, numberCount, flipCount);
            Console.WriteLine(stepCount);
        }

        private static int FindStepsNeededBFS(int[] numbers, int numberCount, int flipCount)
        {
            var queue = new Queue<int[]>();
            var sequences = new Dictionary<string, int>();

            var sequenceKey = string.Join(" ", numbers);

            queue.Enqueue(numbers);
            sequences.Add(sequenceKey, 0);

            while (queue.Count > 0)
            {
                var currentSequence = queue.Dequeue();
                var currentSequenceKey = string.Join(" ", currentSequence);
                var currentStep = sequences[currentSequenceKey];

                if (IsSequenceSorted(currentSequence))
                {
                    return currentStep;
                }

                for (int currentComb = 0; currentComb <= numberCount - flipCount; currentComb++)
                {
                    var newSequence = new int[numberCount];
                    var internalCounter = 1;

                    for (int index = 0; index < numberCount; index++)
                    {
                        if (currentComb <= index && index < currentComb + flipCount)
                        {
                            newSequence[index] = currentSequence[currentComb + flipCount - internalCounter];
                            internalCounter++;
                        }
                        else
                        {
                            newSequence[index] = currentSequence[index];
                        }
                    }

                    var newSequenceKey = string.Join(" ", newSequence);
                    if (!sequences.ContainsKey(newSequenceKey))
                    {
                        queue.Enqueue(newSequence);
                        sequences.Add(newSequenceKey, currentStep + 1);
                    }
                }
            }

            return -1;
        }

        private static bool IsSequenceSorted(int[] currentSequence)
        {
            if (currentSequence.Length <= 1)
            {
                return true;
            }

            for (int i = 1; i < currentSequence.Length; i++)
            {
                if (currentSequence[i] < currentSequence[i - 1])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
