namespace IQCWeb.Repository.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Reasons
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Reason_ID { get; set; }

        [StringLength(50)]
        public string ReasonCode { get; set; }

        public virtual ICollection<IncomingDMR> IncomingDMR { get; set; }
    }
}
