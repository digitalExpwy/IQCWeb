using IQCWeb.Repository;
using IQCWeb.Repository.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IQCWeb.API.Controllers
{
    public class PartsController : ApiController
    {

        I_IQCWebEFRepository _repository;
        InspectionsMasterDataFactory _inspectionsMasterDataFactory = new InspectionsMasterDataFactory();

        public PartsController()
        {
            _repository = new IQCWebRepository(new Repository.Entities.IQCWebData());
        }

        public PartsController(I_IQCWebEFRepository repository)
        {
            _repository = repository;
        }

        public IHttpActionResult Get(string term)
        {
            try
            {
                var parts = _repository.GetParts(term).ToList()
                    .Select(p => new
                    {
                        p.PartNum
                    });

                return Ok(parts);

            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

       


    }
}
