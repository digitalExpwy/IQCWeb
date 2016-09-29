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
    public class IncomingDMRController : ApiController
    {
            
        I_IQCWebEFRepository _repository;
        DmrFactory _dmrFactory = new DmrFactory();

        const int maxPageSize = 10;

        public IncomingDMRController()
        {
            _repository = new IQCWebRepository(new Repository.Entities.IQCWebData());
        }

        public IncomingDMRController(I_IQCWebEFRepository repository)
        {
            _repository = repository;
        }

        
        public IHttpActionResult Get(int id, string fields = "")
        {
            try 
            {
                Repository.Entities.IncomingDMR dmr;
                if (fields.Length > 0)
                {
                   dmr = _repository.GetDmrWithProperties(id, fields);
                }
                else
                {
                    dmr = _repository.GetDMR(id);
                }

                
                if (dmr != null)
                {
                    var returnValue = _dmrFactory.CreateDMR(dmr);
                    
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


        [Route("api/incomingdmr", Name = "PartDmrList")]
        public IHttpActionResult Get(string partNum, string sort = "DMR_ID", string fields = null, int page = 1, int pageSize = 10)
        {
            try
            {   
                var dmr = _repository.GetDmrWithPropertiesByPartNum(partNum, fields);

                if (dmr != null)
                {
                    // ensure the page size isn't larger than the maximum.
                    if (pageSize > maxPageSize)
                    {
                        pageSize = maxPageSize;
                    }

                    var totalCount = dmr.Count();
                    var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

                    var urlHelper = new UrlHelper(Request);
                    var prevLink = page > 1 ? urlHelper.Link("PartDmrList",
                        new
                        {
                            page = page - 1,
                            pageSize = pageSize,
                            sort = sort,
                            fields = fields
                        }) : "";
                    var nextLink = page < totalPages ? urlHelper.Link("PartDmrList",
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


                   return Ok(dmr
                       .ApplySort(sort)
                       .ToList()
                       .Select(d => _dmrFactory.CreateDMR(d)));
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

        [Route("api/incomingdmr", Name = "DmrList")]
        public IHttpActionResult Get(string sort = "DMR_ID", string fields = null, int page = 1, int pageSize = 10)
        {
            try
            {
                List<string> lstOfFields = new List<string>();

                if (fields != null)
                {
                    lstOfFields = fields.ToLower().Split(',').ToList();

                }

                IQueryable<Repository.Entities.IncomingDMR> dmr = null;

                dmr = _repository.GetDmrWithProperties(fields)
                        .ApplySort(sort);

                if (dmr == null)
                {
                    return NotFound();
                }

                // ensure the page size isn't larger than the maximum.
                if (pageSize > maxPageSize)
                {
                    pageSize = maxPageSize;
                }

                var totalCount = dmr.Count();
                var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

                var urlHelper = new UrlHelper(Request);
                var prevLink = page > 1 ? urlHelper.Link("DmrList",
                    new
                    {
                        page = page - 1,
                        pageSize = pageSize,
                        sort = sort,
                        fields = fields
                    }) : "";
                var nextLink = page < totalPages ? urlHelper.Link("DmrList",
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



                return Ok(dmr
                     .Skip(pageSize * (page - 1))
                     .Take(pageSize)
                     .ToList()
                     .Select(d => _dmrFactory.CreateDMR(d)));
                //.Select(eg => _dmrFactory.CreateDataShapedObject(eg, lstOfFields)));

            }
            catch (Exception ex)
            {
                //return InternalServerError();
                throw ex.InnerException;

            }

        


        }




        [Route("api/incomingdmr")]
        [HttpPost]
        public IHttpActionResult Post([FromBody]DTO.IncomingDMR myDmr)
        {
            try
            {
                if (myDmr == null)
                {
                    return BadRequest();
                }

                // map
                var model = _dmrFactory.CreateDMR(myDmr);

                var result = _repository.InsertDMR(model);
                if (result.Status == RepositoryActionStatus.Created)
                {
                    // map to dto
                    var newDmr = _dmrFactory.CreateDMR(result.Entity);
                    return Created<DTO.IncomingDMR>(Request.RequestUri + "/" + newDmr.DMR_ID.ToString(), newDmr);
                }

                return BadRequest();

            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }


        [ValidateModel]
        public IHttpActionResult Put(int id, [FromBody]DTO.IncomingDMR myDmr)
        {
            try
            {
                if (myDmr == null)
                {
                    return BadRequest();
                }

                // map
                var model = _dmrFactory.CreateDMR(myDmr);

                var result = _repository.UpdateDMR(model);
                if (result.Status == RepositoryActionStatus.Updated)
                {
                    // map to dto
                    var updatedDmr = _dmrFactory.CreateDMR(result.Entity);
                    return Ok(updatedDmr);
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
                var result = _repository.DeleteDMR(id);

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
