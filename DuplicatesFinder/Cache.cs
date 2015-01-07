using System;
using System.Collections.Generic;

namespace DuplicatesFinder
{
    public class Cache<TKey, TValue>
    {
        #region Private Fields

        private readonly Object _object = new Object();
        private readonly Dictionary<TKey, TValue> _cache = new Dictionary<TKey, TValue>();

        #endregion

        #region Public Methods

        public TValue GetOrAdd(TKey key, Func<TKey, TValue> valueFactory)
        {
            TValue value;

            lock (_object)
            {
                if (!_cache.TryGetValue(key, out value))
                {
                    value = valueFactory(key);
                    _cache.Add(key, value);
                }
            }

            return value;
        }

        #endregion
    }
}

