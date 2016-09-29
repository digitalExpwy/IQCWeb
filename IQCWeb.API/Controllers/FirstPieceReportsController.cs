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
using IQCWeb.API.Controllers.Helpers;

namespace IQCWeb.API.Controllers
{
    public class FirstPieceReportsController : ApiController
    {
            
        I_IQCWebEFRepository _repository;
        FprFactory _fprFactory = new FprFactory();

        const int maxPageSize = 10;

        public FirstPieceReportsController()
        {
            _repository = new IQCWebRepository(new Repository.Entities.IQCWebData());
        }

        public FirstPieceReportsController(I_IQCWebEFRepository repository)
        {
            _repository = repository;
        }

        
        public IHttpActionResult Get(int id, string fields = "")
        {
            try 
            {
                Repository.Entities.FirstPieceReports fpr;
                if (fields.Length > 0)
                {
                   fpr = _repository.GetFprWithProperties(id, fields);
                }
                else
                {
                    fpr = _repository.GetFPR(id);
                }

                
                if (fpr != null)
                {
                    var returnValue = _fprFactory.CreateFPR(fpr);
                    
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


        [Route("api/firstpiecereports", Name = "PartFprList")]
        public IHttpActionResult Get(string partNum, string sort = "FPR_ID", string fields = null, int page = 1, int pageSize = 10)
        {
            try
            {   
                var fpr = _repository.GetFprWithPropertiesByPartNum(partNum, fields);

                if (fpr != null)
                {
                    // ensure the page size isn't larger than the maximum.
                    if (pageSize > maxPageSize)
                    {
                        pageSize = maxPageSize;
                    }

                    var totalCount = fpr.Count();
                    var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

                    var urlHelper = new UrlHelper(Request);
                    var prevLink = page > 1 ? urlHelper.Link("PartFprList",
                        new
                        {
                            page = page - 1,
                            pageSize = pageSize,
                            sort = sort,
                            fields = fields
                        }) : "";
                    var nextLink = page < totalPages ? urlHelper.Link("PartFprList",
                        new
                        {
                            page = page + 1,
                            pageSize = pageSize,
                            sort = sort,
                            fields = fields
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


                   return Ok(fpr
                       .ApplySort(sort)
                       .ToList()
                       .Select(f => _fprFactory.CreateFPR(f)));
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

        [Route("api/firstpiecereports", Name = "FprList")]
        public IHttpActionResult Get(string sort = "FPR_ID", string fields = null, int page = 1, int pageSize = 10)
        {
            try
            {
                List<string> lstOfFields = new List<string>();

                if (fields != null)
                {
                    lstOfFields = fields.ToLower().Split(',').ToList();

                }

                IQueryable<Repository.Entities.FirstPieceReports> fpr = null;

                fpr = _repository.GetFprWithProperties(fields)
                        .ApplySort(sort);            

                if (fpr == null)
                {
                    return NotFound();
                }

                // ensure the page size isn't larger than the maximum.
                if (pageSize > maxPageSize)
                {
                    pageSize = maxPageSize;
                }

                var totalCount = fpr.Count();
                var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

                var urlHelper = new UrlHelper(Request);
                var prevLink = page > 1 ? urlHelper.Link("FprList",
                    new
                    {
                        page = page - 1,
                        pageSize = pageSize,
                        sort = sort,
                        fields = fields
                    }) : "";
                var nextLink = page < totalPages ? urlHelper.Link("FprList",
                    new
                    {
                        page = page + 1,
                        pageSize = pageSize,
                        sort = sort,
                        fields = fields
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

              
                return Ok(fpr
                     .Skip(pageSize * (page - 1))
                     .Take(pageSize)
                     .ToList()                     
                     .Select(f => _fprFactory.CreateFPR(f)));
             //.Select(eg => _fprFactory.CreateDataShapedObject(eg, lstOfFields)));

            }
            catch (Exception ex)
            {
                //return InternalServerError();
                throw ex.InnerException;

            }

        }




        [Route("api/firstpiecereports")]
        [HttpPost]
        public IHttpActionResult Post([FromBody]DTO.FirstPieceReports myFpr)
        {
            try
            {
                if (myFpr == null)
                {
                    return BadRequest();
                }

                // map
                var model = _fprFactory.CreateFPR(myFpr);

                var result = _repository.InsertFPR(model);
                if (result.Status == RepositoryActionStatus.Created)
                {
                    // map to dto
                    var newFpr = _fprFactory.CreateFPR(result.Entity);
                    return Created<DTO.FirstPieceReports>(Request.RequestUri + "/" + newFpr.FPR_ID.ToString(), newFpr);
                }

                return BadRequest();

            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }


        [ValidateModel]
        public IHttpActionResult Put(int id, [FromBody]DTO.FirstPieceReports myFpr)
        {
            try
            {
                if (myFpr == null)
                {
                    return BadRequest();
                }

                // map
                var model = _fprFactory.CreateFPR(myFpr);

                var result = _repository.UpdateFPR(model);
                if (result.Status == RepositoryActionStatus.Updated)
                {
                    // map to dto
                    var updatedFpr = _fprFactory.CreateFPR(result.Entity);
                    return Ok(updatedFpr);
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

                var result = _repository.DeleteFPR(id);

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
