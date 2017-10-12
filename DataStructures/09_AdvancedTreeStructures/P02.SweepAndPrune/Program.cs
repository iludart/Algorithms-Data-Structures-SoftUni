namespace P02.SweepAndPrune
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static void Main()
        {
            var gameObjects = new List<GameObject>();
            var command = Console.ReadLine();
            var ticks = 1;

            while (!string.IsNullOrEmpty(command))
            {
                var commandParams = command.Split(' ');

                if (commandParams[0].Equals("add"))
                {
                    var gameObject = new GameObject(commandParams[1], int.Parse(commandParams[2]),
                        int.Parse(commandParams[3]));

                    gameObjects.Add(gameObject);
                }

                if (commandParams[0].Equals("start"))
                {
                    while (true)
                    {
                        command = Console.ReadLine();
                        commandParams = command.Split(' ');

                        if (commandParams[0].Equals("move"))
                        {
                            var objectToMoveId = commandParams[1];
                            var obj = gameObjects.FirstOrDefault(x => x.Id.Equals(objectToMoveId));

                            obj?.Move(int.Parse(commandParams[2]), int.Parse(commandParams[3]));
                        }

                        gameObjects = SweepAndPrune(gameObjects, ticks);
                        ticks++;
                    }
                }

                command = Console.ReadLine();
            }
        }

        public static List<GameObject> SweepAndPrune(List<GameObject> objects, int tickCount)
        {
            objects = InsertionSort(objects);
            for (int i = 0; i < objects.Count; i++)
            {
                var currentObj = objects[i];
                for (int j = i + 1; j < objects.Count; j++)
                {
                    var candidateCollisionObj = objects[j];
                    if (currentObj.Bounds.X2 < candidateCollisionObj.Bounds.X1)
                    {
                        break;
                    }

                    if (currentObj.Bounds.Intersects(candidateCollisionObj.Bounds))
                    {
                        Console.WriteLine("({0}){1} collides with {2}", tickCount, currentObj.Id, candidateCollisionObj.Id);
                    }
                }
            }

            return objects;
        }

        private static List<GameObject> InsertionSort(List<GameObject> objects)
        {
            for (int i = 0; i < objects.Count; i++)
            {
                int j = i;
                while (j > 0 && objects[j - 1].Bounds.X1 > objects[j].Bounds.X1)
                {
                    var temp = objects[j - 1];
                    objects[j - 1] = objects[j];
                    objects[j] = temp;
                    j--;
                }
            }

            return objects;
        }
    }
}
