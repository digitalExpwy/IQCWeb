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
    public class DmrFactory
    {
        public DmrFactory()
        {
        }

        InspectionsMasterDataFactory dataFactory = new InspectionsMasterDataFactory();
        
        public DTO.IncomingDMR CreateDMR(IncomingDMR Dmr)
        {
            return new DTO.IncomingDMR()
            {          
               DMR_ID = Dmr.DMR_ID,
               InspID = Dmr.InspID,
               DMR = Dmr.DMR,
               DmrDate = Dmr.DmrDate,
               ApprovedBy = Dmr.ApprovedBy,
               DispDate = Dmr.DispDate,
               QtyDefs = Dmr.QtyDefs,
               QtyAccepted = Dmr.QtyAccepted,
               QtyRejected = Dmr.QtyRejected,
               Engineering = Dmr.Engineering,
               MfrEngineering = Dmr.MfrEngineering,
               ProdControl = Dmr.ProdControl,
               Purchasing = Dmr.Purchasing,
               QAEngineering = Dmr.QAEngineering,
               MrbCoordinator = Dmr.MrbCoordinator,
               Status = Dmr.Status,
               StatusClosedDate = Dmr.StatusClosedDate,
               EmailSent = Dmr.EmailSent,
               SendDMR = Dmr.SendDMR,
               Edistro = Dmr.Edistro,
               DefNum = Dmr.DefNum,
               BusGroup = Dmr.BusGroup,
               Void = Dmr.Void,
               Reason_ID = Dmr.Reason_ID,
               QualityNotification = Dmr.QualityNotification,
               Reasons = dataFactory.CreateReason(Dmr.Reasons),
               Inspections = dataFactory.CreateSimpleInspection(Dmr.Inspections)             
            };
        }

        public IncomingDMR CreateDMR(DTO.IncomingDMR Dmr)
        {
            return new IncomingDMR()
            {
                DMR_ID = Dmr.DMR_ID,
                InspID = Dmr.InspID,
                DMR = Dmr.DMR,
                DmrDate = Dmr.DmrDate,
                ApprovedBy = Dmr.ApprovedBy,
                DispDate = Dmr.DispDate,
                QtyDefs = Dmr.QtyDefs,
                QtyAccepted = Dmr.QtyAccepted,
                QtyRejected = Dmr.QtyRejected,
                Engineering = Dmr.Engineering,
                MfrEngineering = Dmr.MfrEngineering,
                ProdControl = Dmr.ProdControl,
                Purchasing = Dmr.Purchasing,
                QAEngineering = Dmr.QAEngineering,
                MrbCoordinator = Dmr.MrbCoordinator,
                Status = Dmr.Status,
                StatusClosedDate = Dmr.StatusClosedDate,
                EmailSent = Dmr.EmailSent,
                SendDMR = Dmr.SendDMR,
                Edistro = Dmr.Edistro,
                DefNum = Dmr.DefNum,
                BusGroup = Dmr.BusGroup,
                Void = Dmr.Void,
                Reason_ID = Dmr.Reason_ID,
                QualityNotification = Dmr.QualityNotification
               
            };
        }




        public object CreateDataShapedObject(IncomingDMR dmr, List<string> lstOfFields)
        {

            return CreateDataShapedObject(CreateDMR(dmr), lstOfFields);
        }



        public object CreateDataShapedObject(DTO.IncomingDMR dmr, List<string> lstOfFields)
        {
            if (!lstOfFields.Any())
            {
                return dmr;
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

                        var fieldValue = dmr.GetType()
                            .GetProperty(field, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance)
                            .GetValue(dmr, null);

                      

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
