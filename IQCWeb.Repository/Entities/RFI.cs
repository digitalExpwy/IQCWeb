namespace IQCWeb.Repository.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RFI")]
    public partial class RFI
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RFI_ID { get; set; }

        [Column("RFI_Name")]
        [StringLength(30)]
        public string RFI_Name { get; set; }

        public virtual ICollection<FirstPieceReports> FirstPieceReports { get; set; }
    }
}
