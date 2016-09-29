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
    public class LocationsController : ApiController
    {

        I_IQCWebEFRepository _repository;
        InspectionsMasterDataFactory _inspectionsMasterDataFactory = new InspectionsMasterDataFactory();

        public LocationsController()
        {
            _repository = new IQCWebRepository(new Repository.Entities.IQCWebData());
        }

        public LocationsController(I_IQCWebEFRepository repository)
        {
            _repository = repository;
        }

        public IHttpActionResult Get()
        {

            try
            {
                // get locations & map to DTO's
                var locations = _repository.GetLocations().ToList()
                    .Select(loc => _inspectionsMasterDataFactory.CreateLocation(loc));

                return Ok(locations);

            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

       


    }
}
