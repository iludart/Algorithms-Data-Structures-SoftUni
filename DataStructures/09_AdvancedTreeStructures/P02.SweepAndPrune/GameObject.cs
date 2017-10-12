namespace P02.SweepAndPrune
{
    using System;
    using QuadTree.Core;

    public class GameObject : IBoundable, IComparable<GameObject>
    {
        public const int Width = 10;
        public const int Height = 10;

        public GameObject(string id, int x, int y, int width = Width, int height = Height)
        {
            this.Id = id;
            this.Bounds = new Rectangle(x, y, Width, Height);
        }

        public string Id { get; set; }

        public void Move(int x, int y)
        {
            this.Bounds.X1 = x;
            this.Bounds.X2 = x + Width;
            this.Bounds.Y1 = y;
            this.Bounds.Y2 = y + Height;
        }

        public Rectangle Bounds { get; set; }

        public int CompareTo(GameObject other)
        {
            return this.Id.CompareTo(other.Id);
        }

        public override string ToString()
        {
            return string.Format("[{0}]", this.Id);
        }
    }
}
