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
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Cognome")]
        public string Lastname { get; set; }

        [Required]
        [Display(Name = "Indirizzo")]
        public string Address { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Telefono")]
        public string Contact { get; set; }

        [Display(Name = "Attiva")]
        public bool Active { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Data parto")]
        public DateTime DeliveryDate { get; set; }

        [Display(Name = "Settimana di gestazione (al parto)")]
        public int GestationWeek { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Data inizio donazione")]
        public DateTime DonorSince { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Data fine donazione donazione")]
        public DateTime? DonorTo { get; set; }

        [Display(Name = "Dati Clinici")]
        public string ClinicalNotes { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Tiralatte fornito in dotazione dal")]
        public DateTime? BreastPumpProvided { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Al")]
        public DateTime? BreastPumpTaken { get; set; }

        [Display(Name = "Totale donato")]
        public double TotalDonated { get; set; }

        //[NotMapped]
        //public bool CollectionConfirmed { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Donations> Donations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Exams> Exams { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Stock> Stock { get; set; }
    }
}
