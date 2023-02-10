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

        public int DonorID { get; set; }

        [Column(TypeName = "date")]
        public DateTime FreezingDate { get; set; }

        public int Quantity { get; set; }

        public int BottleNum { get; set; }

        public virtual Donors Donors { get; set; }
    }
}
