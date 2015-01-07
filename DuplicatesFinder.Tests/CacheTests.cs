using Xunit;

namespace DuplicatesFinder.Tests
{
    public class CacheTests
    {
        #region Private Fields

        private readonly Cache<string, int> _cache = new Cache<string, int>();
        
        #endregion

        #region Public Methods

        [Fact]
        public void GetOrAdd_Test()
        {
            var value = _cache.GetOrAdd("1", a => 1);

            Assert.Equal(value, 1);
        }

        [Fact]
        public void GetOrAdd_TryAddTwice_Test()
        {
            _cache.GetOrAdd("1", a => 1);
            var value = _cache.GetOrAdd("1", null);

            Assert.Equal(value, 1);
        }

        #endregion
    }
}
