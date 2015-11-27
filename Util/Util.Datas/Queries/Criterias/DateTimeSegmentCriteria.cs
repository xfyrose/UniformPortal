using System;
using System.Linq.Expressions;
using Util.Domains;

namespace Util.Datas.Queries.Criterias
{
    public class DateTimeSegmentCriteria<TEntity, TProperty> : SegmentCriteria<TEntity, TProperty, DateTime>
        where TEntity : class, IAggregateRoot
    {
        public DateTimeSegmentCriteria(Expression<Func<TEntity, TProperty>> propertyExpression, DateTime? min,
            DateTime? max)
            : base(propertyExpression, min, max)
        {
            
        }

        protected override bool IsMinGreaterThanMax(DateTime? min, DateTime? max)
        {
            return min > max;
        }
    }
}