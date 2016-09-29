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
    public class ReasonsController : ApiController
    {

        I_IQCWebEFRepository _repository;
        InspectionsMasterDataFactory _inspectionsMasterDataFactory = new InspectionsMasterDataFactory();

        public ReasonsController()
        {
            _repository = new IQCWebRepository(new Repository.Entities.IQCWebData());
        }

        public ReasonsController(I_IQCWebEFRepository repository)
        {
            _repository = repository;
        }

        public IHttpActionResult Get()
        {

            try
            {
                // get Reasons & map to DTO's
                var Reasons = _repository.GetReasons().ToList()
                    .Select(r => _inspectionsMasterDataFactory.CreateReason(r));

                return Ok(Reasons);

            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

       


    }
}
