using System;
using System.Collections.Generic;
using DictionaryExtensions.StudentsAndCourses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02.BiDictionary
{
    using DictionaryExtensions;

    public class BiDictionary<TKey1, TKey2, TValue>
    {
        private Dictionary<TKey1, List<TValue>> dictByFirstKey;
        private Dictionary<TKey2, List<TValue>> dictBySecondKey;
        private Dictionary<Tuple<TKey1, TKey2>, List<TValue>> dictByBothKeys;

        public BiDictionary()
        {
            this.dictByFirstKey = new Dictionary<TKey1, List<TValue>>();
            this.dictBySecondKey = new Dictionary<TKey2, List<TValue>>();
            this.dictByBothKeys = new Dictionary<Tuple<TKey1, TKey2>, List<TValue>>();
        }

        public void Add(TKey1 key1, TKey2 key2, TValue value)
        {
            this.dictByFirstKey.EnsureKeyExists(key1);
            this.dictByFirstKey.AppendValueToKey(key1, value);

            this.dictBySecondKey.EnsureKeyExists(key2);
            this.dictBySecondKey.AppendValueToKey(key2, value);

            var combinedKey = new Tuple<TKey1, TKey2>(key1, key2);
            this.dictByBothKeys.EnsureKeyExists(combinedKey);
            this.dictByBothKeys.AppendValueToKey(combinedKey, value);
        }

        public IEnumerable<TValue> Find(TKey1 key1, TKey2 key2)
        {
            var combinedKey = new Tuple<TKey1, TKey2>(key1, key2);

            if (this.dictByBothKeys.ContainsKey(combinedKey))
            {
                return this.dictByBothKeys[combinedKey];
            }

            return new List<TValue>();
        }

        public IEnumerable<TValue> FindByKey1(TKey1 key1)
        {
            if (this.dictByFirstKey.ContainsKey(key1))
            {
                return this.dictByFirstKey[key1];
            }

            return new List<TValue>();
        }

        public IEnumerable<TValue> FindByKey2(TKey2 key2)
        {
            if (this.dictBySecondKey.ContainsKey(key2))
            {
                return this.dictBySecondKey[key2];
            }

            return new List<TValue>();
        }

        public bool Remove(TKey1 key1, TKey2 key2)
        {
            var combinedKey = new Tuple<TKey1, TKey2>(key1, key2);
            var itemsToRemove = this.Find(key1, key2);

            if (itemsToRemove.Count() != 0)
            {
                foreach (var value in itemsToRemove)
                {
                    this.dictByFirstKey[key1].Remove(value);
                    this.dictBySecondKey[key2].Remove(value);
                }

                this.dictByBothKeys.Remove(combinedKey);
                return true;
            }

            return false;
        }
    }
}
