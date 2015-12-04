using System;
using Util.Core.Extensions;
using System.Linq.Expressions;
using Util.Core;
using Util.Core.Lambdas;
using Util.Domains;

namespace Util.Datas.Queries.Criterias
{
    public abstract class SegmentCriteria<TEntity, TProperty, TValue> : CriteriaBase<TEntity>
        where TEntity : class, IAggregateRoot
        where TValue : struct
    {
        protected SegmentCriteria(Expression<Func<TEntity, TProperty>> propertyExpression, TValue? min, TValue? max)
        {
            PropertyExpression = propertyExpression;

            Min = min;
            Max = max;

            //if (IsMinGreaterThanMax(min, max))
            //{
            //    Min = max;
            //    Max = min;
            //}
        }

        private Expression<Func<TEntity, TProperty>> PropertyExpression { get; }
        private TValue? Min { get; set; }
        private TValue? Max { get; set; }
        private ExpressionBuilder<TEntity> Builder { get; set; } = new ExpressionBuilder<TEntity>();

        protected abstract bool IsMinGreaterThanMax(TValue? min, TValue? max);

        public override Expression<Func<TEntity, bool>> GetPredicate()
        {
            Expression first = CreateLeftExpression();
            Expression second = CreateRightExpression();
           
            return Builder.ToLambda(first.AndAlso(second));
        }

        private Expression CreateLeftExpression()
        {
            if (Min == null)
            {
                return null;
            }

            return Builder.Create(PropertyExpression, Operator.GreaterThanEqual, GetMinValue());
        }

        private Expression CreateRightExpression()
        {
            if (Max == null)
            {
                return null;
            }

            return Builder.Create(PropertyExpression, GetMaxOperator(), GetMaxValue());
        }

        protected virtual Operator GetMaxOperator()
        {
            return Operator.LessEqual;
        }

        protected virtual TValue? GetMinValue()
        {
            return Min;
        }

        protected virtual TValue? GetMaxValue()
        {
            return Max;
        }
    }
}