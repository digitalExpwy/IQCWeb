namespace IQCWeb.Repository.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoneywellDefectCodeTranslation")]
    public partial class HoneywellDefectCodeTranslation
    {
        [StringLength(255)]
        public string DefectType { get; set; }

        public double? Summ { get; set; }

        [StringLength(5)]
        public string DefectCode { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short Rank { get; set; }

        public byte? HoneywellDefCode { get; set; }
    }
}
