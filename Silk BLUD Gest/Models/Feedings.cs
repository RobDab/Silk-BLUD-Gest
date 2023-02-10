namespace Silk_BLUD_Gest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Feedings
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Feedings()
        {
            BottlesInFeedings = new HashSet<BottlesInFeedings>();
        }

        [Key]
        public int FeedingID { get; set; }

        public int PatientID { get; set; }

        [Column(TypeName = "date")]
        public DateTime AdministrationDate { get; set; }

        public int MlDie { get; set; }

        public bool Consent { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BottlesInFeedings> BottlesInFeedings { get; set; }

        public virtual Patients Patients { get; set; }
    }
}
