namespace IQCWeb.Repository.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AVM")]
    public partial class AVM
    {
        [Key]
        public int VendorID { get; set; }

        [StringLength(30)]
        public string VendorName { get; set; }

        public virtual ICollection<Inspections> Inspections { get; set; }
    }
}
