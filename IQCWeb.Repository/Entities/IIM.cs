namespace IQCWeb.Repository.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    //[Table("IIM")]
    public partial class IIM
    {
        [Key]
        [StringLength(30)]
        public string PartNum { get; set; }

        [StringLength(30)]
        public string PartDesc { get; set; }

        public virtual ICollection<Inspections> Inspections { get; set; }
    }
}
