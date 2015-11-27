using System;
using System.Linq.Expressions;
using Util.Core;
using Util.Core.Extensions;
using Util.Domains;

namespace Util.Datas.Queries.Criterias
{
    public class DateSegmentCriteria<TEntity, TProperty> : SegmentCriteria<TEntity, TProperty, DateTime>
        where TEntity : class, IAggregateRoot
    {
        public DateSegmentCriteria(Expression<Func<TEntity, TProperty>> propertyExpression, DateTime? min, DateTime? max)
            : base(propertyExpression, min, max)
        {
            
        }

        protected override bool IsMinGreaterThanMax(DateTime? min, DateTime? max)
        {
            return min > max;
        }

        protected override DateTime? GetMinValue()
        {
            return base.GetMinValue().SafeValue().Date;
        }

        protected override DateTime? GetMaxValue()
        {
            return base.GetMaxValue().SafeValue().Date.AddDays(1);
        }

        protected override Operator GetMaxOperator()
        {
            return Operator.Less;
        }
    }
}