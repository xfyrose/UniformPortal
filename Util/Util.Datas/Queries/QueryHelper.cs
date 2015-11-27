using System;
using System.Diagnostics.Contracts;
using System.Linq.Expressions;
using Util.Core;
using Util.Core.Extensions;

namespace Util.Datas.Queries
{
    internal class QueryHelper
    {
        public static Expression<Func<T, bool>> ValidatePredicate<T>(Expression<Func<T, bool>> predicate)
        {
            //Contract.Requires<InvalidOperationException>(predicate != null, "不可为空");
            predicate.CheckNull(nameof(predicate));

            if (Lambda.GetCriteriaCount(predicate) > 1)
            {
                throw new InvalidOperationException($"{Util.Resources.Query.OnlyAllowOneCriteria}: {predicate}");
            }

            var value = predicate.Value();
        }
    }
}