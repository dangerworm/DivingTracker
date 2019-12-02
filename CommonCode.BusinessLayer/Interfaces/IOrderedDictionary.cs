// Taken from an implementation by Matt MC https://stackoverflow.com/users/83144/mattmc3
// Stack Overflow post here: https://stackoverflow.com/questions/2629027/no-generic-implementation-of-ordereddictionary/9844528
// http://unlicense.org

using System.Collections.Generic;
using System.Collections.Specialized;

namespace CommonCode.BusinessLayer.Interfaces
{
    public interface IOrderedDictionary<TKey, TValue>
        : IDictionary<TKey, TValue>, IOrderedDictionary
    {
        new int Count { get; }
        new TValue this[int index] { get; set; }
        new TValue this[TKey key] { get; set; }
        new ICollection<TKey> Keys { get; }
        new ICollection<TValue> Values { get; }
        new void Add(TKey key, TValue value);
        new void Clear();
        new bool ContainsKey(TKey key);
        bool ContainsValue(TValue value);
        bool ContainsValue(TValue value, IEqualityComparer<TValue> comparer);
        new IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator();
        KeyValuePair<TKey, TValue> GetItem(int index);
        TValue GetValue(TKey key);
        int IndexOf(TKey key);
        void Insert(int index, TKey key, TValue value);
        new bool Remove(TKey key);
        new void RemoveAt(int index);
        void SetItem(int index, TValue value);
        void SetValue(TKey key, TValue value);
        new bool TryGetValue(TKey key, out TValue value);
    }
}