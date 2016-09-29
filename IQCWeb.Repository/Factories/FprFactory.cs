using IQCWeb.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IQCWeb.Repository.Factories
{
    public class FprFactory
    {
        public FprFactory()
        {
        }

        InspectionsMasterDataFactory dataFactory = new InspectionsMasterDataFactory();
        
        public DTO.FirstPieceReports CreateFPR(FirstPieceReports Fpr)
        {
            return new DTO.FirstPieceReports()
            {
               FPR_ID = Fpr.FPR_ID,
               InspID = Fpr.InspID,
               FPR = Fpr.FPR,
               FprDate = Fpr.FprDate,
               RFI_ID = Fpr.RFI_ID,
               AcceptMechEng = Fpr.AcceptMechEng,
               AcceptElectEng = Fpr.AcceptElectEng,
               AcceptQA = Fpr.AcceptQA,
               AuthorizePaymentOfTooling = Fpr.AuthorizePaymentOfTooling,
               AuthorizedMechEng = Fpr.AuthorizedMechEng,
               AuthorizedElecEng = Fpr.AuthorizedElecEng,
               AuthorizedQA = Fpr.AuthorizedQA,
               EPL = Fpr.EPL,
               MechEngDate = Fpr.MechEngDate,
               ElecEngDate = Fpr.ElecEngDate,
               QADate = Fpr.QADate,
               EplDate = Fpr.EplDate,
               CommentsHoneywell = Fpr.CommentsHoneywell,
               CommentsToPurchasing = Fpr.CommentsToPurchasing,
               CommentsToEng = Fpr.CommentsToEng,
               CommentsToQC = Fpr.CommentsToQC,
               QARequired = Fpr.QARequired,
               PoMech = Fpr.PoMech,
               PoElec = Fpr.PoElec,
               RejReason = Fpr.RejReason,
               PartType = Fpr.PartType,
               DesignSiteID = Fpr.DesignSiteID,
               OutToEng = Fpr.OutToEng,
               OutToDate = Fpr.OutToDate,
               OutToEmailDate = Fpr.OutToEmailDate,
               EstCompletionDate = Fpr.EstCompletionDate,
               AuthorizeNewToolTransfer = Fpr.AuthorizeNewToolTransfer,
               MechRejReason_ID = Fpr.MechRejReason_ID,
               ElecRejReason_ID = Fpr.ElecRejReason_ID,
               RFI = dataFactory.CreateRFI(Fpr.RFI),
               DesignSites = dataFactory.CreateDesignSite(Fpr.DesignSites),
               Inspections = dataFactory.CreateSimpleInspection(Fpr.Inspections)
             
            };
        }

        public FirstPieceReports CreateFPR(DTO.FirstPieceReports Fpr)
        {
            return new FirstPieceReports()
            {
                FPR_ID = Fpr.FPR_ID,
                InspID = Fpr.InspID,
                FPR = Fpr.FPR,
                FprDate = Fpr.FprDate,
                RFI_ID = Fpr.RFI_ID,
                AcceptMechEng = Fpr.AcceptMechEng,
                AcceptElectEng = Fpr.AcceptElectEng,
                AcceptQA = Fpr.AcceptQA,
                AuthorizePaymentOfTooling = Fpr.AuthorizePaymentOfTooling,
                AuthorizedMechEng = Fpr.AuthorizedMechEng,
                AuthorizedElecEng = Fpr.AuthorizedElecEng,
                AuthorizedQA = Fpr.AuthorizedQA,
                EPL = Fpr.EPL,
                MechEngDate = Fpr.MechEngDate,
                ElecEngDate = Fpr.ElecEngDate,
                QADate = Fpr.QADate,
                EplDate = Fpr.EplDate,
                CommentsHoneywell = Fpr.CommentsHoneywell,
                CommentsToPurchasing = Fpr.CommentsToPurchasing,
                CommentsToEng = Fpr.CommentsToEng,
                CommentsToQC = Fpr.CommentsToQC,
                QARequired = Fpr.QARequired,
                PoMech = Fpr.PoMech,
                PoElec = Fpr.PoElec,
                RejReason = Fpr.RejReason,
                PartType = Fpr.PartType,
                DesignSiteID = Fpr.DesignSiteID,
                OutToEng = Fpr.OutToEng,
                OutToDate = Fpr.OutToDate,
                OutToEmailDate = Fpr.OutToEmailDate,
                EstCompletionDate = Fpr.EstCompletionDate,
                AuthorizeNewToolTransfer = Fpr.AuthorizeNewToolTransfer,
                MechRejReason_ID = Fpr.MechRejReason_ID,
                ElecRejReason_ID = Fpr.ElecRejReason_ID
               
            };
        }

       


        public object CreateDataShapedObject(FirstPieceReports fpr, List<string> lstOfFields)
        {

            return CreateDataShapedObject(CreateFPR(fpr), lstOfFields);
        }



        public object CreateDataShapedObject(DTO.FirstPieceReports fpr, List<string> lstOfFields)
        {
            if (!lstOfFields.Any())
            {
                return fpr;
            }
            else
            {
                try
                {
                    // create a new ExpandoObject & dynamically create the properties for this object

                    ExpandoObject objectToReturn = new ExpandoObject();
                    foreach (var field in lstOfFields)
                    {
                        // need to include public and instance, b/c specifying a binding flag overwrites the
                        // already-existing binding flags.

                        var fieldValue = fpr.GetType()
                            .GetProperty(field, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance)
                            .GetValue(fpr, null);

                      

                        // add the field to the ExpandoObject
                        ((IDictionary<String, Object>)objectToReturn).Add(field, fieldValue);
                    }

                    return objectToReturn;
                }
                catch (Exception ex)
                {
                    throw new ArgumentException(ex.InnerException.Message);
                }
            }
        }

    }
}
