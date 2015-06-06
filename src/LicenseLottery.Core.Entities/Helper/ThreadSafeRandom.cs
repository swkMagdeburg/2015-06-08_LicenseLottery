using System;
using System.Threading;

namespace LicenseLottery.Core.Entities.Helper
{
    /// <summary>
    /// ThreadSafeRandom found on http://stackoverflow.com/questions/273313/randomize-a-listt-in-c-sharp
    /// </summary>
    public static class ThreadSafeRandom
    {
        [ThreadStatic]
        private static Random _local;

        public static Random ThisThreadsRandom
        {
            get { return _local ?? (_local = new Random(unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId))); }
        }
    }
}
