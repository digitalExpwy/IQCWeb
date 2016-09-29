namespace IQCWeb.Repository.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NonDimensionalDefects
    {
        [Key]
        public int NonDimDefect_ID { get; set; }

        public int FPR_ID { get; set; }

        public int? Item { get; set; }

        [StringLength(500)]
        public string Defect { get; set; }

        [StringLength(100)]
        public string SeeNote { get; set; }

        public byte? Allow { get; set; }

        public byte? PrevNotedOn { get; set; }
    }
}
