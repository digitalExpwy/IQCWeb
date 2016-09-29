using IQCWeb.Repository;
using IQCWeb.Repository.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IQCWeb.API.Helpers;
using System.Web.Http.Routing;
using System.Web;

namespace IQCWeb.API.Controllers
{
    public class InspectionsController : ApiController
    {
            
        I_IQCWebEFRepository _repository;
        InspectionsFactory _inspectionsFactory = new InspectionsFactory();

        const int maxPageSize = 10;

        public InspectionsController()
        {
            _repository = new IQCWebRepository(new Repository.Entities.IQCWebData());
        }

        public InspectionsController(I_IQCWebEFRepository repository)
        {
            _repository = repository;
        }

        
        public IHttpActionResult Get(int id, string fields = "")
        {
            try 
            {
                Repository.Entities.Inspections inspection;
                if (fields.Length > 0)
                {
                   inspection = _repository.GetInspectionWithProperties(id, fields);
                }
                else
                {
                    inspection = _repository.GetInspection(id);
                }

                
                if (inspection != null)
                {
                    var returnValue = _inspectionsFactory.CreateInspection(inspection);
                    
                    return Ok(returnValue);
                }
                else
                {
                    return NotFound();
                }

            }
            catch(Exception)
            {
                return InternalServerError();
            }

        }


        [Route("api/inspections", Name = "PartsInspectionsList")]
        public IHttpActionResult Get(string partNum, string sort = "InspID", string locationID = null, string fields = null, int page = 1, int pageSize = 10)
        {
            try
            {                

                List<string> lstOfFields = new List<string>();

                if (fields != null)
                {
                    lstOfFields = fields.ToLower().Split(',').ToList();
                }

                int locId = -1;
                if (locationID != null)
                {
                    locId = int.Parse(locationID);
                }

                var inspections = _repository.GetInspectionsByPartNum(partNum);

                if (inspections != null)
                {
                    // ensure the page size isn't larger than the maximum.
                    if (pageSize > maxPageSize)
                    {
                        pageSize = maxPageSize;
                    }

                    var totalCount = inspections.Count();
                    var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

                    var urlHelper = new UrlHelper(Request);
                    var prevLink = page > 1 ? urlHelper.Link("PartsInspectionsList",
                        new
                        {
                            page = page - 1,
                            pageSize = pageSize,
                            sort = sort,
                            fields = fields,
                            locationID = locationID
                        }) : "";
                    var nextLink = page < totalPages ? urlHelper.Link("PartsInspectionsList",
                        new
                        {
                            page = page + 1,
                            pageSize = pageSize,
                            sort = sort,
                            fields = fields,
                            locationID = locationID
                        }) : "";


                    var paginationHeader = new
                    {
                        currentPage = page,
                        pageSize = pageSize,
                        totalCount = totalCount,
                        totalPages = totalPages,
                        previousPageLink = prevLink,
                        nextPageLink = nextLink
                    };

                    HttpContext.Current.Response.Headers.Add("X-Pagination",
                        Newtonsoft.Json.JsonConvert.SerializeObject(paginationHeader));


                   return Ok(inspections
                       .ApplySort(sort)
                       .Where(eg => (locId == -1 || eg.LocationID == locId))
                       .ToList()
                       .Select(eg => _inspectionsFactory.CreateInspection(eg)));
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception)
            {
                return InternalServerError();
            }

        }

        [Route("api/inspections", Name = "InspectionsList")]
        public IHttpActionResult Get(string sort = "QC_In", string locationID = null, string fields = null, int page = 1, int pageSize = 10)
        {
            try
            {

                
                List<string> lstOfFields = new List<string>();

                if (fields != null)
                {
                    lstOfFields = fields.ToLower().Split(',').ToList();
                    
                }

                int locId = -1;
                if (locationID != null)
                {
                    locId = int.Parse(locationID);
                }
                IQueryable<Repository.Entities.Inspections> inspections = null;
                
                inspections = _repository.GetInspectionsCompleted()
                        .ApplySort(sort)
                        .Where(eg => (locId == -1 || eg.LocationID == locId));
                


                if (inspections == null)
                {
                    return NotFound();
                }

                // ensure the page size isn't larger than the maximum.
                if (pageSize > maxPageSize)
                {
                    pageSize = maxPageSize;
                }

                var totalCount = inspections.Count();
                var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

                var urlHelper = new UrlHelper(Request);
                var prevLink = page > 1 ? urlHelper.Link("InspectionsList",
                    new
                    {
                        page = page - 1,
                        pageSize = pageSize,
                        sort = sort,
                        fields = fields,  
                        locationID = locationID
                    }) : "";
                var nextLink = page < totalPages ? urlHelper.Link("InspectionsList",
                    new
                    {
                        page = page + 1,
                        pageSize = pageSize,
                        sort = sort,
                        fields = fields,
                        locationID = locationID
                    }) : "";


                var paginationHeader = new
                {
                    currentPage = page,
                    pageSize = pageSize,
                    totalCount = totalCount,
                    totalPages = totalPages,
                    previousPageLink = prevLink,
                    nextPageLink = nextLink
                };

                HttpContext.Current.Response.Headers.Add("X-Pagination",
                    Newtonsoft.Json.JsonConvert.SerializeObject(paginationHeader));

              
                return Ok(inspections
                     .Skip(pageSize * (page - 1))
                     .Take(pageSize)
                     .ToList()
                     .Select(eg => _inspectionsFactory.CreateDataShapedObject(eg, lstOfFields)));
             

            }
            catch (Exception ex)
            {
                //return InternalServerError();
                throw ex.InnerException;

            }

        }




        [Route("api/inspections")]
        [HttpPost]
        public IHttpActionResult Post([FromBody]DTO.Inspections inspection)
        {
            try
            {
                if (inspection == null)
                {
                    return BadRequest();
                }

                // map
                var insp = _inspectionsFactory.CreateInspection(inspection);

                var result = _repository.InsertInspection(insp);
                if (result.Status == RepositoryActionStatus.Created)
                {
                    // map to dto
                    var newInsp = _inspectionsFactory.CreateInspection(result.Entity);
                    return Created<DTO.Inspections>(Request.RequestUri + "/" + newInsp.InspID.ToString(), newInsp);
                }

                return BadRequest();

            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }



        public IHttpActionResult Put(int id, [FromBody]DTO.Inspections inspection)
        {
            try
            {
                if (inspection == null)
                {
                    return BadRequest();
                }

                // map
                var insp = _inspectionsFactory.CreateInspection(inspection);

                var result = _repository.UpdateInspection(insp);
                if (result.Status == RepositoryActionStatus.Updated)
                {
                    // map to dto
                    var updatedInspection = _inspectionsFactory.CreateInspection(result.Entity);
                    return Ok(updatedInspection);
                }
                else if (result.Status == RepositoryActionStatus.NotFound)
                {
                    return NotFound();
                }

                return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }


        public IHttpActionResult Delete(int id)
        {
            try
            {

                var result = _repository.DeleteInspection(id);

                if (result.Status == RepositoryActionStatus.Deleted)
                {
                    return StatusCode(HttpStatusCode.NoContent);
                }
                else if (result.Status == RepositoryActionStatus.NotFound)
                {
                    return NotFound();
                }

                return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }



    }
}
