using System;
using System.Collections.Generic;

namespace DuplicatesFinder
{
    public class Cache<TKey, TValue>
    {
        #region Private Fields

        private Object _object = new Object();
        private Dictionary<TKey, TValue> _cache = new Dictionary<TKey, TValue>();

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
                }
            }

            return value;
        }

        #endregion
    }
}

