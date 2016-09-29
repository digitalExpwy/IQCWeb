using IQCWeb.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace IQCWeb.Repository
{
    public class IQCWebRepository: IQCWeb.Repository.I_IQCWebEFRepository
    {
        
        IQCWebData _ctx;


        public IQCWebRepository(IQCWebData ctx)
        {
            _ctx = ctx;
            
            // Disable lazy loading - if not, related properties are auto-loaded when
            // they are accessed for the first time, which means they'll be included when
            // we serialize (b/c the serialization process accesses those properties).  
            // 
            // We don't want that, so we turn it off.  We want to eagerly load them (using Include)
            // manually.

            _ctx.Configuration.LazyLoadingEnabled = false;

        }


        #region Inspections

        public Inspections GetInspection(int inspID)
        {
            try
            {               
                return _ctx.Inspections.FirstOrDefault(e => e.InspID == inspID);
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

       

        public Inspections GetInspectionWithProperties(int inspID, string includeProperties = "")
        {
            DbSet<Inspections> dbSet = null;
            
            IQueryable<Inspections> query = dbSet;
            try
            {
                query = _ctx.Inspections;
            
                foreach (var includeProperty in includeProperties.Split
                    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }

           
                return query.FirstOrDefault(e => e.InspID == inspID);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.InnerException.Message);
            }
           
        }



        public IQueryable<Inspections> GetInspectionsByPartNum(string partNum)
        {
            // if inspections exist, we return the inspections for that part number.
            // if there no inspections, we can return null (commented code), so we can throw a not found exception

            //var correctGroup = _ctx.Inspections.FirstOrDefault(eg => eg.PartNum == partNum);
            //if (correctGroup != null)
            //{
            //    return _ctx.Inspections.Where(e => e.PartNum == partNum);
            //}
            //else
            //{
            //    return null;
            //}

            return _ctx.Inspections.Where(e => e.PartNum == partNum);


        }


        public IQueryable<Inspections> GetInspectionsCompleted()
        {
            
            var result = _ctx.Inspections.Where(eg => eg.DateInspected != null && eg.Accept != null);
            if (result != null)
            {
                return result;
            }
            else
            {
                return null;
            }


        }

        public IQueryable<Inspections> GetInspectionsOpenTickets()
        {
            DateTime defaultDate = DateTime.Parse("01/01/1950");
            
            var result = _ctx.Inspections.Where(eg => eg.QC_Out == null || eg.QC_Out == defaultDate);
            if (result != null)
            {
                return result;
            }
            else
            {
                return null;
            }


        }

       
        

        public RepositoryActionResult<Inspections> InsertInspection(Inspections e)
        {
            try
            {                
                _ctx.Inspections.Add(e);
                var result = _ctx.SaveChanges();
                if (result > 0)
                {
                    return new RepositoryActionResult<Inspections>(e, RepositoryActionStatus.Created);
                }
                else
                {
                    return new RepositoryActionResult<Inspections>(e, RepositoryActionStatus.NothingModified, null);
                }

            }
            catch (Exception ex)
            {
                return new RepositoryActionResult<Inspections>(null, RepositoryActionStatus.Error, ex.InnerException);
            }
        }


        public RepositoryActionResult<Inspections> UpdateInspection(Inspections e)
        {
            try
            {

                // we can only update when inspection already exists for this inspID

                var existingInspection = _ctx.Inspections.FirstOrDefault(exp => exp.InspID == e.InspID);

                if (existingInspection == null)
                {
                    return new RepositoryActionResult<Inspections>(e, RepositoryActionStatus.NotFound);
                }

                // change the original entity status to detached; otherwise, we get an error on attach
                // as the entity is already in the dbSet

                // set original entity state to detached
                _ctx.Entry(existingInspection).State = EntityState.Detached;

                // attach & save
                _ctx.Inspections.Attach(e);

                // set the updated entity state to modified, so it gets updated.
                _ctx.Entry(e).State = EntityState.Modified;


                var result = _ctx.SaveChanges();
                if (result > 0)
                {
                    return new RepositoryActionResult<Inspections>(e, RepositoryActionStatus.Updated);
                }
                else
                {
                    return new RepositoryActionResult<Inspections>(e, RepositoryActionStatus.NothingModified, null);
                }
            }
            catch (Exception ex)
            {
                return new RepositoryActionResult<Inspections>(null, RepositoryActionStatus.Error, ex);
            }

        }

        public RepositoryActionResult<Inspections> DeleteInspection(int inspID)
        {
            try
            {
                var exp = _ctx.Inspections.Where(e => e.InspID == inspID).FirstOrDefault();
                if (exp != null)
                {
                    _ctx.Inspections.Remove(exp);
                    _ctx.SaveChanges();
                    return new RepositoryActionResult<Inspections>(null, RepositoryActionStatus.Deleted);
                }
                return new RepositoryActionResult<Inspections>(null, RepositoryActionStatus.NotFound);
            }
            catch (Exception ex)
            {
                return new RepositoryActionResult<Inspections>(null, RepositoryActionStatus.Error, ex);
            }
        }


        #endregion


        #region Countries

        public Countries GetCountry(int id)
        {
            try
            {
                return _ctx.Countries.FirstOrDefault(egs => egs.CountryID == id);
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public IQueryable<Countries> GetCountries()
        {
            try
            {
                return _ctx.Countries
                    .Where(c => c.CountryID != 0)
                    .OrderBy(c => c.Country);
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }


        #endregion



        #region Employees

        public IQueryable<Employees> GetEmployees(string empFunction)
        {
            try
            {
                
                var result = _ctx.Employees
                                    .Where(e => e.EmpFunction == empFunction && e.Status == "A")
                                    .OrderBy(e => e.Name);             

                if (result != null)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public IQueryable<Employees> GetEmployees()
        {
            try
            {

                var result = _ctx.Employees
                                    .Where(e => e.Status == "A")
                                    .OrderBy(e => e.Name);

                if (result != null)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        #endregion


        #region Locations

        public IQueryable<Locations> GetLocations()
        {
            try
            {
                var result = _ctx.Locations
                                    .Where(e => e.Status == "Active" && e.LocationID > 0)
                                    .OrderBy(e => e.Location);

                if (result != null)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        #endregion


        #region Parts

        public IQueryable<IIM> GetParts(string term)
        {
            try
            {
                var result = _ctx.IIM
                                    .Where(e => e.PartNum.StartsWith(term)).Distinct().Take(10);


                if (result != null)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }


        #endregion


        #region Molds

        public Molds GetMold(int MoldID)
        {
            try
            {
                return _ctx.Molds.FirstOrDefault(e => e.MoldID == MoldID);
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }


        public RepositoryActionResult<Molds> InsertMold(Molds m)
        {
            try
            {
                _ctx.Molds.Add(m);
                var result = _ctx.SaveChanges();
                if (result > 0)
                {
                    return new RepositoryActionResult<Molds>(m, RepositoryActionStatus.Created);
                }
                else
                {
                    return new RepositoryActionResult<Molds>(m, RepositoryActionStatus.NothingModified, null);
                }

            }
            catch (Exception ex)
            {
                return new RepositoryActionResult<Molds>(null, RepositoryActionStatus.Error, ex.InnerException);
            }
        }

        public RepositoryActionResult<Molds> UpdateMold(Molds m)
        {
            try
            {

                // we can only update when mold already exists for this MoldID

                var existingMold = _ctx.Molds.FirstOrDefault(ex => ex.MoldID == m.MoldID);

                if (existingMold == null)
                {
                    return new RepositoryActionResult<Molds>(m, RepositoryActionStatus.NotFound);
                }

                // change the original entity status to detached; otherwise, we get an error on attach
                // as the entity is already in the dbSet

                // set original entity state to detached
                _ctx.Entry(existingMold).State = EntityState.Detached;

                // attach & save
                _ctx.Molds.Attach(m);

                // set the updated entity state to modified, so it gets updated.
                _ctx.Entry(m).State = EntityState.Modified;


                var result = _ctx.SaveChanges();
                if (result > 0)
                {
                    return new RepositoryActionResult<Molds>(m, RepositoryActionStatus.Updated);
                }
                else
                {
                    return new RepositoryActionResult<Molds>(m, RepositoryActionStatus.NothingModified, null);
                }
            }
            catch (Exception ex)
            {
                return new RepositoryActionResult<Molds>(null, RepositoryActionStatus.Error, ex);
            }

        }

        public RepositoryActionResult<Molds> DeleteMold(int MoldID)
        {
            try
            {
                var exp = _ctx.Molds.Where(e => e.MoldID == MoldID).FirstOrDefault();
                if (exp != null)
                {
                    _ctx.Molds.Remove(exp);
                    _ctx.SaveChanges();
                    return new RepositoryActionResult<Molds>(null, RepositoryActionStatus.Deleted);
                }
                return new RepositoryActionResult<Molds>(null, RepositoryActionStatus.NotFound);
            }
            catch (Exception ex)
            {
                return new RepositoryActionResult<Molds>(null, RepositoryActionStatus.Error, ex);
            }
        }



        #endregion


        #region First Piece Reports

        public FirstPieceReports GetFPR(int FPR_ID)
        {
            try
            {
                return _ctx.FirstPieceReports.FirstOrDefault(e => e.FPR_ID == FPR_ID);
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }



        public FirstPieceReports GetFprWithProperties(int FPR_ID, string includeProperties = "")
        {
            DbSet<FirstPieceReports> dbSet = null;

            IQueryable<FirstPieceReports> query = dbSet;
            try
            {
                query = _ctx.FirstPieceReports;

                foreach (var includeProperty in includeProperties.Split
                    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }

                return query.FirstOrDefault(e => e.FPR_ID == FPR_ID);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.InnerException.Message);
            }

        }

        public IQueryable<FirstPieceReports> GetFprWithPropertiesByPartNum(string PartNum, string includeProperties = "")
        {
            DbSet<FirstPieceReports> dbSet = null;

            IQueryable<FirstPieceReports> query = dbSet;
            try
            {
                query = _ctx.FirstPieceReports;

                foreach (var includeProperty in includeProperties.Split
                    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
                
                return query.Where(e => e.Inspections.PartNum == PartNum);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.InnerException.Message);
            }

        }

        public IQueryable<FirstPieceReports> GetFprWithProperties(string includeProperties = "")
        {
            DbSet<FirstPieceReports> dbSet = null;

            IQueryable<FirstPieceReports> query = dbSet;
            try
            {
                query = _ctx.FirstPieceReports;

                foreach (var includeProperty in includeProperties.Split
                    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }

                
                return query.Where(e => e.RFI_ID > 0);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.InnerException.Message);
            }
          

        }



        //public IQueryable<FirstPieceReports> GetFprByPartNum(string partNum)
        //{
            //var query= _ctx.Inspections
            //                    .Join(_ctx.FirstPieceReports,
            //                          i => i.InspID,
            //                          f => f.InspID,
            //                          (i, f) => new { i, f })
            //                    .Where(x => x.i.PartNum == partNum)
            //                    .OrderBy(x => x.f.FPR_ID)
            //                    .Select(x => new { x.f.FPR_ID, x.f.FPR, x.f.FprDate, x.f.RFI_ID, x.f.DesignSiteID});

            //var fpr = new List<FirstPieceReports>();
            
            //foreach(var t in query)
            //{
            //    fpr.Add(new FirstPieceReports()
            //    {

            //    });

            //}

          
            
            //return fpr;


        //}


        public RepositoryActionResult<FirstPieceReports> InsertFPR(FirstPieceReports e)
        {
            try
            {
                _ctx.FirstPieceReports.Add(e);
                var result = _ctx.SaveChanges();
                if (result > 0)
                {
                    return new RepositoryActionResult<FirstPieceReports>(e, RepositoryActionStatus.Created);
                }
                else
                {
                    return new RepositoryActionResult<FirstPieceReports>(e, RepositoryActionStatus.NothingModified, null);
                }

            }
            catch (Exception ex)
            {
                return new RepositoryActionResult<FirstPieceReports>(null, RepositoryActionStatus.Error, ex.InnerException);
            }
        }


        public RepositoryActionResult<FirstPieceReports> UpdateFPR(FirstPieceReports e)
        {
            try
            {

                // we can only update when FPR already exists for this FPR_ID

                var existingFpr = _ctx.FirstPieceReports.FirstOrDefault(f => f.FPR_ID == e.FPR_ID);

                if (existingFpr == null)
                {
                    return new RepositoryActionResult<FirstPieceReports>(e, RepositoryActionStatus.NotFound);
                }

                // change the original entity status to detached; otherwise, we get an error on attach
                // as the entity is already in the dbSet

                // set original entity state to detached
                _ctx.Entry(existingFpr).State = EntityState.Detached;

                // attach & save
                _ctx.FirstPieceReports.Attach(e);

                // set the updated entity state to modified, so it gets updated.
                _ctx.Entry(e).State = EntityState.Modified;


                var result = _ctx.SaveChanges();
                if (result > 0)
                {
                    return new RepositoryActionResult<FirstPieceReports>(e, RepositoryActionStatus.Updated);
                }
                else
                {
                    return new RepositoryActionResult<FirstPieceReports>(e, RepositoryActionStatus.NothingModified, null);
                }
            }
            catch (Exception ex)
            {
                return new RepositoryActionResult<FirstPieceReports>(null, RepositoryActionStatus.Error, ex);
            }

        }

        public RepositoryActionResult<FirstPieceReports> DeleteFPR(int FPR_ID)
        {
            try
            {
                var fpr = _ctx.FirstPieceReports.Where(e => e.FPR_ID == FPR_ID).FirstOrDefault();
                if (fpr != null)
                {
                    _ctx.FirstPieceReports.Remove(fpr);
                    _ctx.SaveChanges();
                    return new RepositoryActionResult<FirstPieceReports>(null, RepositoryActionStatus.Deleted);
                }
                return new RepositoryActionResult<FirstPieceReports>(null, RepositoryActionStatus.NotFound);
            }
            catch (Exception ex)
            {
                return new RepositoryActionResult<FirstPieceReports>(null, RepositoryActionStatus.Error, ex);
            }
        }


        #endregion


        #region RFI

        public IQueryable<RFI> GetRFI()
        {
            try
            {
                var result = _ctx.RFI.OrderBy(e => e.RFI_Name);

                if (result != null)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        #endregion


        #region DesignSites

        public IQueryable<DesignSites> GetDesignSites()
        {
            try
            {
                var result = _ctx.DesignSites.OrderBy(e => e.DesignSite);

                if (result != null)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        #endregion



        #region DMRs

        public IncomingDMR GetDMR(int DMR_ID)
        {
            try
            {
                return _ctx.IncomingDMR.FirstOrDefault(e => e.DMR_ID == DMR_ID);
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }



        public IncomingDMR GetDmrWithProperties(int DMR_ID, string includeProperties = "")
        {
            DbSet<IncomingDMR> dbSet = null;

            IQueryable<IncomingDMR> query = dbSet;
            try
            {
                query = _ctx.IncomingDMR;

                foreach (var includeProperty in includeProperties.Split
                    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }

                return query.FirstOrDefault(e => e.DMR_ID == DMR_ID);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.InnerException.Message);
            }

        }

        public IQueryable<IncomingDMR> GetDmrWithPropertiesByPartNum(string PartNum, string includeProperties = "")
        {
            DbSet<IncomingDMR> dbSet = null;

            IQueryable<IncomingDMR> query = dbSet;
            try
            {
                query = _ctx.IncomingDMR;

                foreach (var includeProperty in includeProperties.Split
                    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }

                return query.Where(e => e.Inspections.PartNum == PartNum);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.InnerException.Message);
            }

        }

        public IQueryable<IncomingDMR> GetDmrWithProperties(string includeProperties = "")
        {
            DbSet<IncomingDMR> dbSet = null;

            IQueryable<IncomingDMR> query = dbSet;
            try
            {
                query = _ctx.IncomingDMR;

                foreach (var includeProperty in includeProperties.Split
                    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }

                return query.Where(e => e.QtyAccepted != null);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.InnerException.Message);
            }


        }




        public RepositoryActionResult<IncomingDMR> InsertDMR(IncomingDMR e)
        {
            try
            {
                var existingMaxDmr = _ctx.IncomingDMR.LastOrDefault(d => d.DMR.StartsWith("JZ"));
                string dmrName = existingMaxDmr.DMR.ToString();
                int dmrNum = Int32.Parse(dmrName.Substring(2));
                dmrNum += 1;
                e.DMR = "JZ" + dmrNum.ToString();

                _ctx.IncomingDMR.Add(e);
                var result = _ctx.SaveChanges();
                if (result > 0)
                {
                    return new RepositoryActionResult<IncomingDMR>(e, RepositoryActionStatus.Created);
                }
                else
                {
                    return new RepositoryActionResult<IncomingDMR>(e, RepositoryActionStatus.NothingModified, null);
                }
            }
            catch (Exception ex)
            {
                return new RepositoryActionResult<IncomingDMR>(null, RepositoryActionStatus.Error, ex.InnerException);
            }
        }


        public RepositoryActionResult<IncomingDMR> UpdateDMR(IncomingDMR e)
        {
            try
            {
                // we can only update when DMR already exists for this DMR_ID

                var existingDmr = _ctx.IncomingDMR.FirstOrDefault(f => f.DMR_ID == e.DMR_ID);


                if (existingDmr == null)
                {
                    return new RepositoryActionResult<IncomingDMR>(e, RepositoryActionStatus.NotFound);
                }

                e.DMR = existingDmr.DMR;
                e.SendDMR = existingDmr.SendDMR;
                e.Status = existingDmr.Status;
                e.StatusClosedDate = existingDmr.StatusClosedDate;
                e.Void = existingDmr.Void;
                e.QtyAccepted = existingDmr.QtyAccepted;
                e.EmailSent = existingDmr.EmailSent;
                e.DefNum = existingDmr.DefNum;
                e.BusGroup = existingDmr.BusGroup;

                // change the original entity status to detached; otherwise, we get an error on attach
                // as the entity is already in the dbSet

                // set original entity state to detached
                _ctx.Entry(existingDmr).State = EntityState.Detached;

                // attach & save
                _ctx.IncomingDMR.Attach(e);

                // set the updated entity state to modified, so it gets updated.
                _ctx.Entry(e).State = EntityState.Modified;


                var result = _ctx.SaveChanges();
                if (result > 0)
                {
                    return new RepositoryActionResult<IncomingDMR>(e, RepositoryActionStatus.Updated);
                }
                else
                {
                    return new RepositoryActionResult<IncomingDMR>(e, RepositoryActionStatus.NothingModified, null);
                }
            }
            catch (Exception ex)
            {
                return new RepositoryActionResult<IncomingDMR>(null, RepositoryActionStatus.Error, ex);
            }

        }

        public RepositoryActionResult<IncomingDMR> DeleteDMR(int DMR_ID)
        {
            try
            {
                var dmr = _ctx.IncomingDMR.Where(e => e.DMR_ID == DMR_ID).FirstOrDefault();
                if (dmr != null)
                {
                    _ctx.IncomingDMR.Remove(dmr);
                    _ctx.SaveChanges();
                    return new RepositoryActionResult<IncomingDMR>(null, RepositoryActionStatus.Deleted);
                }
                return new RepositoryActionResult<IncomingDMR>(null, RepositoryActionStatus.NotFound);
            }
            catch (Exception ex)
            {
                return new RepositoryActionResult<IncomingDMR>(null, RepositoryActionStatus.Error, ex);
            }
        }


        #endregion


        #region Reasons (for DMR)

        public IQueryable<Reasons> GetReasons()
        {
            try
            {
                var result = _ctx.Reasons.OrderBy(e => e.ReasonCode);

                if (result != null)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        #endregion







      



    }
}
