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
    public class RfiController : ApiController
    {

        I_IQCWebEFRepository _repository;
        InspectionsMasterDataFactory _inspectionsMasterDataFactory = new InspectionsMasterDataFactory();

        public RfiController()
        {
            _repository = new IQCWebRepository(new Repository.Entities.IQCWebData());
        }

        public RfiController(I_IQCWebEFRepository repository)
        {
            _repository = repository;
        }

        public IHttpActionResult Get()
        {

            try
            {
                // get RFI & map to DTO's
                var rfi = _repository.GetRFI().ToList()
                    .Select(r => _inspectionsMasterDataFactory.CreateRFI(r));

                return Ok(rfi);

            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

       


    }
}
