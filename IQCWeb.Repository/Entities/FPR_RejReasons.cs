namespace IQCWeb.Repository.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FPR_RejReasons
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FprRejReason_ID { get; set; }

        [StringLength(100)]
        public string FprRejReason { get; set; }
    }
}
