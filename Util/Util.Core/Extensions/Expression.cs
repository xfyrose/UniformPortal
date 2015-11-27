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

        public static Expression AndAlso(this Expression left, Expression right)
        {
            return Expression.AndAlso(left, right);
        }

        //internal static LambdaExpression Compose<T>(this LambdaExpression first, LambdaExpression second, Func<Expression, Expression, Expression> merge)
        //{
        //    Dictionary<ParameterExpression, ParameterExpression> map = first.Parameters.Select((f, i) => new { f, s = second.Parameters[i] }).ToDictionary(p => p.s, p => p.f);
        //    Expression secondBody = ParameterRebinder.ReplaceParameter(map, second.Body);

        //    return Expression.Lambda<T>(merge(first.Body, second.Body), first.Parameters);
        //}

        internal static Expression<T> Compose<T>(this Expression<T> first, Expression<T> second, Func<Expression, Expression, Expression> merge)
        {
            Dictionary<ParameterExpression, ParameterExpression> map = first.Parameters.Select((f, i) => new { f, s = second.Parameters[i] }).ToDictionary(p => p.s, p => p.f);
            Expression secondBody = ParameterRebinder.ReplaceParameter(map, second.Body);

            return Expression.Lambda<T>(merge(first.Body, second.Body), first.Parameters);
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
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

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
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

        public static Expression Equal(this Expression left, Expression right)
        {
            return Expression.Equal(left, right);
        }

        public static Expression Equal(this Expression left, object value)
        {
            return left.Equal(Lambda.Constant(left, value));
        }

        public static Expression NotEqual(this Expression left, Expression right)
        {
            return Expression.NotEqual(left, right);
        }

        public static Expression NotEqual(this Expression left, object value)
        {
            return left.NotEqual(Lambda.Constant(left, value));
        }

        public static Expression GreaterThan(this Expression left, Expression right)
        {
            return Expression.GreaterThan(left, right);
        }

        public static Expression GreaterThan(this Expression left, object value)
        {
            return left.GreaterThan(Lambda.Constant(left, value));
        }

        public static Expression GreaterThanOrEqual(this Expression left, Expression right)
        {
            return Expression.GreaterThanOrEqual(left, right);
        }

        public static Expression GreaterThanOrEqual(this Expression left, object value)
        {
            return left.GreaterThanOrEqual(Lambda.Constant(left, value));
        }

        public static Expression LessThan(this Expression left, Expression right)
        {
            return Expression.LessThan(left, right);
        }

        public static Expression LessThan(this Expression left, object value)
        {
            return left.LessThan(Lambda.Constant(left, value));
        }

        public static Expression LessThanOrEqual(this Expression left, Expression right)
        {
            return Expression.LessThanOrEqual(left, right);
        }

        public static Expression LessThanOrEqual(this Expression left, object value)
        {
            return left.LessThanOrEqual(Lambda.Constant(left, value));
        }

        public static Expression Call(this Expression instance, string methodName, params object[] values)
        {
            if ((values == null) || (values.Length == 0))
            {
                return Expression.Call(instance, instance.Type.GetMethod(methodName));
            }

            return Expression.Call(instance, instance.Type.GetMethod(methodName), values.Select(Expression.Constant));
        }

        public static Expression Contains(this Expression left, object value)
        {
            return left.Call("Contains", new[] { typeof(string) }, value);
        }

        public static Expression StartsWith(this Expression left, object value)
        {
            return left.Call("StartsWith", new[] { typeof(string) }, value);
        }

        public static Expression EndsWith(this Expression left, object value)
        {
            return left.Call("EndsWith", new[] { typeof(string) }, value);
        }

        public static Expression Operation(this Expression left, Operator @operator, object value)
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