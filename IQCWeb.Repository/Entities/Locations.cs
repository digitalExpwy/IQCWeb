namespace IQCWeb.Repository.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Locations
    {
        [Key]
        public byte LocationID { get; set; }

        [StringLength(30)]
        public string Location { get; set; }

        public int? Fac { get; set; }

        [StringLength(10)]
        public string Status { get; set; }

        public virtual ICollection<Inspections> Inspections { get; set; }
    }
}
