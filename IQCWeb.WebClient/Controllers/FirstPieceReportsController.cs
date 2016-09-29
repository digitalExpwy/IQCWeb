using IQCWeb.DTO;
using IQCWeb.WebClient.Helpers;
using IQCWeb.WebClient.Models;
using Newtonsoft.Json;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace IQCWeb.WebClient.Controllers
{
    public class FirstPieceReportsController : Controller
    {

        public async Task<ActionResult> Index(int? page = 1, string currentFilter = null, string searchString = null)
        {
            if (searchString == null)
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var client = IQCWebHttpClient.GetClient();
           
            var model = new FprViewModel();


            var csResponse = await client.GetAsync("api/employees");

            if (csResponse.IsSuccessStatusCode)
            {
                string csContent = await csResponse.Content.ReadAsStringAsync();
                var lstEmployees = JsonConvert
                    .DeserializeObject<IEnumerable<Employees>>(csContent);

                model.Employees = lstEmployees;
            }
            else
            {
                return Content("An error occurred.");
            }
        
            HttpResponseMessage response;
            if (!String.IsNullOrEmpty(searchString))
            {
                response = await client.GetAsync("api/firstpiecereports?partNum=" + searchString + "&sort=FPR_ID&fields=Inspections,RFI,DesignSites&page=" + page + "&pagesize = 10");
            }
            else
            {
                response = await client.GetAsync("api/firstpiecereports?sort=FPR_ID&fields=Inspections,RFI,DesignSites&page=" + page + "&pagesize = 10");
            }

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();

                var pagingInfo = HeaderParser.FindAndParsePagingInfo(response.Headers);

                var lstFprs = JsonConvert.DeserializeObject<IEnumerable<FirstPieceReports>>(content);


                var pagedFprList = new StaticPagedList<FirstPieceReports>(lstFprs,
                    pagingInfo.CurrentPage,
                    pagingInfo.PageSize, pagingInfo.TotalCount);

                model.PagedFirstPieceReports = pagedFprList;
                model.PagingInfo = pagingInfo;

               
            }
            else
            {
                return Content("An error occurred.");
            }

            return View(model);

            
           
        }

 
        // GET: FirstPieceReports/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            var client = IQCWebHttpClient.GetClient();

            var model = new FprViewModel();


            var csResponse = await client.GetAsync("api/employees");

            if (csResponse.IsSuccessStatusCode)
            {
                string csContent = await csResponse.Content.ReadAsStringAsync();
                var lstEmployees = JsonConvert
                    .DeserializeObject<IEnumerable<Employees>>(csContent);

                model.Employees = lstEmployees;
            }
            else
            {
                return Content("An error occurred.");
            }

            HttpResponseMessage response = await client.GetAsync("api/firstpiecereports/" + id
            + "?fields=RFI, DesignSites");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var lstFprs = JsonConvert.DeserializeObject<FirstPieceReports>(content);
                 model.FirstPieceReport = lstFprs;

                return View(model);
            }

            return Content("An error occurred");
        }



        // GET: FirstPieceReports/Create
        public async Task<ActionResult> Create(int inspID)
        {
            await PopulateMechEngDropDownList();
            await PopulateEplDropDownList();
            await PopulateRfiDropDownList();
            await PopulateDesignSitesDropDownList();

            ViewBag.InspID = inspID;
            return View();
        }

        // POST: FirstPieceReports/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(FirstPieceReports firstpiecerpt)
        {
            try
            {
                var client = IQCWebHttpClient.GetClient();


                var serializedItemToCreate = JsonConvert.SerializeObject(firstpiecerpt);

                var response = await client.PostAsync("api/firstpiecereports",
                    new StringContent(serializedItemToCreate,
                        System.Text.Encoding.Unicode,
                        "application/json"));

                if (response.IsSuccessStatusCode)
                {                    
                    return RedirectToAction("Details", "Inspections", new { id = firstpiecerpt.InspID });
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

        // GET: FirstPieceReports/Edit/5
 
        public async Task<ActionResult> Edit(int id)
        {
            var client = IQCWebHttpClient.GetClient();

            HttpResponseMessage response = await client.GetAsync("api/firstpiecereports/" + id);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<FirstPieceReports>(content);
                await PopulateMechEngDropDownList(model.AuthorizedMechEng);
                await PopulateEplDropDownList(model.EPL);
                await PopulateRfiDropDownList(model.RFI_ID);
                await PopulateDesignSitesDropDownList(model.RFI_ID);
                return View(model);
            }

            return Content("An error occurred.");

        }


        // POST: FirstPieceReports/Edit/5   
        [HttpPost]
                                                                                                                       //*/999*
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, FirstPieceReports firstpiecerpt)
        {
            try
            {
                var client = IQCWebHttpClient.GetClient();
                
                // serialize & PUT
                var serializedItemToUpdate = JsonConvert.SerializeObject(firstpiecerpt);

                var response = await client.PutAsync("api/firstpiecereports/" + id,
                    new StringContent(serializedItemToUpdate,
                    System.Text.Encoding.Unicode, "application/json"));


                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Details", "Inspections", new { id = firstpiecerpt.InspID });
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


        // POST: FirstPieceReports/Delete/5
        public async Task<ActionResult> Delete(int inspId, int id)
        {
            try
            {
                var client = IQCWebHttpClient.GetClient();

                var response = await client.DeleteAsync("api/firstpiecereports/" + id);

                if (response.IsSuccessStatusCode)
                {
                   return RedirectToAction("Details", "Inspections", new { id = inspId });
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


        private async Task PopulateMechEngDropDownList(object selectedValue = null)
        {
            var client = IQCWebHttpClient.GetClient();

            HttpResponseMessage response = await client.GetAsync("api/employees?empFunction=MENG");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var lstMechEngs = JsonConvert.DeserializeObject<IEnumerable<Employees>>(content);
                ViewBag.AuthorizedMechEng = new SelectList(lstMechEngs, "EmployeeCounter", "Name", selectedValue);
            }


        }

        private async Task PopulateEplDropDownList(object selectedValue = null)
        {
            var client = IQCWebHttpClient.GetClient();

            HttpResponseMessage response = await client.GetAsync("api/employees?empFunction=EENG");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var lstEpls = JsonConvert.DeserializeObject<IEnumerable<Employees>>(content);
                ViewBag.EPL = new SelectList(lstEpls, "EmployeeCounter", "Name", selectedValue);
            }


        }

        private async Task PopulateRfiDropDownList(object selectedValue = null)
        {
            var client = IQCWebHttpClient.GetClient();

            HttpResponseMessage response = await client.GetAsync("api/rfi");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var lstRFI = JsonConvert.DeserializeObject<IEnumerable<RFI>>(content);
                ViewBag.RFI_ID = new SelectList(lstRFI, "RFI_ID", "RFI_Name", selectedValue);
            }


        }

        private async Task PopulateDesignSitesDropDownList(object selectedValue = null)
        {
            var client = IQCWebHttpClient.GetClient();

            HttpResponseMessage response = await client.GetAsync("api/designsites");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var lstDesignSites = JsonConvert.DeserializeObject<IEnumerable<DesignSites>>(content);
                ViewBag.DesignSiteID = new SelectList(lstDesignSites, "DesignSiteID", "DesignSite", selectedValue);
            }


        }

       
    }
}
