namespace FitnessApp.Models.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class klijent_trener
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int KlijentId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TrenerId { get; set; }

        [StringLength(255)]
        public string OpisTreninga { get; set; }

        public virtual Klijent Klijent { get; set; }

        public virtual Trener Trener { get; set; }
    }
}
