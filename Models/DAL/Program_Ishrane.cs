namespace FitnessApp.Models.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Program_Ishrane
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Program_Ishrane()
        {
            Proizvod = new HashSet<Proizvod>();
        }

        [Key]
        public int ProgramIshraneId { get; set; }

        public decimal? CenaPrograma { get; set; }

        [StringLength(1)]
        public string OpisPrograma { get; set; }

        public int? KlijentId { get; set; }

        public virtual Klijent Klijent { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Proizvod> Proizvod { get; set; }
    }
}
