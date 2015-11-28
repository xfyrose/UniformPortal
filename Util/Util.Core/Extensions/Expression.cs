using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Util.Core.Lambdas;

namespace Util.Core.Extensions
{
    public static partial class CustomExtensions
    {
        public static MemberExpression MakeMemberAccess(this Expression expression, MemberInfo member)
        {
            return Expression.MakeMemberAccess(expression, member);
        }

        public static BinaryExpression AndAlso(this Expression left, Expression right)
        {
            return Expression.AndAlso(left, right);
        }

        //internal static LambdaExpression Compose<T>(this LambdaExpression first, LambdaExpression second, Func<Expression, Expression, Expression> merge)
        //{
        //    Dictionary<ParameterExpression, ParameterExpression> map = first.Parameters.Select((f, i) => new { f, s = second.Parameters[i] }).ToDictionary(p => p.s, p => p.f);
        //    Expression secondBody = ParameterRebinder.ReplaceParameter(map, second.Body);

        //    return Expression.Lambda<T>(merge(first.Body, second.Body), first.Parameters);
        //}

        internal static Expression<TDelegate> Compose<TDelegate>(this Expression<TDelegate> first, Expression<TDelegate> second, Func<Expression, Expression, Expression> merge)
        {
            Dictionary<ParameterExpression, ParameterExpression> map = first.Parameters.Select((f, i) => new { f, s = second.Parameters[i] }).ToDictionary(p => p.s, p => p.f);
            Expression secondBody = ParameterRebinder.ReplaceParameter(map, second.Body);

            return Expression.Lambda<TDelegate>(merge(first.Body, second.Body), first.Parameters);
        }

        public static Expression<Func<TEntity, bool>> And<TEntity>(this Expression<Func<TEntity, bool>> left, Expression<Func<TEntity, bool>> right)
        {
            if (left == null)
            {
                return right;
            }

            if (right == null)
            {
                return left;
            }

            return left.Compose(right, Expression.AndAlso);
        }

        public static Expression<Func<TEntity, bool>> Or<TEntity>(this Expression<Func<TEntity, bool>> left, Expression<Func<TEntity, bool>> right)
        {
            if (left == null)
            {
                return right;
            }

            if (right == null)
            {
                return left;
            }

            return left.Compose(right, Expression.OrElse);
        }

        public static BinaryExpression Equal(this MemberExpression left, ConstantExpression right)
        {
            return Expression.Equal(left, right);
        }

        public static BinaryExpression Equal(this MemberExpression left, object value)
        {
            return left.Equal(Lambda.Constant(left, value));
        }

        public static BinaryExpression NotEqual(this MemberExpression left, Expression right)
        {
            return Expression.NotEqual(left, right);
        }

        public static BinaryExpression NotEqual(this MemberExpression left, object value)
        {
            return left.NotEqual(Lambda.Constant(left, value));
        }

        public static BinaryExpression GreaterThan(this MemberExpression left, Expression right)
        {
            return Expression.GreaterThan(left, right);
        }

        public static BinaryExpression GreaterThan(this MemberExpression left, object value)
        {
            return left.GreaterThan(Lambda.Constant(left, value));
        }

        public static BinaryExpression GreaterThanOrEqual(this MemberExpression left, Expression right)
        {
            return Expression.GreaterThanOrEqual(left, right);
        }

        public static BinaryExpression GreaterThanOrEqual(this MemberExpression left, object value)
        {
            return left.GreaterThanOrEqual(Lambda.Constant(left, value));
        }

        public static BinaryExpression LessThan(this MemberExpression left, Expression right)
        {
            return Expression.LessThan(left, right);
        }

        public static BinaryExpression LessThan(this MemberExpression left, object value)
        {
            return left.LessThan(Lambda.Constant(left, value));
        }

        public static BinaryExpression LessThanOrEqual(this MemberExpression left, Expression right)
        {
            return Expression.LessThanOrEqual(left, right);
        }

        public static BinaryExpression LessThanOrEqual(this MemberExpression left, object value)
        {
            return left.LessThanOrEqual(Lambda.Constant(left, value));
        }

        public static MethodCallExpression Call(this MemberExpression instance, string methodName, params object[] values)
        {
            if ((values == null) || (values.Length == 0))
            {
                return Expression.Call(instance, instance.Type.GetMethod(methodName));
            }

            return Expression.Call(instance, instance.Type.GetMethod(methodName), values.Select(Expression.Constant));
        }

        public static MethodCallExpression Contains(this MemberExpression left, object value)
        {
            return left.Call("Contains", new[] { typeof(string) }, value);
        }

        public static MethodCallExpression StartsWith(this MemberExpression left, object value)
        {
            return left.Call("StartsWith", new[] { typeof(string) }, value);
        }

        public static MethodCallExpression EndsWith(this MemberExpression left, object value)
        {
            return left.Call("EndsWith", new[] { typeof(string) }, value);
        }

        public static Expression Operation(this MemberExpression left, Operator @operator, object value)
        {
            switch (@operator)
            {
                case Operator.Equal:
                    return left.Equal(value);

                case Operator.NotEqual:
                    return left.NotEqual(value);

                case Operator.GreaterThan:
                    return left.GreaterThan(value);

                case Operator.Less:
                    return left.LessThan(value);

                case Operator.GreaterThanEqual:
                    return left.GreaterThanOrEqual(value);

                case Operator.LessEqual:
                    return left.LessThanOrEqual(value);

                case Operator.Contains:
                    return left.Contains(value);

                case Operator.StartsWith:
                    return left.StartsWith(value);

                case Operator.EndsWith:
                    return left.EndsWith(value);

                default:
                    throw new NotImplementedException();
            }
        }

        public static object Value<T>(this Expression<Func<T, bool>> expression)
        {
            return Lambda.GetValue(expression);
        }

        public static Expression<TDelegate> ToLambda<TDelegate>(this Expression body, params ParameterExpression[] parameters)
        {
            return Expression.Lambda<TDelegate>(body, parameters);
        }
    }
}