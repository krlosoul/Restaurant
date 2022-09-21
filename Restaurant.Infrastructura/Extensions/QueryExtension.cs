namespace Restaurant.Infrastructure.Extensions
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public static class QueryExtension
    {
        /// <summary>
        /// validate if condition exists.
        /// </summary>
        /// <param name="source">The Source.</param>
        /// <param name="condition">The Condition.</param>
        /// <param name="predicate">The Predicate.</param>
        /// <returns>IQueryable&lt;TSource&gt;.</returns>
        public static IQueryable<TSource> WhereIf<TSource>(this IQueryable<TSource> source, bool condition, Expression<Func<TSource, bool>> predicate)
        {
            if (condition)
                return source.Where(predicate);

            return source;
        }

        /// <summary>
        /// Include related entities.
        /// </summary>
        /// <param name="source">The Source.</param>
        /// <param name="includeProperties">The Properties.</param>
        /// <returns>IQueryable&lt;TEntity&gt;.</returns>
        public static IQueryable<TEntity> PerformInclusions<TEntity>(this IQueryable<TEntity> source, IEnumerable<Expression<Func<TEntity, object>>> includeProperties) where TEntity : class
        {
            return includeProperties.Aggregate(source, (current, includeProperties) => current.Include(includeProperties));
        }
    }
}