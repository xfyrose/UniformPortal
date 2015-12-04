using System.Collections.Generic;
using System.Linq;
using Util.Core.Extensions;

namespace Util.Datas.Queries.OrderBys
{
    public class OrderByBuilder
    {
        private List<OrderByItem> Items { get; } = new List<OrderByItem>();

        public string Generate()
        {
            return Items.Select(i => i.Generate()).ToList().Splice();
        }

        public void Add(string name, bool desc = false)
        {
            Items.Add(new OrderByItem(name, desc == false ? OrderDirection.Desc : OrderDirection.Asc));
        }

        public void Add(string name, OrderDirection orderDirection)
        {
            Items.Add(new OrderByItem(name, orderDirection));
        }
    }
}