using System.Collections.Generic;

namespace LicenseLottery.Core.Entities.Helper
{
    internal static class ListExtensions
    {
        /// <summary>
        /// Shuffle found on http://stackoverflow.com/questions/273313/randomize-a-listt-in-c-sharp
        /// </summary>
        public static void Shuffle<T>(this IList<T> list)
        {
            var index = list.Count;
            while (index > 1)
            {
                index--;
                var randomIndex = ThreadSafeRandom.ThisThreadsRandom.Next(index + 1);
                
                var value = list[randomIndex];
                list[randomIndex] = list[index];
                list[index] = value;
            }
        }

        public static T FetchFirstOrDefault<T>(this IList<T> list)
        {
            if (list.Count <= 0)
            {
                return default(T);
            }

            var firstElement = list[0];
            list.Remove(firstElement);
            return firstElement;
        }
    }
}
