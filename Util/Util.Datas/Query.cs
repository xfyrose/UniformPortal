using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Util.Core;
using Util.Datas.Queries;
using Util.Datas.Queries.Criterias;
using Util.Datas.Queries.OrderBys;
using Util.Domains;
using Util.Domains.Repositories;
using Util.Core.Extensions;
using Util.Datas.Extensions;

namespace Util.Datas
{
    public class Query<TEntity, TKey> : Pager, IQuery<TEntity, TKey>
        where TEntity : class, IAggregateRoot<TKey>
    {
        private ICriteria<TEntity> Criteria { get; set; }

        private OrderByBuilder OrderBuilder { get; set; } = new OrderByBuilder();

        public Query(IPager pager)
        {
            PageNumber = pager.PageNumber;
            PageSize = pager.PageSize;
            TotalCount = pager.TotalCount;
            OrderBy(pager.Order);
        }

        public Expression<Func<TEntity, bool>> GetPredicate()
        {
            return Criteria?.GetPredicate();
        }

        public string GetOrderBy()
        {
            Order = OrderBuilder.Generate();
            if (string.IsNullOrWhiteSpace(Order))
            {
                Order = Util.Resources.Consts.OrderById;
            }

            return Order;
        }

        public IQuery<TEntity, TKey> Filter(Expression<Func<TEntity, bool>> predicate, bool isOr = false)
        {
            if (predicate == null)
            {
                return this;
            }

            if (isOr)
            {
                Or(predicate);
            }
            else
            {
                And(predicate);
            }

            return this;
        }

        public IQuery<TEntity, TKey> Or(Expression<Func<TEntity, bool>> predicate)
        {
            if (Criteria == null)
            {
                Criteria = new Criteria<TEntity>(predicate);
                return this;
            }

            Criteria = new OrCriteria<TEntity>(Criteria.GetPredicate(), predicate);
            return this;
        }

        public IQuery<TEntity, TKey> And(Expression<Func<TEntity, bool>> predicate)
        {
            if (Criteria == null)
            {
                Criteria = new Criteria<TEntity>(predicate);
                return this;
            }

            Criteria = new AndCriteria<TEntity>(Criteria.GetPredicate(), predicate);
            return this;
        }

        public IQuery<TEntity, TKey> Filter(string propertyName, object value, Operator @operator = Operator.Equal)
        {
            return Filter(Lambda.ParsePredicate<TEntity>(propertyName, value, @operator));
        }

        public IQuery<TEntity, TKey> Filter(ICriteria<TEntity> criteria)
        {
            And(criteria.GetPredicate());
            return this;
        }

        public IQuery<TEntity, TKey> FilterInt<TProperty>(Expression<Func<TEntity, TProperty>> propertyExpression,
            int? min, int? max)
        {
            return Filter(new IntSegmentCriteria<TEntity, TProperty>(propertyExpression, min, max));
        }

        public IQuery<TEntity, TKey> FilterDouble<TProperty>(Expression<Func<TEntity, TProperty>> propertyExpression,
            double? min, double? max)
        {
            return Filter(new DoubleSegmentCriteria<TEntity, TProperty>(propertyExpression, min, max));
        }

        public IQuery<TEntity, TKey> FilterDecimal<TProperty>(Expression<Func<TEntity, TProperty>> propertyExpression,
            decimal? min, decimal? max)
        {
            return Filter(new DecimalSegmentCriteria<TEntity, TProperty>(propertyExpression, min, max));
        }

        public IQuery<TEntity, TKey> FilterDate<TProperty>(Expression<Func<TEntity, TProperty>> propertyExpression,
            DateTime? min, DateTime? max)
        {
            return Filter(new DateSegmentCriteria<TEntity, TProperty>(propertyExpression, min, max));
        }

        public IQuery<TEntity, TKey> FilterDateTime<TProperty>(Expression<Func<TEntity, TProperty>> propertyExpression,
            DateTime? min, DateTime? max)
        {
            return Filter(new DateTimeSegmentCriteria<TEntity, TProperty>(propertyExpression, min, max));
        }

        public IQuery<TEntity, TKey> And(IQuery<TEntity, TKey> query)
        {
            return And(query.GetPredicate());
        }

        public IQuery<TEntity, TKey> Or(IQuery<TEntity, TKey> query)
        {
            return Or(query.GetPredicate());
        }

        public IQuery<TEntity, TKey> OrderBy<TProperty>(Expression<Func<TEntity, TProperty>> expression,
            bool desc = false)
        {
            return OrderBy(Lambda.GetName(expression), desc);
        }

        public IQuery<TEntity, TKey> OrderBy(string propertyName, bool desc = false)
        {
            OrderBuilder.Add(propertyName, desc);
            GetOrderBy();

            return this;
        }

        public void Clear()
        {
            Criteria = null;
            OrderBuilder = new OrderByBuilder();
        }

        public List<TEntity> GetList(IQueryable<TEntity> queryable)
        {
            return Execute(queryable).OrderBy(Order).ToList();
        }

        private IQueryable<TEntity> Execute(IQueryable<TEntity> queryable)
        {
            queryable.CheckNull(nameof(queryable));
            queryable = FilterBy(queryable);
            GetOrderBy();

            return queryable;
        }

        private IQueryable<TEntity> FilterBy(IQueryable<TEntity> queryable)
        {
            if (Criteria == null)
            {
                return queryable;
            }

            return queryable.Where(Criteria.GetPredicate());
        }

        public PagerList<TEntity> GetPagerList(IQueryable<TEntity> queryable)
        {
            return Execute(queryable).PagerResult(this);
        }
    }

    public class Query<TEntity> : Query<TEntity, Guid>, IQuery<TEntity>
        where TEntity : class, IAggregateRoot<Guid>
    {
        public Query(IPager pager)
            : base(pager)
        {
            
        }
    }
}