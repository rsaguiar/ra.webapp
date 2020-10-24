using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RA.App.ViewModel {
    public class PriceViewModel {
        [DisplayName("Cod.")]
        public int Id { get; set; }
       
        [Required]
        [DisplayName("Origem")]
        public int FromDDDCode { get; set; }

        [Required]
        [DisplayName("Destino")]
        public int ToDDDCode { get; set; }

        [Required]
        [DisplayName("$/Min")]
        public Decimal PricePerMinute { get; set; }
    }
}
