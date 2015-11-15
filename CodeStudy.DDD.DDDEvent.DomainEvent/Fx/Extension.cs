using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DomainEvent.Fx
{
    public static class Extension
    {
        #region Check Expression

        /// <summary>
        ///     检查表达式是否为空
        /// </summary>
        /// <param name="argument">    </param>
        /// <param name="argumentName"></param>
        /// <param name="message">     </param>
        public static void CheckNull(this Expression argument, string argumentName, string message = null)
        {
            if (argument != null) return;
            var e = new ArgumentNullException(argumentName, message);
            throw new ArgumentException(string.Format("参数 \"{0}\" 为空表达式引发异常。", argumentName), e);
        }

        #endregion Check Expression

        #region IEnumerable.IsNull or Empty

        /// <summary>
        ///     判断集合是否为空
        /// </summary>
        /// <typeparam name="T"> 动态类型 </typeparam>
        /// <param name="source"> 要处理的集合 </param>
        /// <returns> 为空返回True，不为空返回False </returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
        {
            return source == null || !source.Any();
        }

        #endregion IEnumerable.IsNull or Empty

        #region Check Object

        /// <summary>
        ///     检测空值,为 null 则抛出 ArgumentNullException 异常
        /// </summary>
        /// <param name="argument">     对象 </param>
        /// <param name="argumentName"> 参数名 </param>
        public static void CheckNull(this object argument, string argumentName)
        {
            if (argument != null) return;
            var e = new ArgumentNullException(argumentName);
            throw new ArgumentException(string.Format("参数 \"{0}\" 为空引发异常。", argumentName), e);
        }

        #endregion Check Object

        #region Do(循环执行扩展)

        /// <summary>
        ///     循环执行
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> Do<TSource>(this IEnumerable<TSource> source, Action<TSource> action)
        {
            IEnumerable<TSource> enumerable = source as TSource[] ?? source.ToArray();
            foreach (var x in enumerable) action(x);
            return enumerable;
        }

        #endregion Do(循环执行扩展)

        #region SafeValue(获取安全值)

        /// <summary>
        ///     安全返回值
        /// </summary>
        /// <param name="value"> 可空值 </param>
        public static T SafeValue<T>(this T? value) where T : struct
        {
            return value ?? default(T);
        }

        #endregion SafeValue(获取安全值)

        #region Distinct

        /// <summary>
        ///     根据指定条件返回集合中不重复的元素
        /// </summary>
        /// <typeparam name="T"> 动态类型 </typeparam>
        /// <typeparam name="TKey"> 动态筛选条件类型 </typeparam>
        /// <param name="source">      要操作的源 </param>
        /// <param name="keySelector"> 重复数据筛选条件 </param>
        /// <returns> 不重复元素的集合 </returns>
        public static IEnumerable<T> DistinctBy<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector)
        {
            return source.GroupBy(keySelector).Select(group => group.First());
        }

        #endregion Distinct

        #region Check String

        /// <summary>
        ///     检查字符串是否为 null、String.Empty 或 Blank
        /// </summary>
        /// <param name="argument">    </param>
        /// <param name="argumentName"></param>
        /// <param name="message">     </param>
        public static void CheckNull(this string argument, string argumentName, string message = null)
        {
            if (argument.IsNotNullNorWhiteSpace()) return;
            var e = new ArgumentNullException(argumentName, message);
            throw new ArgumentException(string.Format("参数 \"{0}\" 为空字符串引发异常。", argumentName), e);
        }

        /// <summary>
        /// 检查字符串是否为 String.Empty 或 Blank
        /// </summary>
        /// <param name="argument">    </param>
        /// <param name="argumentName"></param>
        public static void CheckBlank(this string argument, string argumentName)
        {
            IsNotEmpty(argument, argumentName);
        }

        /// <summary>
        ///     检查字符串不是 null、空或由空白字符串组成
        /// </summary>
        /// <param name="string"></param>
        /// <returns></returns>
        public static bool IsNotNullNorWhiteSpace(this string @string)
        {
            return !string.IsNullOrWhiteSpace(@string);
        }

        /// <summary>
        ///     检查字符串是否为 Blank
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        public static void IsNotEmpty(string argument, string argumentName)
        {
            if (!string.IsNullOrEmpty((argument ?? string.Empty).Trim())) return;
            var e = new ArgumentNullException(argumentName);
            throw new ArgumentException(string.Format("参数 \"{0}\" 为 Blank 引发异常。", argumentName), e);
        }

        #endregion Check String
    }
}