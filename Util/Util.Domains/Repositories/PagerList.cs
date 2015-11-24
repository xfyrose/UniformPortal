using System;
using System.Collections.Generic;
using System.Linq;

namespace Util.Domains.Repositories
{
    public class PagerList<T> : List<T>
    {
        public PagerList(int pageNumber, int pageSize, int totalCount, string order)
        {
            Pager pager = new Pager(pageNumber, pageSize, totalCount, order);
            PageNumber = pager.PageNumber;
            PageSize = pager.PageSize;
            TotalCount = pager.TotalCount;
            Order = pager.Order;
            PageCount = pager.PageCount;
        }

        public PagerList(int pageNumber, int pageSize, int totalCount)
            : this(pageNumber, pageSize, totalCount, "")
        {
            
        }

        public PagerList(int totalCount)
            : this(Util.Resources.Consts.PageNumberDefault, Util.Resources.Consts.PageSizeDefault, totalCount)
        {
            
        }

        public PagerList(IPager pager)
            : this(pager.PageNumber, pager.PageSize, pager.TotalCount, pager.Order)
        {
            
        }

        public int PageNumber { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public string Order { get; private set; }
        public int PageCount { get; private set; }

        public PagerList<TResult> Convert<TResult>(Func<T, TResult> converter)
        {
            PagerList<TResult> result = new PagerList<TResult>(PageNumber, PageSize, TotalCount, Order);
            result.AddRange(this.Select(converter));

            return result;
        }
    }
}