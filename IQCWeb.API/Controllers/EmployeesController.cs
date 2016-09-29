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
    public class EmployeesController : ApiController
    {

        I_IQCWebEFRepository _repository;
        InspectionsMasterDataFactory _inspectionsMasterDataFactory = new InspectionsMasterDataFactory();

        public EmployeesController()
        {
            _repository = new IQCWebRepository(new Repository.Entities.IQCWebData());
        }

        public EmployeesController(I_IQCWebEFRepository repository)
        {
            _repository = repository;
        }

        public IHttpActionResult Get(string empFunction)
        {

            try
            {
                var employees = _repository.GetEmployees(empFunction).ToList()
                    .Select(emp => _inspectionsMasterDataFactory.CreateEmployee(emp));

                return Ok(employees);

            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult Get()
        {
            try
            {
                var employees = _repository.GetEmployees().ToList()
                    .Select(emp => _inspectionsMasterDataFactory.CreateEmployee(emp));

                return Ok(employees);

            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

       


    }
}
