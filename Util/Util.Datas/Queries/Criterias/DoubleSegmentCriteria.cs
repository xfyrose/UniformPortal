using System;
using System.Linq.Expressions;
using Util.Domains;

namespace Util.Datas.Queries.Criterias
{
    public class DoubleSegmentCriteria<TEntity, TProperty> : SegmentCriteria<TEntity, TProperty, double>
        where TEntity : class, IAggregateRoot
    {
        public DoubleSegmentCriteria(Expression<Func<TEntity, TProperty>> propertyExpression, double? min, double? max)
            : base(propertyExpression, min, max)
        {
            
        }

        protected override bool IsMinGreaterThanMax(double? min, double? max)
        {
            return min > max;
        }
    }
}