using Util.Core.Lambdas;
using Util.Domains;

namespace Util.Datas.Queries.Criterias
{
    public abstract class SegmentCriteria<TEntity, TProperty, TValue> : Criteria<TEntity>
        where TEntity : class, IAggregateRoot
        where TValue : struct
    {
         Builder = new ExpressionBuilder<TEntity>();
    }
}