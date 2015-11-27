using System;
using System.Linq.Expressions;
using Util.Core.Extensions;

namespace Util.Core.Lambdas
{
    public class ExpressionBuilder<TEntity>
    {
        //public ExpressionBuilder()
        //{
        //} 

        private ParameterExpression Parameter { get; } = Expression.Parameter(typeof(TEntity), "t");

        public Expression<Func<TEntity, bool>> Create<TProperty>(Expression<Func<TEntity, TProperty>> property, Operator @operator, object value)
        {
            return Parameter.MakeMemberAccess(Lambda.GetMemberInfo(property)).Operation(@operator, value) as Expression<Func<TEntity, bool>>;
            //return ((MemberExpression)property.Body).Operation(@operator, value);
        }

        public Expression<Func<TEntity, bool>> ToLambda(Expression expression) => expression?.ToLambda<Func<TEntity, bool>>(Parameter);
    }
}