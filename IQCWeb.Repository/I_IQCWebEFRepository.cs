using System;
using System.Linq;

namespace IQCWeb.Repository
{
    public interface I_IQCWebEFRepository
    {        
        
        IQCWeb.Repository.Entities.Inspections GetInspection(int inspID);
        IQCWeb.Repository.Entities.Inspections GetInspectionWithProperties(int inspID, string includeProperties); 
       
        
        IQueryable<IQCWeb.Repository.Entities.Inspections> GetInspectionsByPartNum(string partNum);
        IQueryable<IQCWeb.Repository.Entities.Inspections> GetInspectionsCompleted();
        IQueryable<IQCWeb.Repository.Entities.Inspections> GetInspectionsOpenTickets();

        RepositoryActionResult<IQCWeb.Repository.Entities.Inspections> InsertInspection(IQCWeb.Repository.Entities.Inspections e);
        RepositoryActionResult<IQCWeb.Repository.Entities.Inspections> UpdateInspection(IQCWeb.Repository.Entities.Inspections e);
        RepositoryActionResult<IQCWeb.Repository.Entities.Inspections> DeleteInspection(int inspID);

        IQCWeb.Repository.Entities.Countries GetCountry(int id);
        IQueryable<IQCWeb.Repository.Entities.Countries> GetCountries();

        IQueryable<IQCWeb.Repository.Entities.Employees> GetEmployees(string empFunction);
        IQueryable<IQCWeb.Repository.Entities.Employees> GetEmployees();
        IQueryable<IQCWeb.Repository.Entities.Locations> GetLocations();
        IQueryable<IQCWeb.Repository.Entities.IIM> GetParts(string term);
        IQueryable<IQCWeb.Repository.Entities.RFI> GetRFI();
        IQueryable<IQCWeb.Repository.Entities.DesignSites> GetDesignSites();

        //Molds
        IQCWeb.Repository.Entities.Molds GetMold(int MoldID);
        RepositoryActionResult<IQCWeb.Repository.Entities.Molds> InsertMold(IQCWeb.Repository.Entities.Molds e);
        RepositoryActionResult<IQCWeb.Repository.Entities.Molds> UpdateMold(IQCWeb.Repository.Entities.Molds e);
        RepositoryActionResult<IQCWeb.Repository.Entities.Molds> DeleteMold(int inspID);

        //FPRs
        IQCWeb.Repository.Entities.FirstPieceReports GetFPR(int FPR_ID);
        IQCWeb.Repository.Entities.FirstPieceReports GetFprWithProperties(int FPR_ID, string includeProperties);
        IQueryable<IQCWeb.Repository.Entities.FirstPieceReports> GetFprWithProperties(string includeProperties);
        IQueryable<IQCWeb.Repository.Entities.FirstPieceReports> GetFprWithPropertiesByPartNum(string partNum, string includeProperties);

        RepositoryActionResult<IQCWeb.Repository.Entities.FirstPieceReports> InsertFPR(IQCWeb.Repository.Entities.FirstPieceReports e);
        RepositoryActionResult<IQCWeb.Repository.Entities.FirstPieceReports> UpdateFPR(IQCWeb.Repository.Entities.FirstPieceReports e);
        RepositoryActionResult<IQCWeb.Repository.Entities.FirstPieceReports> DeleteFPR(int FPR_ID);

        //DMRs
        IQCWeb.Repository.Entities.IncomingDMR GetDMR(int DMR_ID);
        IQCWeb.Repository.Entities.IncomingDMR GetDmrWithProperties(int DMR_ID, string includeProperties);
        IQueryable<IQCWeb.Repository.Entities.IncomingDMR> GetDmrWithProperties(string includeProperties);
        IQueryable<IQCWeb.Repository.Entities.IncomingDMR> GetDmrWithPropertiesByPartNum(string partNum, string includeProperties);

        RepositoryActionResult<IQCWeb.Repository.Entities.IncomingDMR> InsertDMR(IQCWeb.Repository.Entities.IncomingDMR e);
        RepositoryActionResult<IQCWeb.Repository.Entities.IncomingDMR> UpdateDMR(IQCWeb.Repository.Entities.IncomingDMR e);
        RepositoryActionResult<IQCWeb.Repository.Entities.IncomingDMR> DeleteDMR(int FPR_ID);

        IQueryable<IQCWeb.Repository.Entities.Reasons> GetReasons();

    }
}
