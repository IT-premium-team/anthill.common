using Anthill.Common.Extensions.Models;
using System;
using System.Collections.Generic;

namespace Anthill.Common.Extensions
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<IEnumerable<S>> Batch<S>(this IEnumerable<S> collection, Int32 batchSize)
        {
            List<S> nextbatch = new List<S>(batchSize);

            foreach (S item in collection)
            {
                nextbatch.Add(item);

                if (nextbatch.Count == batchSize)
                {
                    yield return nextbatch;
                    nextbatch = new List<S>(batchSize);
                }
            }

            if (nextbatch.Count > 0)
            {
                yield return nextbatch;
            }
        }

        public static bool HasDuplicates<T, S>(this IEnumerable<T> source, Func<T, S> selector)
        {
            var d = new HashSet<S>();

            foreach (var t in source)
            {
                if (!d.Add(selector(t)))
                {
                    return true;
                }
            }

            return false;
        }

        public static PagedList<T> ToPagedList<T>(this IEnumerable<T> source, int totalItems, int totalPages, int currentPage)
        {
            return new PagedList<T>(source, totalItems, totalPages, currentPage);
        }
    }
}
