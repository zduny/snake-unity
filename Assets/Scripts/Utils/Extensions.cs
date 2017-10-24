using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public static class Extensions
    {
        /// <summary>
        /// Get random element from list. Throws exception for empty lists.
        /// </summary>
        /// <typeparam name="T">Generic type parameter of list</typeparam>
        /// <param name="list">list you want to get random element from</param>
        /// <returns>random element from list</returns>
        public static T RandomElement<T>(this IList<T> list)
        {
            return list[Random.Range(0, list.Count)];
        }
    }
}
