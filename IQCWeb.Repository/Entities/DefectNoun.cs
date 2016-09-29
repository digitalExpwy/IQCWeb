namespace IQCWeb.Repository.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DefectNoun")]
    public partial class DefectNoun
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NounCode { get; set; }

        [StringLength(50)]
        public string Noun { get; set; }
    }
}
