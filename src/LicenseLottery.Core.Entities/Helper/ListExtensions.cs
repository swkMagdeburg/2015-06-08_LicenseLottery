using System;
using System.Collections.Generic;

namespace LicenseLottery.Core.Entities.Helper
{
    internal static class ListExtensions
    {
        public static void Shuffle<T>(this IList<T> list)
        {
            var random = new Random();
            var n = list.Count;
            while (n > 1)
            {
                n--;
                
                var k = random.Next(n + 1);
                
                var value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static T FetchFirst<T>(this IList<T> list)
        {
            var firstElement = list[0];
            list.Remove(firstElement);
            return firstElement;
        }
    }
}
