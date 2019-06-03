namespace FitnessApp.Models.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Clanska_Karta
    {
        [Key]
        public int ClanskaKartaId { get; set; }

        public decimal? Cena { get; set; }

        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? DatumUplate { get; set; }

        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? DatumVazenja { get; set; }

        public int? BrojKarte { get; set; }

        public int? KlijentId { get; set; }

        public virtual Klijent Klijent { get; set; }
    }
}
