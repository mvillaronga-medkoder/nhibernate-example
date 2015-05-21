using FluentNHibernate.Mapping;

using domain;

namespace maps.domain
{
    public class CreditCardPaymentMap : ClassMap<CreditCardPayment>
    {
        public CreditCardPaymentMap()
        {
            Table("creditcardpayment");
            LazyLoad();

            Id(x => x.Id).Column("CreditCardPaymentId")
                .GeneratedBy.Identity()
                .Unique();

            Map(x => x.CardholderName).Column("CardholderName")
                .Not.Nullable();

            Map(x => x.CardNumber).Column("CardNumber")
                .Not.Nullable()
                .Length(45);
            Map(x => x.CardType).Column("CardType")
                .Not.Nullable();
            Map(x => x.ExpiryDate).Column("ExpiryDate")
                .Not.Nullable();
        }
    
    }
}
