namespace P01.Dictionary
{
    public class KeyValue<TKey, TValue>
    {
        public KeyValue(TKey key, TValue valule)
        {
            this.Key = key;
            this.Value = valule;
        }

        public TKey Key { get; set; }

        public TValue Value { get; set; }

        public override bool Equals(object other)
        {
            var element = (KeyValue<TKey, TValue>)other;
            return this.Key.Equals(element.Key);
        }

        public override int GetHashCode()
        {
            return this.Key.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format(" [{0} -> {1}]", this.Key, this.Value);
        }
    }
}
