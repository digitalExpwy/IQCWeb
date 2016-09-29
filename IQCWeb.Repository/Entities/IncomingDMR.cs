namespace IQCWeb.Repository.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IncomingDMR")]
    public partial class IncomingDMR
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DMR_ID { get; set; }

       
        public int InspID { get; set; }

        [StringLength(50)]
        public string DMR { get; set; }

        public DateTime? DmrDate { get; set; }

        public int? ApprovedBy { get; set; }

        public DateTime? DispDate { get; set; }

        public int? QtyDefs { get; set; }

        public int? QtyAccepted { get; set; }

        public int? QtyRejected { get; set; }

        public int? Engineering { get; set; }

        public int? MfrEngineering { get; set; }

        public int? ProdControl { get; set; }

        public int? Purchasing { get; set; }

        public int? QAEngineering { get; set; }

        public int? MrbCoordinator { get; set; }

        public bool? Status { get; set; }

        public DateTime? StatusClosedDate { get; set; }

        public DateTime? EmailSent { get; set; }

        public bool? SendDMR { get; set; }

        [StringLength(1000)]
        public string Edistro { get; set; }

        public int? DefNum { get; set; }

        public int? BusGroup { get; set; }

        public bool? Void { get; set; }

        public int? Reason_ID { get; set; }

        [StringLength(50)]
        public string QualityNotification { get; set; }

       
        public virtual Reasons Reasons { get; set; }

        public virtual Inspections Inspections { get; set; }
    }
}
