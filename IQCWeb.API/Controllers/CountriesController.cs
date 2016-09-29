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
    public class CountriesController : ApiController
    {
        I_IQCWebEFRepository _repository;
        InspectionsMasterDataFactory _inspectionsMasterDataFactory = new InspectionsMasterDataFactory();

        public CountriesController()
        {
            _repository = new IQCWebRepository(new Repository.Entities.IQCWebData());
        }

        public CountriesController(I_IQCWebEFRepository repository)
        {
            _repository = repository;
        }

         
        public IHttpActionResult Get()
        {

            try
            {
                // get countries & map to DTO's
                var countries = _repository.GetCountries().ToList()
                    .Select(cs => _inspectionsMasterDataFactory.CreateCountry(cs));

                return Ok(countries);

            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult Get(int id)
        {
            try
            {

                var country = _repository.GetCountry(id);

                if (country != null)
                {
                    var returnValue = _inspectionsMasterDataFactory.CreateCountry(country);
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



    }
}
