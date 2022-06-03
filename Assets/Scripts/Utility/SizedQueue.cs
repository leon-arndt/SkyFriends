using System.Collections.Generic;

namespace Utility
{
    public sealed class SizedQueue<T> : Queue<T>
    {
        public uint FixedCapacity { get; }
        public SizedQueue(uint fixedCapacity)
        {
            FixedCapacity = fixedCapacity;
        }

        /// <summary>
        /// If the total number of item exceed the capacity, the oldest element automatically dequeues.
        /// </summary>
        /// <returns>The dequeued value, if any.</returns>
        public new T Enqueue(T item)
        {
            base.Enqueue(item);
            return Count > FixedCapacity ? Dequeue() : default;
        }
    }
}