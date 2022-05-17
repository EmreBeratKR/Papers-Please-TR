using UnityEngine;

namespace Scriptable_Objects
{
    public abstract class Container<T> : ScriptableObject
    {
        [SerializeField] private T[] items;

        
        public T Random => items[UnityEngine.Random.Range(0, items.Length)];
    }
}
