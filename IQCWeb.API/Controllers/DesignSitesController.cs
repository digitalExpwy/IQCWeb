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
    public class DesignSitesController : ApiController
    {

        I_IQCWebEFRepository _repository;
        InspectionsMasterDataFactory _inspectionsMasterDataFactory = new InspectionsMasterDataFactory();

        public DesignSitesController()
        {
            _repository = new IQCWebRepository(new Repository.Entities.IQCWebData());
        }

        public DesignSitesController(I_IQCWebEFRepository repository)
        {
            _repository = repository;
        }

        public IHttpActionResult Get()
        {

            try
            {
                // get DesignSites & map to DTO's
                var sites = _repository.GetDesignSites().ToList()
                    .Select(d => _inspectionsMasterDataFactory.CreateDesignSite(d));

                return Ok(sites);

            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

       


    }
}
