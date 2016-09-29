namespace IQCWeb.Repository.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DMR_Dispositions
    {
        [Key]
        public int DispID { get; set; }

        public int? InspID { get; set; }

        public byte? Disposition { get; set; }

        public DateTime? DispositionDate { get; set; }

        [StringLength(100)]
        public string Comments { get; set; }
    }
}
