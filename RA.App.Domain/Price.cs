using System;

namespace RA.App.Domain {
    public class Price {
        public int Id { get; set; }
        public int FromDDDCode { get; set; }

        public int ToDDDCode { get; set; }
        
        public Decimal PricePerMinute { get; set; }

        public bool IsValid() {
            return FromDDDCode > Decimal.Zero
                && ToDDDCode > Decimal.Zero
                && PricePerMinute > Decimal.Zero;
        }
    }
}
