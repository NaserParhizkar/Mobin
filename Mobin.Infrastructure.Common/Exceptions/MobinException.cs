using System;

namespace Mobin.Common
{
    public class MobinException : Exception
    {
        public MobinException() : base() { }

        public MobinException(string message) : base(message) { }

        public MobinException(string message, Exception innerException) : base(message, innerException) { }
    }
}
