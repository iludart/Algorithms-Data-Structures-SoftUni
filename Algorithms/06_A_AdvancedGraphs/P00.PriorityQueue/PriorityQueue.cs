using Wintellect.PowerCollections;
using P00.PriorityQueue;

namespace P00.PriorityQueue
{
    public class PriorityQueue<Node>
    {
        private OrderedBag<Node> queue;

        public PriorityQueue()
        {
            queue = new OrderedBag<Node>();
        }

        public void Enqueue(Node element)
        {
            this.queue.Add(element);
        }

        public Node ExtractMin()
        {
            var result = this.queue.RemoveFirst();
            return result; 
        }

        public void DecreaseKey(Node element, int newKey)
        {
            element.Distance = 
            this.queue.Remove(element);
            this.queue.Add(element);
        }
    }
}
