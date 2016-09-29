using IQCWeb.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQCWeb.Repository.Factories
{
    public class InspectionsMasterDataFactory
    {
        public InspectionsMasterDataFactory()
        {

        }

        #region Countries

        public Countries CreateCountry(DTO.Countries country)
        {
            if (country != null)
            {
                return new Countries()
                {
                    CountryID = country.CountryID,
                    Country = country.Country
                };
            }
            else
            {
                return new Countries()
                {
                    CountryID = 0,
                    Country = string.Empty
                };
            }
        }

        public DTO.Countries CreateCountry(Countries country)
        {
            if (country != null)
            {
                return new DTO.Countries()
                {
                    CountryID = country.CountryID,
                    Country = country.Country
                };
            }
            else
            {
                return new DTO.Countries()
                {
                    CountryID = 0,
                    Country = string.Empty
                };

            }
        }

        #endregion


        #region AVM (Vendors)

        public AVM CreateVendor(DTO.AVM vendor)
        {
            if (vendor != null)
            {
                return new AVM()
                {
                    VendorID = vendor.VendorID,
                    VendorName = vendor.VendorName
                };
            }
            else
            {
                return new AVM()
                {
                    VendorID = 0,
                    VendorName = string.Empty
                };
            }
        }

        public DTO.AVM CreateVendor(AVM vendor)
        {
            if (vendor != null)
            {
                return new DTO.AVM()
                {
                    VendorID = vendor.VendorID,
                    VendorName = vendor.VendorName
                };
            }
            else
            {
                return new DTO.AVM()
                {
                    VendorID = 0,
                    VendorName = string.Empty
                };

            }
        }

        #endregion


        #region IIM (Parts)


        public IIM CreatePart(DTO.IIM part)
        {
            if (part != null)
            {
                return new IIM()
                {
                    PartNum = part.PartNum,
                    PartDesc = part.PartDesc
                };
            }
            else
            {
                return new IIM()
                {
                    PartNum = string.Empty,
                    PartDesc = string.Empty
                };
            }
        }

        public DTO.IIM CreatePart(IIM part)
        {
            if (part != null)
            {
                return new DTO.IIM()
                {
                    PartNum = part.PartNum,
                    PartDesc = part.PartDesc
                };
            }
            else
            {
                return new DTO.IIM()
                {
                    PartNum = string.Empty,
                    PartDesc = string.Empty
                };

            }
        }

        #endregion


        #region Employees

        public Employees CreateEmployee(DTO.Employees employee)
        {
            if (employee != null)
            {
                return new Employees()
                {
                   EmployeeCounter = employee.EmployeeCounter,
                   Name = employee.Name                   
                };
            }
            else
            {
                return new Employees()
                {
                    EmployeeCounter = 0,
                    Name = string.Empty
                };
            }
        }

        public DTO.Employees CreateEmployee(Employees employee)
        {
            if (employee != null)
            {
                return new DTO.Employees()
                {
                    EmployeeCounter = employee.EmployeeCounter,
                    Name = employee.Name
                };
            }
            else
            {
                return new DTO.Employees()
                {
                    EmployeeCounter = 0,
                    Name = string.Empty
                };

            }
        }

        #endregion 


        #region Locations


        public Locations CreateLocation(DTO.Locations location)
        {
            if (location != null)
            {
                return new Locations()
                {
                    LocationID = location.LocationID,
                    Location = location.Location
                };
            }
            else
            {
                return new Locations()
                {
                    LocationID = 0,
                    Location = string.Empty
                };
            }
        }

        public DTO.Locations CreateLocation(Locations location)
        {
            if (location != null)
            {
                return new DTO.Locations()
                {
                    LocationID = location.LocationID,
                    Location = location.Location
                };
            }
            else
            {
                return new DTO.Locations()
                {
                    LocationID = 0,
                    Location = string.Empty
                };

            }
        }
#endregion


        #region Molds

        public Molds CreateMold(DTO.Molds mold)
        {
            if (mold != null)
            {
                return new Molds()
                {
                    MoldID = mold.MoldID,
                    InspID = mold.InspID,
                    MoldNum = mold.MoldNum,
                    PartNum = mold.PartNum,
                    NumOfCavities = mold.NumOfCavities,
                    ResinUsed = mold.ResinUsed,
                    MoldRev = mold.MoldRev                    
                };
            }
            else
            {
                return new Molds()
                {
                    MoldID = 0,
                    InspID = 0,
                    MoldNum = string.Empty,
                    PartNum = string.Empty,
                    NumOfCavities = 0,
                    ResinUsed = string.Empty,
                    MoldRev = string.Empty           
                };
            }
        }

        public DTO.Molds CreateMold(Molds mold)
        {
            if (mold != null)
            {
                return new DTO.Molds()
                {
                    MoldID = mold.MoldID,
                    InspID = mold.InspID,
                    MoldNum = mold.MoldNum,
                    PartNum = mold.PartNum,
                    NumOfCavities = mold.NumOfCavities,
                    ResinUsed = mold.ResinUsed,
                    MoldRev = mold.MoldRev
                };
            }
            else
            {
                return new DTO.Molds()
                {
                    MoldID = 0,
                    InspID = 0,
                    MoldNum = string.Empty,
                    PartNum = string.Empty,
                    NumOfCavities = 0,
                    ResinUsed = string.Empty,
                    MoldRev = string.Empty
                };
            }
        }


        #endregion


        #region RFI


        public RFI CreateRFI(DTO.RFI rfi)
        {
            if (rfi != null)
            {
                return new RFI()
                {
                    RFI_ID = rfi.RFI_ID,
                    RFI_Name = rfi.RFI_Name
                };
            }
            else
            {
                return new RFI()
                {
                    RFI_ID = 0,
                    RFI_Name = string.Empty
                };
            }
        }

        public DTO.RFI CreateRFI(RFI rfi)
        {
            if (rfi != null)
            {
                return new DTO.RFI()
                {
                    RFI_ID = rfi.RFI_ID,
                    RFI_Name = rfi.RFI_Name
                };
            }
            else
            {
                return new DTO.RFI()
                {
                    RFI_ID = 0,
                    RFI_Name = string.Empty
                };

            }
        }
        #endregion

        #region DesignSites
        
        public DesignSites CreateDesignSite(DTO.DesignSites designSite)
        {
            if (designSite != null)
            {
                return new DesignSites()
                {
                    DesignSiteID= designSite.DesignSiteID,
                    DesignSite = designSite.DesignSite,
                    Status = designSite.Status
                };
            }
            else
            {
                return new DesignSites()
                {
                    DesignSiteID = 0,
                    DesignSite = string.Empty,
                    Status = string.Empty
                };
            }
        }

        public DTO.DesignSites CreateDesignSite(DesignSites designSite)
        {
            if (designSite != null)
            {
                return new DTO.DesignSites()
                {
                    DesignSiteID = designSite.DesignSiteID,
                    DesignSite = designSite.DesignSite,
                    Status = designSite.Status
                };
            }
            else
            {
                return new DTO.DesignSites()
                {
                    DesignSiteID = 0,
                    DesignSite = string.Empty,
                    Status = string.Empty
                };

            }
        }
        #endregion

        #region Inspections for FPR
        public DTO.Inspections CreateSimpleInspection(Inspections inspection)
        {
            if (inspection == null)
            {
                return EmptyInspection();
            }

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
                RecordDate = inspection.RecordDate,
                Buyer = inspection.Buyer,
                Priority = inspection.Priority,
                MfrPartNum = inspection.MfrPartNum,
                IsSAPVendor = inspection.IsSAPVendor

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

        #endregion

        #region FPR for Inspection

        public DTO.FirstPieceReports CreateFprForInspection(FirstPieceReports Fpr)
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
                ElecRejReason_ID = Fpr.ElecRejReason_ID
            };
        }


        #endregion

        #region Reasons (for DMR)


        public Reasons CreateReason(DTO.Reasons reason)
        {
            if (reason != null)
            {
                return new Reasons()
                {
                    Reason_ID = reason.Reason_ID,
                    ReasonCode = reason.ReasonCode
                };
            }
            else
            {
                return new Reasons()
                {
                    Reason_ID = 0,
                    ReasonCode = string.Empty
                };
            }
        }

        public DTO.Reasons CreateReason(Reasons reason)
        {
            if (reason != null)
            {
                return new DTO.Reasons()
                {
                    Reason_ID = reason.Reason_ID,
                    ReasonCode = reason.ReasonCode
                };
            }
            else
            {
                return new DTO.Reasons()
                {
                    Reason_ID = 0,
                    ReasonCode = string.Empty
                };

            }
        }
        #endregion


    }
}
