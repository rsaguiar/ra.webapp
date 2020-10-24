using System;

namespace RA.App.Domain {
    public class Calculator {
        public int Id { get; set; }
        public int FromDDDCode { get; set; }

        public int ToDDDCode { get; set; }
        public int Time { get; set; }
        public int PlanTypeId { get; set; }
        public Decimal? PriceWithPlan { get; set; }
        public Decimal? PriceWithoutPlan { get; set; }

        public bool IsValid() {
            return FromDDDCode > Decimal.Zero
                && ToDDDCode > Decimal.Zero
                && Time > Decimal.Zero;
        }
    }
}
