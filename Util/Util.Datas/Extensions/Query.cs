using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Util.Core.Extensions;
using Util.Domains;
using Util.Domains.Repositories;
using Util.Lambdas.Dynamics;

namespace Util.Datas.Extensions
{
    public static class CustomExtensions
    {
        public static IQueryable<T> Filter<T>(this IQueryable<T> source, ICriteria<T> criteria)
            where T : class, IAggregateRoot
        {
            if (criteria == null)
            {
                return source;
            }

            Expression<Func<T, bool>> predicate = criteria.GetPredicate();
            if (predicate == null)
            {
                return source;
            }

            return source.Where(predicate);
        }

        public static IQueryable<T> Filter<T>(this IQueryable<T> source, ICriteria criteria)
            where T : class, IAggregateRoot
        {
            if (criteria == null)
            {
                return source;
            }

            string predicate = criteria.GetPredicate();
            if (predicate.IsEmpty())
            {
                return source;
            }

            return source.Where(predicate, criteria.GetValues());
        }

        public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, string propertyName)
        {
            return source.OrderByDynamic(propertyName);
        }

        public static PagerList<T> PagerResult<T>(this IQueryable<T> queryable, IPager pager)
        {
            return OrderBy(queryable, pager).Pager(pager).ToPagerList(pager);
        }

        private static IQueryable<T> OrderBy<T>(this IQueryable<T> queryable, IPager pager)
        {
            if (pager.Order.IsEmpty())
            {
                return queryable;
            }

            return queryable.OrderBy(pager.Order);
        }

        public static IQueryable<T> Pager<T>(this IQueryable<T> queryable, IPager pager)
        {
            if (pager.TotalCount <= 0)
            {
                pager.TotalCount = queryable.Count();
            }

            return queryable.Skip(pager.SkipCount).Take(pager.PageSize);
        }

        public static PagerList<T> ToPagerList<T>(this IEnumerable<T> source, IPager pager)
        {
            PagerList<T> result = new PagerList<T>(pager);
            result.AddRange(source.ToList());

            return result;
        }
    }
}