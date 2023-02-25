namespace Silk_BLUD_Gest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Donations
    {
        [Key]
        public int DonationID { get; set; }

        [Display(Name = "Codice donatrice")]
        public int DonorID { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Data di congelamento")]
        public DateTime FreezingDate { get; set; }

        [Display(Name = "Qantità (ml)")]
        public int Quantity { get; set; }

        [Display(Name = "Numero di bottiglie")]
        public int BottleNum { get; set; }

        public virtual Donors Donors { get; set; }
    }
}
