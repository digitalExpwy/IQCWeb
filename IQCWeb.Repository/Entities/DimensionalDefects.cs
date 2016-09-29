namespace IQCWeb.Repository.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DimensionalDefects
    {
        [Key]
        public int Defect_ID { get; set; }

        public int FPR_ID { get; set; }

        public int? Item { get; set; }

        [StringLength(255)]
        public string Dimension { get; set; }

        [StringLength(255)]
        public string Measured { get; set; }

        [StringLength(255)]
        public string ViewGridLocation { get; set; }

        public byte? Allow { get; set; }

        public byte? PrevNotedOn { get; set; }
    }
}
