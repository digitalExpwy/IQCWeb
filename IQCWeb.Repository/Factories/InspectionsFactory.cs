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
    public class InspectionsFactory
    {
        public InspectionsFactory()
        {
        }

        InspectionsMasterDataFactory dataFactory = new InspectionsMasterDataFactory();
       
        public DTO.Inspections CreateInspection(Inspections inspection)
        {
            return new DTO.Inspections()
            {
                InspID = inspection.InspID,
                DateInspected = inspection.DateInspected,
                PartNum = inspection.PartNum,
                Revision = inspection.Revision,
                DateCode = inspection.DateCode,
                QtyReceived = inspection.QtyReceived,
                UMnum = inspection.UMnum,
                SampleSize = inspection.SampleSize,
                VendorID = inspection.VendorID,
                MfrId = inspection.MfrId,
                IsSupplier = inspection.IsSupplier,
                CountryID = inspection.CountryID,
                PO = inspection.PO,
                RcvrNum = inspection.RcvrNum,
                RcvrDate = inspection.RcvrDate,
                EmployeeCounter = inspection.EmployeeCounter,
                LocationID = inspection.LocationID,
                QC_In = inspection.QC_In,
                QC_Out = inspection.QC_Out,
                FirstPce = inspection.FirstPce,
                FirstAppr = inspection.FirstAppr,
                PrevInsp = inspection.PrevInsp,
                Comments = inspection.Comments,
                IsInc = inspection.IsInc,
                Accept = inspection.Accept,
                RecordDate  = inspection.RecordDate,
                Buyer = inspection.Buyer,
                Priority = inspection.Priority,
                MfrPartNum = inspection.MfrPartNum,
                IsSAPVendor = inspection.IsSAPVendor,
                Countries = dataFactory.CreateCountry(inspection.Countries),
                AVM = dataFactory.CreateVendor(inspection.AVM),
                IIM = dataFactory.CreatePart(inspection.IIM),
                Employees = dataFactory.CreateEmployee(inspection.Employees), 
                Locations = dataFactory.CreateLocation(inspection.Locations),
                Molds = inspection.Molds.Select(i => dataFactory.CreateMold(i)).ToList(),
                FirstPieceReports = inspection.FirstPieceReports.Select(i => dataFactory.CreateFprForInspection(i)).ToList()                   
            };
        }

        public Inspections CreateInspection(DTO.Inspections inspection)
        {
            return new Inspections()
            {
                InspID = inspection.InspID,
                DateInspected = inspection.DateInspected,
                PartNum = inspection.PartNum,
                Revision = inspection.Revision,
                DateCode = inspection.DateCode,
                QtyReceived = inspection.QtyReceived,
                UMnum = inspection.UMnum,
                SampleSize = inspection.SampleSize,
                VendorID = inspection.VendorID,
                MfrId = inspection.MfrId,
                IsSupplier = inspection.IsSupplier,
                CountryID = inspection.CountryID,
                PO = inspection.PO,
                RcvrNum = inspection.RcvrNum,
                RcvrDate = inspection.RcvrDate,
                EmployeeCounter = inspection.EmployeeCounter,
                LocationID = inspection.LocationID,
                QC_In = inspection.QC_In,
                QC_Out = inspection.QC_Out,
                FirstPce = inspection.FirstPce,
                FirstAppr = inspection.FirstAppr,
                PrevInsp = inspection.PrevInsp,
                Comments = inspection.Comments,
                IsInc = inspection.IsInc,
                Accept = inspection.Accept,
                RecordDate = inspection.RecordDate,
                Buyer = inspection.Buyer,
                Priority = inspection.Priority,
                MfrPartNum = inspection.MfrPartNum,
                IsSAPVendor = inspection.IsSAPVendor

                // Molds = inspection.Molds == null ? new List<Molds>() : inspection.Molds.Select(i => dataFactory.CreateMold(i)).ToList()
            };
        }

        
        
        public DTO.Inspections EmptyInspection()
        {
            return new DTO.Inspections()
            {
                InspID = 0,
                DateInspected = new DateTime(1950, 1, 1),
                PartNum = string.Empty,
                Revision = string.Empty,
                DateCode = string.Empty,
                QtyReceived = 0,
                UMnum = 0,
                SampleSize = 0,
                VendorID = 0,
                MfrId = 0,
                IsSupplier = false,
                CountryID = 0,
                PO = 0,
                RcvrNum = 0,
                RcvrDate = new DateTime(1950, 1, 1),
                EmployeeCounter = 0,
                LocationID = 0,
                QC_In = new DateTime(1950, 1, 1),
                QC_Out = new DateTime(1950, 1, 1),
                FirstPce = false,
                FirstAppr = false,
                PrevInsp = false,
                Comments = string.Empty,
                IsInc = 0,
                Accept = false,
                RecordDate = new DateTime(1950, 1, 1),
                Buyer = string.Empty,
                Priority = string.Empty,
                MfrPartNum = string.Empty,
                IsSAPVendor = false

            };
        }

        public object CreateDataShapedObject(Inspections inspection, List<string> lstOfFields)
        {

            return CreateDataShapedObject(CreateInspection(inspection), lstOfFields);
        }



        public object CreateDataShapedObject(DTO.Inspections inspection, List<string> lstOfFields)
        {

            if (!lstOfFields.Any())
            {
                return inspection;
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

                        var fieldValue = inspection.GetType()
                            .GetProperty(field, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance)
                            .GetValue(inspection, null);

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
