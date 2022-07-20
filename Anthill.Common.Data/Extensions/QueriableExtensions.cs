using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Anthill.Common.Data.Extensions
{
    public static class QueriableExtensions
    {
        public static async Task<IEnumerable<T>> BatchQueryAsync<T>(this IQueryable<T> query, Int32 batchSize = 25000)
        {
            if (batchSize < 10000)
            {
                //try avoid N+1 queries
                throw new ArgumentException("batchSize should be more than 10000", "batchSize");
            }

            var result = new List<T>();

            var queryCounter = 1;

            var queryResult = await query.OrderByFirstProperty().Take(batchSize).ToListAsync();
            result.AddRange(queryResult);

            while (queryResult.Count == batchSize)
            {
                var tempQuery = query.OrderByFirstProperty().Skip(queryCounter * batchSize).Take(batchSize);
                queryResult = tempQuery.ToList();
                result.AddRange(queryResult);
                Console.WriteLine(queryCounter);
                queryCounter++;
            }

            return result;
        }

        public static IEnumerable<T> BatchQuery<T>(this IQueryable<T> query, Int32 batchSize = 25000)
        {
            if (batchSize < 10000)
            {
                //try avoid N+1 queries
                throw new ArgumentException("batchSize should be more than 10000", "batchSize");
            }

            var result = new List<T>();

            var queryCounter = 1;

            var queryResult = query.OrderByFirstProperty().Take(batchSize).ToList();
            result.AddRange(queryResult);

            while (queryResult.Count == batchSize)
            {
                var tempQuery = query.OrderByFirstProperty().Skip(queryCounter * batchSize).Take(batchSize);
                queryResult = tempQuery.ToList();
                result.AddRange(queryResult);
                Console.WriteLine(queryCounter);
                queryCounter++;
            }

            return result;
        }

        public static IQueryable<T> OrderByFirstProperty<T>(this IQueryable<T> query)
        {
            var type = typeof(T);
            var name = type.GetProperties().First().Name;
            Type selectorResultType;
            var selector = GenerateSelector<T>(name, out selectorResultType);

            MethodCallExpression resultExp = Expression.Call(typeof(Queryable), "OrderBy",
                                           new Type[] { type, selectorResultType },
                                           query.Expression, Expression.Quote(selector));

            return query.Provider.CreateQuery<T>(resultExp);
        }

        private static LambdaExpression GenerateSelector<T>(String propertyName, out Type resultType)
        {
            // Create a parameter to pass into the Lambda expression (Entity => Entity.OrderByField).
            var parameter = Expression.Parameter(typeof(T), "Entity");
            //  create the selector part, but support child properties
            PropertyInfo property;
            Expression propertyAccess;
            if (propertyName.Contains('.'))
            {
                // support to be sorted on child fields.
                var childProperties = propertyName.Split('.');
                property = typeof(T).GetProperty(childProperties[0]);
                propertyAccess = Expression.MakeMemberAccess(parameter, property);
                for (int i = 1; i < childProperties.Length; i++)
                {
                    property = property.PropertyType.GetProperty(childProperties[i]);
                    propertyAccess = Expression.MakeMemberAccess(propertyAccess, property);
                }
            }
            else
            {
                property = typeof(T).GetProperty(propertyName);
                propertyAccess = Expression.MakeMemberAccess(parameter, property);
            }
            resultType = property.PropertyType;
            // Create the order by expression.
            return Expression.Lambda(propertyAccess, parameter);
        }
    }
}
