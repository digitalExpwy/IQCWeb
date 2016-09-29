namespace IQCWeb.Repository.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Mfrs
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MfrId { get; set; }

        [StringLength(50)]
        public string MfrName { get; set; }

        public virtual ICollection<Inspections> Inspections { get; set; }
    }
}
