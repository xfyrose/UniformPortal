using System;
using System.Linq.Expressions;
using Util.Domains;

namespace Util.Datas.Queries.Criterias
{
    public class DecimalSegmentCriteria<TEntity, TProperty> : SegmentCriteria<TEntity, TProperty, decimal>
        where TEntity : class, IAggregateRoot
    {
        public DecimalSegmentCriteria(Expression<Func<TEntity, TProperty>> propertyExpression, decimal? min, decimal? max)
            : base(propertyExpression, min, max)
        {
            
        }

        protected override bool IsMinGreaterThanMax(decimal? min, decimal? max)
        {
            return min > max;
        }
    }
}