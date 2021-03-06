using System;
using System.Collections.Generic;

namespace NarwhalEngine
{
    public class ObjectPoolManager
    {
        private Dictionary<System.Type, AbstractObjectPool> _pools;

        /// <summary>
        /// Creates the Object Pool Manager
        /// </summary>
        public ObjectPoolManager()
        {
            _pools = new Dictionary<System.Type, AbstractObjectPool>();
        }

        /// <summary>
        /// Creates an object pool
        /// </summary>
        /// <typeparam name="T">The type of the pool</typeparam>
        /// <param name="factoryMethod">Factory method to create objects</param>
        /// <param name="turnOnCallback">Callback to turn on the object</param>
        /// <param name="turnOffCallback">Callback to turn off the object</param>
        /// <param name="initialStock">The initial stock that will be created</param>
        /// <param name="isDynamic">If the pool is dynamic</param>
        public void AddObjectPool<T>(Func<T> factoryMethod, Action<T> turnOnCallback, Action<T> turnOffCallback, int initialStock = 0, bool isDynamic = true)
        {
            if (!_pools.ContainsKey(typeof(T)))
                _pools.Add(typeof(T), new ObjectPool<T>(factoryMethod, turnOnCallback, turnOffCallback, initialStock, isDynamic));
        }

        /// <summary>
        /// Creates an object pool
        /// </summary>
        /// <typeparam name="T">The type of the pool</typeparam>
        /// <param name="factoryMethod">Factory method to create objects</param>
        /// <param name="turnOnCallback">Callback to turn on the object</param>
        /// <param name="turnOffCallback">Callback to turn off the object</param>
        /// <param name="initialStock">The initial stock of objects</param>
        /// <param name="isDynamic">If the pool is dynamic</param>
        public void AddObjectPool<T>(Func<T> factoryMethod, Action<T> turnOnCallback, Action<T> turnOffCallback, List<T> initialStock, bool isDynamic = true) where T : AbstractObjectPool, new()
        {
            if (!_pools.ContainsKey(typeof(T)))
                _pools.Add(typeof(T), new ObjectPool<T>(factoryMethod, turnOnCallback, turnOffCallback, initialStock, isDynamic));
        }

        /// <summary>
        /// Adds an existing Object Pool if it doesn't have already one of that type
        /// </summary>
        /// <param name="pool">Pool to be added</param>
        public void AddObjectPool(AbstractObjectPool pool)
        {
            if (!_pools.ContainsKey(pool.GetType()))
                _pools.Add(pool.GetType(), pool);
        }

        /// <summary>
        /// Gets an Object Pool
        /// </summary>
        /// <typeparam name="T">Type of the object pool</typeparam>
        /// <returns>The object pool that contains T type</returns>
        public ObjectPool<T> GetObjectPool<T>()
        {
            return (ObjectPool<T>)_pools[typeof(T)];
        }

        /// <summary>
        /// Gets an object from a pool
        /// </summary>
        /// <typeparam name="T">Type of the object</typeparam>
        /// <returns>The object of T type</returns>
        public T GetObject<T>()
        {
            return ((ObjectPool<T>)_pools[typeof(T)]).GetObject();
        }

        /// <summary>
        /// Returns an object to the pool
        /// </summary>
        /// <typeparam name="T">Type of the object</typeparam>
        /// <param name="o">The object of T type</param>
        public void ReturnObject<T>(T o)
        {
            ((ObjectPool<T>)_pools[typeof(T)]).ReturnObject(o);
        }
    }
}