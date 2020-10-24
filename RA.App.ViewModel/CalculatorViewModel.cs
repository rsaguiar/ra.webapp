using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RA.App.ViewModel {
    public enum PlanType {
        [Display(Name = "FaleMais 30")]
        Mais30 = 30,
        [Display(Name = "FaleMais 60")]
        Mais60 = 60,
        [Display(Name = "FaleMais 120")]
        Mais120 = 120
    }

    public class CalculatorViewModel {
        [DisplayName("Cod.")]
        public int Id { get; set; }
        [Required]
        [DisplayName("Origem")]
        public int FromDDDCode { get; set; }
        [Required]
        [DisplayName("Destino")]
        public int ToDDDCode { get; set; }
        [Required]
        [DisplayName("Tempo")]
        public int Time { get; set; }
        [Required] 
        [DisplayName("Plano FaleMais")]
        public int PlanTypeId { get; set; }
        public string PlanName { get; set; }

        [DisplayName("Com FaleMais")]
        [DisplayFormat(NullDisplayText = "-")]
        public Decimal? PriceWithPlan { get; set; }
        [DisplayName("Sem FaleMais")]
        [DisplayFormat(NullDisplayText = "-")]
        public Decimal? PriceWithoutPlan { get; set; }
        public List<CalculatorViewModel> CalculatorHistorical { get; set; }
       
    }

}
