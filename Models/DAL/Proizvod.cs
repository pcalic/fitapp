namespace FitnessApp.Models.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Proizvod")]
    public partial class Proizvod
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Proizvod()
        {
            Program_Ishrane = new HashSet<Program_Ishrane>();
        }

        public int ProizvodId { get; set; }

        [StringLength(255)]
        public string Naziv { get; set; }

        public decimal? Cena { get; set; }

        [StringLength(255)]
        public string Opis { get; set; }

        [StringLength(255)]
        public string Vrsta { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Program_Ishrane> Program_Ishrane { get; set; }
    }
}
