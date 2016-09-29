namespace IQCWeb.Repository.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DefectAdjective")]
    public partial class DefectAdjective
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AdjCode { get; set; }

        [StringLength(50)]
        public string Adjective { get; set; }
    }
}
