﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace EnergonSoftware.Generator
{
    public static class RandomExtensions
    {
#region Random Collection Entries
        public static T GetRandomEntry<T>(this Random random, IReadOnlyCollection<T> collection)
        {
            if(collection.Count < 1) {
                return default(T);
            }

            int idx = random.Next(collection.Count);
            return collection.ElementAt(idx);
        }

        public static T RemoveRandomEntry<T>(this Random random, IList<T> collection)
        {
            if(collection.Count < 1) {
                return default(T);
            }

            int idx = random.Next(collection.Count);
            T v = collection.ElementAt(idx);
            collection.RemoveAt(idx);
            return v;
        }
#endregion
    }
}
