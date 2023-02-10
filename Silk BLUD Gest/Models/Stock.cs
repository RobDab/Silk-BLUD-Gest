namespace Silk_BLUD_Gest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Stock")]
    public partial class Stock
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Stock()
        {
            BottlesInFeedings = new HashSet<BottlesInFeedings>();
        }

        [Key]
        [StringLength(30)]
        public string BottleID { get; set; }

        [Column(TypeName = "date")]
        public DateTime FreezingDate { get; set; }

        public int DonorID { get; set; }

        [StringLength(1)]
        public string Identifier { get; set; }

        [Column(TypeName = "date")]
        public DateTime? PasteurizationDate { get; set; }

        public double? Proteins { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BottlesInFeedings> BottlesInFeedings { get; set; }

        public virtual Donors Donors { get; set; }
    }
}
