namespace IQCWeb.Repository.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PurchasedParts
    {
        [Key]
        [StringLength(30)]
        public string PartNum { get; set; }

        [StringLength(30)]
        public string Description { get; set; }
    }
}
