using System;
using System.Linq.Expressions;
using Util.Core.Extensions;

namespace Util.Core.Lambdas
{
    public class ExpressionBuilder<TEntity>
    {
        public ExpressionBuilder()
        {
            Parameter = Expression.Parameter(typeof(TEntity), "t");
        } 

        public ParameterExpression Parameter { get; }

        public Expression Create<T>(Expression<Func<TEntity, T>> property, Operator @operator, object value)
        {
            return Parameter.MakeMemberAccess(Lambda.GetMember(property)).Operation(@operator, value);
            //return (property.Body).Operation(@operator, value);
        }

        //public Expression Create<T>(Expression<Func<TEntity, T>> property, Operator @operator, object value)
        //{
        //    return ((MemberExpression)property.Body).Operation(@operator, value);
        //}

        public Expression<Func<TEntity, bool>> ToLambda(Expression expression) => expression?.ToLambda<Func<TEntity, bool>>(Parameter);
    }
}