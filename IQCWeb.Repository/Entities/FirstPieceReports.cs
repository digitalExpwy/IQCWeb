namespace IQCWeb.Repository.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FirstPieceReports
    {
      
        [Key]
        public int FPR_ID { get; set; }

        public int InspID { get; set; }

        [Required]
        [StringLength(50)]
        public string FPR { get; set; }

        public DateTime? FprDate { get; set; }

        public int? RFI_ID { get; set; }

        public int? AcceptMechEng { get; set; }

        public int? AcceptElectEng { get; set; }

        public int? AcceptQA { get; set; }

        public bool? AuthorizePaymentOfTooling { get; set; }

        public int? AuthorizedMechEng { get; set; }

        public int? AuthorizedElecEng { get; set; }

        public int? AuthorizedQA { get; set; }

        public int? EPL { get; set; }

        public DateTime? MechEngDate { get; set; }

        public DateTime? ElecEngDate { get; set; }

        public DateTime? QADate { get; set; }

        public DateTime? EplDate { get; set; }

        [StringLength(1000)]
        public string CommentsHoneywell { get; set; }

        [StringLength(1000)]
        public string CommentsToPurchasing { get; set; }

        [StringLength(1000)]
        public string CommentsToEng { get; set; }

        [StringLength(1000)]
        public string CommentsToQC { get; set; }

        public byte? QARequired { get; set; }

        public int? PoMech { get; set; }

        public int? PoElec { get; set; }

        [StringLength(200)]
        public string RejReason { get; set; }

        public byte? PartType { get; set; }

        public byte? DesignSiteID { get; set; }

        public int? OutToEng { get; set; }

        public DateTime? OutToDate { get; set; }

        public DateTime? OutToEmailDate { get; set; }

        public DateTime? EstCompletionDate { get; set; }

        public bool? AuthorizeNewToolTransfer { get; set; }

        public int? MechRejReason_ID { get; set; }

        public int? ElecRejReason_ID { get; set; }


        public virtual RFI RFI { get; set; }
       
        public virtual DesignSites DesignSites { get; set; }
       


        public virtual Inspections Inspections { get; set; }

        
    }
}
