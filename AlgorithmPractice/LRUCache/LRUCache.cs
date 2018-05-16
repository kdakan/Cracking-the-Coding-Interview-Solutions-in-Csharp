using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmPractice
{
    public class LRUCache<K, V>
    {
        private int maxCacheSize = 5;
        private LRUCacheNode<K, V> listHead;
        private LRUCacheNode<K, V> listTail;
        private Dictionary<K, LRUCacheNode<K, V>> dict = new Dictionary<K, LRUCacheNode<K, V>>();

        public LRUCache(int maxCacheSize)
        {
            if (maxCacheSize < 1)
                throw new ArgumentException("maxCacheSize cannot be lwss than 1");

            this.maxCacheSize = maxCacheSize;
        }

        public void Put(K key, V value)
        {
            //if key exists in cache, just update the value
            //if key does not exist in cache, 
            //  check cache size, if current size is at its max, remove least recently used item (at head of list)
            //  add new item to head of list

            if (dict.ContainsKey(key))
            {
                dict[key].Value = value;
                return;
            }

            //if currentCacheSize == maxCacheSize then remove head element from list and dict
            if (dict.Keys.Count == maxCacheSize)
            {
                dict.Remove(listHead.Key);
                removeFromList(listHead);
            }

            //insert element to hashset and head of list
            var newNode = new LRUCacheNode<K, V>(key, value, listHead, null);
            dict.Add(key, newNode);
            if (listHead != null)
                listHead.Previous = newNode;

            listHead = newNode;

            if (listTail == null)
                listTail = newNode;
        }

        public V Get(K key)
        {
            //lru items are located near the head, when an item is used(get) it is moved to tail
            //if key exists, move element to end of list and return value

            if (!dict.ContainsKey(key))
                throw new Exception("Key not found");

            var existingNode = dict[key];

            //if there is only one item just return it
            if (listHead.Next == null)
                return existingNode.Value;

            ////if item is already on the tail, just return it
            //if (existingNode.Next == null)
            //    return existingNode.Value;

            removeFromList(existingNode);

            //add item to tail
            listTail.Next = existingNode;
            existingNode.Previous = listTail;
            listTail = existingNode;

            return existingNode.Value;
 
        }

        private void removeFromList(LRUCacheNode<K, V> node)
        {
            if (listHead == node)
            {
                listHead = node.Next;
                listHead.Previous = null;
                if (listHead == null)
                    listTail = null;
            }
            else
            {
                node.Previous.Next = node.Next;

            }
        }

        public void Remove(K key)
        {
            //if dict has key then remove element from list

            if (!dict.ContainsKey(key))
                throw new Exception("Key not found");

            var existingNode = dict[key];
            removeFromList(existingNode);

            dict.Remove(key);
        }
    }

    public class LRUCacheNode<K, V>
    {
        public K Key { get; set; }
        public V Value { get; set; }
        public LRUCacheNode<K, V> Next { get; set; }
        public LRUCacheNode<K, V> Previous { get; set; }

        public LRUCacheNode(K key, V value, LRUCacheNode<K, V> next, LRUCacheNode<K, V> previous)
        {
            Key = key;
            Value = value;
            Next = next;
            Previous = previous;
        }
    }
}
