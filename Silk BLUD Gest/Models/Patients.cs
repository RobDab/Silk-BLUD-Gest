namespace Silk_BLUD_Gest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Patients
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Patients()
        {
            Feedings = new HashSet<Feedings>();
        }

        [Key]
        public int PatientID { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        [StringLength(30)]
        public string Lastname { get; set; }

        public int GestationalAge { get; set; }

        public double BirthWeight { get; set; }

        [Column(TypeName = "date")]
        public DateTime NutritionStart { get; set; }

        [Column(TypeName = "date")]
        public DateTime NutritionEnd { get; set; }

        [Column(TypeName = "date")]
        public DateTime? MixedNutritionStart { get; set; }

        public double WeightAtNutritionEnd { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Feedings> Feedings { get; set; }
    }
}
