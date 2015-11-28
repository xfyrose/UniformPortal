using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Util.Core
{
    public class Lambda
    {
        public static MemberInfo GetMemberInfo(Expression expression)
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

        public static ConstantExpression Constant(MemberExpression expression, object value)
        {
            //MemberExpression memberExpression = expression as MemberExpression;
            //if (memberExpression == null)
            //{
            //    return Expression.Constant(value);
            //}

            //return Expression.Constant(value, memberExpression.Type);
            return Expression.Constant(value, expression.Type);
        }

        public static int GetCriteriaCount(LambdaExpression expression)
        {
            if (expression == null)
            {
                return 0;
            }

            string result = expression.ToString().Replace("AndAlse", "|").Replace("OrElse", "|");
            return result.Split('|').Count();
        }

        public static object GetValue(Expression expression)
        {
            if (expression == null)
            {
                return null;
            }

            switch (expression.NodeType)
            {
                case ExpressionType.Lambda:
                    return GetValue(((LambdaExpression)expression).Body);
                case ExpressionType.Convert:
                    return GetValue(((UnaryExpression)expression).Operand);
                case ExpressionType.Equal:
                case ExpressionType.NotEqual:
                case ExpressionType.GreaterThan:
                case ExpressionType.LessThan:
                case ExpressionType.GreaterThanOrEqual:
                case ExpressionType.LessThanOrEqual:
                    return GetValue(((BinaryExpression)expression).Right);
                case ExpressionType.Call:
                    return GetValue(((MethodCallExpression)expression).Arguments.FirstOrDefault());
                case ExpressionType.MemberAccess:
                    return GetMemberValue((MemberExpression)expression);
                case ExpressionType.Constant:
                    return GetConstantExpressionValue(expression);

                default:
                    return null;
            }
        }

        private static object GetMemberValue(MemberExpression expression)
        {
            if (expression == null)
            {
                return null;
            }

            FieldInfo fieldInfo = expression.Member as FieldInfo;
            if (fieldInfo != null)
            {
                object constValue = GetConstantExpressionValue(expression.Expression);
                return fieldInfo.GetValue(constValue);
            }

            PropertyInfo propertyInfo = expression.Member as PropertyInfo;
            if (propertyInfo == null)
            {
                return null;
            }

            object value = GetMemberValue(expression.Expression as MemberExpression);
            return propertyInfo.GetValue(value);
        }

        private static object GetConstantExpressionValue(Expression expression)
        {
            ConstantExpression constantExpression = (ConstantExpression)expression;
            return constantExpression?.Value;
        }
    }
}