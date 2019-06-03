namespace FitnessApp.Models.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Klijent")]
    public partial class Klijent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Klijent()
        {
            Clanska_Karta = new HashSet<Clanska_Karta>();
            Program_Ishrane = new HashSet<Program_Ishrane>();
            klijent_trener = new HashSet<klijent_trener>();
        }

        public int KlijentId { get; set; }

        [StringLength(255)]
        public string Ime { get; set; }

        [StringLength(255)]
        public string Prezime { get; set; }

        [StringLength(1)]
        public string Pol { get; set; }

        [Range(16, 100, ErrorMessage = "Clanovi fitness centra ne mogu biti mladji od 16 godina!")]
        public int? Godine { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Clanska_Karta> Clanska_Karta { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Program_Ishrane> Program_Ishrane { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<klijent_trener> klijent_trener { get; set; }
    }
}
