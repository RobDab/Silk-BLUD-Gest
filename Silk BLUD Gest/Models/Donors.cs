namespace Silk_BLUD_Gest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Donors
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Donors()
        {
            Donations = new HashSet<Donations>();
            Exams = new HashSet<Exams>();
            Stock = new HashSet<Stock>();
        }

        [Key]
        public int DonorID { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        [StringLength(30)]
        public string Lastname { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [StringLength(30)]
        public string Contact { get; set; }

        public bool Active { get; set; }

        [Column(TypeName = "date")]
        public DateTime DeliveryDate { get; set; }

        public int GestationWeek { get; set; }

        [Column(TypeName = "date")]
        public DateTime DonorSince { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DonorTo { get; set; }

        public string ClinicalNotes { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BreastPumpProvided { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BreastPumpTaken { get; set; }

        public double TotalDonated { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Donations> Donations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Exams> Exams { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Stock> Stock { get; set; }
    }
}
