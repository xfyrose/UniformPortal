namespace Util.Datas.Queries.OrderBys
{
    public class OrderByItem
    {
        public string Name { get; private set; } 
        public OrderDirection Direction { get; private set; }

        public OrderByItem(string name, OrderDirection direction)
        {
            this.Name = name;
            this.Direction = direction;
        }

        public string Generate()
        {
            if (Direction == OrderDirection.Asc)
            {
                return Name;
            }

            return $"{Name} DESC";
        }
    }
}