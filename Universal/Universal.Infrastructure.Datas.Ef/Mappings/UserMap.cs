using Universal.Domains.Models;
using Util.Datas.Ef;

namespace Universal.Infrastructure.Datas.Ef.Mappings
{
    public class UserMap : AggregateMapBase<User, string>
    {
        protected override void MapTable()
        {
            ToTable("Universal", "User");
        }

        protected override void MapProperties()
        {
            base.MapProperties();

            Property(t => t.Name)
                .HasColumnName("Name")
                .HasMaxLength(64);
        }
    }
}