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
    public class MoldsController : ApiController
    {
            
        I_IQCWebEFRepository _repository;
        InspectionsMasterDataFactory _dataFactory = new InspectionsMasterDataFactory();

        const int maxPageSize = 10;

        public MoldsController()
        {
            _repository = new IQCWebRepository(new Repository.Entities.IQCWebData());
        }

        public MoldsController(I_IQCWebEFRepository repository)
        {
            _repository = repository;
        }

        
        public IHttpActionResult Get(int id)
        {
            try
            {
                Repository.Entities.Molds mold;
                
                mold = _repository.GetMold(id);
         
                if (mold != null)
                {
                    var returnValue = _dataFactory.CreateMold(mold);

                    return Ok(returnValue);
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

        

        [Route("api/molds")]
        [HttpPost]
        public IHttpActionResult Post([FromBody]DTO.Molds mold)
        {
            try
            {
                if (mold == null)
                {
                    return BadRequest();
                }

                // map
                var model = _dataFactory.CreateMold(mold);

                var result = _repository.InsertMold(model);
                if (result.Status == RepositoryActionStatus.Created)
                {
                    // map to dto
                    var newMold = _dataFactory.CreateMold(result.Entity);
                    return Created<DTO.Molds>(Request.RequestUri + "/" + newMold.InspID.ToString(), newMold);
                }

                return BadRequest();

            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }



        public IHttpActionResult Put(int id, [FromBody]DTO.Molds mold)
        {
            try
            {
                if (mold == null)
                {
                    return BadRequest();
                }

                // map
                var model = _dataFactory.CreateMold(mold);

                var result = _repository.UpdateMold(model);
                if (result.Status == RepositoryActionStatus.Updated)
                {
                    // map to dto
                    var updatedMold = _dataFactory.CreateMold(result.Entity);
                    return Ok(updatedMold);
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

                var result = _repository.DeleteMold(id);

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
