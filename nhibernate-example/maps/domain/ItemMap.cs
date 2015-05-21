using FluentNHibernate.Mapping;

using domain;

namespace maps.domain
{
    public class ItemMap : ClassMap<Item>
    {
        public ItemMap()
        {
            Table("item");
            LazyLoad();

            Id(x => x.ItemId).Column("ItemId")
                .GeneratedBy.Identity();
            Map(x => x.Name).Column("itemname")
                .Not.Nullable();
            Map(x => x.Price).Column("price")
                .Not.Nullable()
                .Precision(18).Scale(5);
        }
    }
}
