namespace FitnessApp.Models.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Trener")]
    public partial class Trener
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Trener()
        {
            klijent_trener = new HashSet<klijent_trener>();
        }

        public int TrenerId { get; set; }

        [StringLength(255)]
        public string Ime { get; set; }

        [StringLength(255)]
        public string Prezime { get; set; }

        [StringLength(1)]
        public string Pol { get; set; }

        [Range(18, 100, ErrorMessage = "Treneri fitness centra ne mogu biti mladji od 18 godina!")]
        public int? Godine { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<klijent_trener> klijent_trener { get; set; }
    }
}
