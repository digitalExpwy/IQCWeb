using IQCWeb.DTO;
using IQCWeb.WebClient.Helpers;
using IQCWeb.WebClient.Models;
using Newtonsoft.Json;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace IQCWeb.WebClient.Controllers
{
    public class InspectionsController : Controller
    {

        public async Task<ActionResult> Index(int? page = 1, string currentFilter = null, string searchString = null)
        {
            if (searchString == null)
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var client = IQCWebHttpClient.GetClient();

           
            var model = new InspectionsViewModel();

            var csResponse = await client.GetAsync("api/countries");

            if (csResponse.IsSuccessStatusCode)
            {
                string csContent = await csResponse.Content.ReadAsStringAsync();
                var lstCountries = JsonConvert
                    .DeserializeObject<IEnumerable<Countries>>(csContent);

                model.Countries = lstCountries;
            }
            else
            {
                return Content("An error occurred.");
            }
            HttpResponseMessage response;
            if (!String.IsNullOrEmpty(searchString))
            {
                response = await client.GetAsync("api/inspections?partNum=" + searchString + "&sort=InspID&page=" + page + "&pagesize = 10");
            }
            else
            {
                response = await client.GetAsync("api/inspections?sort=PartNum&page=" + page + "&pagesize = 10");
            }

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();

                var pagingInfo = HeaderParser.FindAndParsePagingInfo(response.Headers);

                var lstInspections = JsonConvert.DeserializeObject<IEnumerable<Inspections>>(content);


                var pagedInspectionsList = new StaticPagedList<Inspections>(lstInspections,
                    pagingInfo.CurrentPage,
                    pagingInfo.PageSize, pagingInfo.TotalCount);

                model.Inspections = pagedInspectionsList;
                model.PagingInfo = pagingInfo;

            }
            else
            {
                if (response.ReasonPhrase.Contains("Not Found"))
                {
                    return Content("Not Found");                    
                }
                else
                {
                    return Content("An error occurred.");
                }
            }


            return View(model);
           
        }

 
        // GET: Inspections/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            var client = IQCWebHttpClient.GetClient();

            HttpResponseMessage response = await client.GetAsync("api/inspections/" + id
            + "?fields=Countries, AVM, IIM, Employees, Locations, Molds, FirstPieceReports");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<Inspections>(content);
                return View(model);
            }

            return Content("An error occurred");
        }

        // GET: Inspections/Create
 
        public async Task<ActionResult> Create()
        {
            await PopulateInspectorsDropDownList();
            await PopulateLocationsDropDownList();
            await PopulateCountriesDropDownList();

            return View();
        }

        // POST: Inspections/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Inspections inspection)
        {
            try
            {
                var client = IQCWebHttpClient.GetClient();

                
                var serializedItemToCreate = JsonConvert.SerializeObject(inspection);

                var response = await client.PostAsync("api/inspections",
                    new StringContent(serializedItemToCreate,
                        System.Text.Encoding.Unicode,
                        "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return Content("An error occurred.");
                }
            }
            catch
            {
                return Content("An error occurred.");
            }
        }

        // GET: Inspections/Edit/5
 
        public async Task<ActionResult> Edit(int id)
        {
            var client = IQCWebHttpClient.GetClient();

            HttpResponseMessage response = await client.GetAsync("api/inspections/" + id);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<Inspections>(content);
                await PopulateInspectorsDropDownList(model.EmployeeCounter);
                await PopulateLocationsDropDownList(model.LocationID);
                await PopulateCountriesDropDownList(model.CountryID);
                return View(model);
            }

            return Content("An error occurred.");

        }

        // POST: Inspections/Edit/5   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Inspections inspection)
        {
            try
            {
                
                var client = IQCWebHttpClient.GetClient();
                
                // serialize & PUT
                var serializedItemToUpdate = JsonConvert.SerializeObject(inspection);

                var response = await client.PutAsync("api/inspections/" + id,
                    new StringContent(serializedItemToUpdate,
                    System.Text.Encoding.Unicode, "application/json"));


                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return Content("An error occurred");
                }

            }
            catch
            {
                return Content("An error occurred");
            }
        }
         

        // POST: Inspections/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var client = IQCWebHttpClient.GetClient();

                var response = await client.DeleteAsync("api/inspections/" + id);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return Content("An error occurred");
                }

            }
            catch
            {
                return Content("An error occurred");
            }
        }


        private async Task PopulateInspectorsDropDownList(object selectedValue = null)
        {
            var client = IQCWebHttpClient.GetClient();

            HttpResponseMessage response = await client.GetAsync("api/employees?empFunction=QCI");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var lstInspectors = JsonConvert.DeserializeObject<IEnumerable<Employees>>(content);
                ViewBag.EmployeeCounter = new SelectList(lstInspectors, "EmployeeCounter", "Name", selectedValue);
            }

                        
        }

        private async Task PopulateLocationsDropDownList(object selectedValue = null)
        {
            var client = IQCWebHttpClient.GetClient();

            HttpResponseMessage response = await client.GetAsync("api/locations");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var lstLocations = JsonConvert.DeserializeObject<IEnumerable<Locations>>(content);
                ViewBag.LocationID = new SelectList(lstLocations, "LocationID", "Location", selectedValue);
            }


        }

        private async Task PopulateCountriesDropDownList(object selectedValue = null)
        {
            var client = IQCWebHttpClient.GetClient();

            HttpResponseMessage response = await client.GetAsync("api/countries");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var lstCountries = JsonConvert.DeserializeObject<IEnumerable<Countries>>(content);
                ViewBag.CountryID = new SelectList(lstCountries, "CountryID", "Country", selectedValue);
            }


        }

       
    }
}
