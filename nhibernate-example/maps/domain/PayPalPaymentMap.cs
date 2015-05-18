using FluentNHibernate.Mapping;

using domain;
namespace maps
{
    public class PayPalPaymentMap : ClassMap<PayPalPayment>
    {
        PayPalPaymentMap()
        {
            Table("PayPalPayment");
            LazyLoad();

            Id(x => x.ID).Column("PayPalPaymentId")
                .GeneratedBy.Identity()
                .Unique();

            Map(x => x.AccountName).Column("AccountName");
        }
    }
}
