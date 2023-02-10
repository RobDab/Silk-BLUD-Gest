namespace Silk_BLUD_Gest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BottlesInFeedings
    {
        public int ID { get; set; }

        public int FeedingID { get; set; }

        [Required]
        [StringLength(30)]
        public string BottleID { get; set; }

        public virtual Feedings Feedings { get; set; }

        public virtual Stock Stock { get; set; }
    }
}
