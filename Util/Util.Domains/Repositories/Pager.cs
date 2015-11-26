using System;

namespace Util.Domains.Repositories
{
    public class Pager : StateDescription, IPager
    {
        public Pager(int pageNumber, int pageSize = 20, int totalCount = 0, string order = "")
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalCount = totalCount;
            Order = order;
        }

        public Pager(int pageNumber, int pageSize, string order)
            : this(pageNumber, pageSize, 0, order)
        {
        }

        public Pager()
            : this(1)
        {
        }

        private int _pageIndex;

        public int PageNumber
        {
            get
            {
                if (_pageIndex <= 0)
                {
                    _pageIndex = 1;
                }

                return _pageIndex;
            }
            set
            {
                _pageIndex = value;
            }
        }

        public int PageSize { get; set; }
        public int TotalCount { get; set; }

        public int PageCount => (int)Math.Ceiling((decimal)TotalCount / PageSize);

        public int SkipCount
        {
            get
            {
                if (PageNumber > PageCount)
                {
                    PageNumber = PageCount;
                }

                return PageSize * (PageNumber - 1);
            }
        }

        public string Order { get; set; }
        public int FirstLineNumber => (PageNumber - 1) * PageSize + 1;
        public int LastLineNumber => PageNumber * PageSize;

        protected override void AddDescriptions()
        {
            base.AddDescriptions();

            AddDescription(nameof(PageNumber), PageNumber);
            AddDescription(nameof(PageSize), PageSize);
            AddDescription(nameof(TotalCount), TotalCount);
            AddDescription(nameof(Order), Order);
        }
    }
}