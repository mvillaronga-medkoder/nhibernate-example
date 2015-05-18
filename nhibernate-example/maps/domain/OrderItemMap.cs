using FluentNHibernate.Mapping;

using domain;

namespace maps.domain
{
    public class OrderItemMap : ClassMap<OrderItem>
    {
        OrderItemMap()
        {
            Table("OrderItem");
            LazyLoad();

            Id(x => x.Id).Column("OrderItemId")
                .GeneratedBy.Identity()
                .Unique();
            References(x => x.Item).Column("ItemId")
                .Cascade.None();
            References(x => x.Order).Column("OrderId")
                .Cascade.None();
            Map(x => x.Quantity).Column("Quantity");
        }

    }
}
