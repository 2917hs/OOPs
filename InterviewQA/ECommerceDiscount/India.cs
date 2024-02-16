using System;
namespace InterviewQA.ECommerceDiscount
{
	public class India : Country
    {
		public India()
		{
		}

        public override bool IsOfferApplicable { get; set; }

        public override void ApplyDiscount(decimal price, ref decimal discountedPrice)
        {
            discountedPrice = price * 0.30m;
            discountedPrice = base.CalculateFinalPrice(price, discountedPrice);
        }

        public override Country Clone()
        {
            return (Country)MemberwiseClone();
        }
    }
}

