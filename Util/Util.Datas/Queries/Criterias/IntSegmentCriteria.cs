using System;
using System.Linq.Expressions;
using Util.Domains;

namespace Util.Datas.Queries.Criterias
{
    public class IntSegmentCriteria<TEntity, TProperty> : SegmentCriteria<TEntity, TProperty, int>
        where TEntity : class, IAggregateRoot
    {
        public IntSegmentCriteria(Expression<Func<TEntity, TProperty>> propertyExpression, int? min, int? max)
            : base(propertyExpression, min, max)
        {
            
        }

        protected override bool IsMinGreaterThanMax(int? min, int? max)
        {
            return min > max;
        }
    }
}