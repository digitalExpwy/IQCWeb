namespace IQCWeb.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class FirstPieceReports
    {
       
        public int FPR_ID { get; set; }

        public int InspID { get; set; }

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

        
        public string CommentsHoneywell { get; set; }

        
        public string CommentsToPurchasing { get; set; }

       
        public string CommentsToEng { get; set; }

       
        public string CommentsToQC { get; set; }

        public byte? QARequired { get; set; }

        public int? PoMech { get; set; }

        public int? PoElec { get; set; }

        
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


        public Employees Employees { get; set; }
        public RFI RFI { get; set; }
        public DesignSites DesignSites { get; set; }

        public Inspections Inspections { get; set; }
    }

   
}
