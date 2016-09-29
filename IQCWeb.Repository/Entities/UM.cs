namespace IQCWeb.Repository.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UM")]
    public partial class UM
    {
        [Key]
        public int UMnum { get; set; }

        [Column("UM_Name")]
        [StringLength(9)]
        public string UM_Name { get; set; }


       
    }
}
