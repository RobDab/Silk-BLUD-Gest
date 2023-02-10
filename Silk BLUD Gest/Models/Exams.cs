namespace Silk_BLUD_Gest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Exams
    {
        [Key]
        public int ExamsResultsID { get; set; }

        public int DonorID { get; set; }

        [Column(TypeName = "date")]
        public DateTime ExamsDate { get; set; }

        [Required]
        [StringLength(10)]
        public string LMCulture { get; set; }

        public bool HBV { get; set; }

        public bool HCV { get; set; }

        public bool HIV { get; set; }

        public virtual Donors Donors { get; set; }
    }
}
