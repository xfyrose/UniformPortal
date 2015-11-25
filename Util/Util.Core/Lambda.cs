using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Util.Core
{
    public class Lambda
    {
        public static MemberInfo GetMember(Expression expression)
        {
            MemberExpression memberExpression = GetMemberExpression(expression);

            return memberExpression?.Member;
        }

        public static MemberExpression GetMemberExpression(Expression expression)
        {
            if (expression == null)
            {
                return null;
            }

            switch (expression.NodeType)
            {
                case ExpressionType.Lambda:
                    return GetMemberExpression(((LambdaExpression)expression).Body);
                case ExpressionType.Convert:
                    return GetMemberExpression(((UnaryExpression)expression).Operand);
                case ExpressionType.MemberAccess:
                    return (MemberExpression)expression;
                default:
                    return null;
            }
        }

        public static ConstantExpression Constant(Expression expression, object value)
        {
            MemberExpression memberExpression = expression as MemberExpression;
            if (memberExpression == null)
            {
                return Expression.Constant(value);
            }

            return Expression.Constant(value, memberExpression.Type);
        }
    }
}