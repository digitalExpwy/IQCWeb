namespace IQCWeb.Repository.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DispositionCodes
    {
        [Key]
        public byte DispositionID { get; set; }

        [StringLength(16)]
        public string Disposition { get; set; }
    }
}
