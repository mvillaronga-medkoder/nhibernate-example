using FluentNHibernate.Mapping;

using domain;

namespace maps
{
    public class OrderMap : ClassMap<Order>
    {
        public OrderMap()
        {
            Table("Orders");
            LazyLoad();

            Map(x => x.ReferenceNumber).Column("ReferenceNumber");
            Map(x => x.PaymentType).Column("PaymentType").ReadOnly();

            Id(x => x.Id).Column("OrderId")
                .GeneratedBy.Identity()
                .Unique();

            HasMany(x => x.Items).KeyColumn("OrderId")
                .Inverse()
                .Cascade.AllDeleteOrphan();

            ReferencesAny<IPaymentType>(x => x.Payment)
                .EntityTypeColumn("PaymentType")
                .EntityIdentifierColumn("PaymentId")
                .IdentityType<int>()
                .AddMetaValue<CreditCardPayment>(CreditCardPayment.DiscriminatorDefinition())
                .AddMetaValue<PayPalPayment>(PayPalPayment.DiscriminatorDefinition())
                .Cascade.All();
        }
    }
}
