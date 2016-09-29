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
    public class IncomingDMRController : Controller
    {

        public async Task<ActionResult> Index(int? page = 1, string currentFilter = null, string searchString = null)
        {
            if (searchString == null)
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var client = IQCWebHttpClient.GetClient();
           
            var model = new DmrViewModel();


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
                response = await client.GetAsync("api/incomingdmr?partNum=" + searchString + "&sort=DMR_ID&fields=Inspections,Reasons&page=" + page + "&pagesize = 10");
            }
            else
            {
                response = await client.GetAsync("api/incomingdmr?sort=DMR_ID&fields=Inspections,Reasons&page=" + page + "&pagesize = 10");
            }

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();

                var pagingInfo = HeaderParser.FindAndParsePagingInfo(response.Headers);

                var lstDmrs = JsonConvert.DeserializeObject<IEnumerable<IncomingDMR>>(content);


                var pagedDmrList = new StaticPagedList<IncomingDMR>(lstDmrs,
                    pagingInfo.CurrentPage,
                    pagingInfo.PageSize, pagingInfo.TotalCount);

                model.PagedIncomingDMR = pagedDmrList;
                model.PagingInfo = pagingInfo;

               
            }
            else
            {
                return Content("An error occurred.");
            }

            return View(model);
                       
           
        }

 
        // GET: IncomingDMR/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            var client = IQCWebHttpClient.GetClient();

            var model = new DmrViewModel();


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

            HttpResponseMessage response = await client.GetAsync("api/incomingdmr/" + id
            + "?fields=Reasons");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var lstDmrs = JsonConvert.DeserializeObject<IncomingDMR>(content);
                 model.DMR = lstDmrs;

                return View(model);
            }

            return Content("An error occurred");
        }



        // GET: IncomingDMR/Create
        public async Task<ActionResult> Create(int inspID)
        {
            await PopulateApprovedByDropDownList();
            await PopulateEngDropDownList();
            await PopulateMfrEngDropDownList();
            await PopulateProdControlDropDownList();
            await PopulatePurchasingDropDownList();
            await PopulateQAEngDropDownList();
            await PopulateMrbCoordDropDownList();
            await PopulateReasonsDropDownList();

            ViewBag.InspID = inspID;
            return View();
        }

        // POST: IncomingDMR/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IncomingDMR dmr)
        {
            try
            {
                var client = IQCWebHttpClient.GetClient();


                var serializedItemToCreate = JsonConvert.SerializeObject(dmr);

                var response = await client.PostAsync("api/incomingdmr",
                    new StringContent(serializedItemToCreate,
                        System.Text.Encoding.Unicode,
                        "application/json"));

                if (response.IsSuccessStatusCode)
                {                    
                    return RedirectToAction("Details", "Inspections", new { id = dmr.InspID });
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

        // GET: IncomingDMR/Edit/5
 
        public async Task<ActionResult> Edit(int id)
        {
            var client = IQCWebHttpClient.GetClient();

            HttpResponseMessage response = await client.GetAsync("api/incomingdmr/" + id);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<IncomingDMR>(content);
                await PopulateApprovedByDropDownList(model.ApprovedBy);
                await PopulateEngDropDownList(model.Engineering);
                await PopulateMfrEngDropDownList(model.MfrEngineering);
                await PopulateProdControlDropDownList(model.ProdControl);
                await PopulatePurchasingDropDownList(model.Purchasing);
                await PopulateQAEngDropDownList(model.QAEngineering);
                await PopulateMrbCoordDropDownList(model.MrbCoordinator);
                await PopulateReasonsDropDownList(model.Reason_ID);
                
                return View(model);
            }

            return Content("An error occurred.");

        }


        // POST: IncomingDMR/Edit/5   
        [HttpPost]                                                                                                                       
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, IncomingDMR dmr)
        {
            try
            {
                var client = IQCWebHttpClient.GetClient();
                
                // serialize & PUT
                var serializedItemToUpdate = JsonConvert.SerializeObject(dmr);

                var response = await client.PutAsync("api/incomingdmr/" + id,
                    new StringContent(serializedItemToUpdate,
                    System.Text.Encoding.Unicode, "application/json"));


                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Details", "IncomingDMR", new { id = dmr.DMR_ID });
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


        // POST: IncomingDMR/Delete/5
        public async Task<ActionResult> Delete(int inspId, int id)
        {
            try
            {
                var client = IQCWebHttpClient.GetClient();

                var response = await client.DeleteAsync("api/incomingdmr/" + id);

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


        private async Task PopulateApprovedByDropDownList(object selectedValue = null)
        {
            var client = IQCWebHttpClient.GetClient();

            HttpResponseMessage response = await client.GetAsync("api/employees?empFunction=QCS");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var lstEmp = JsonConvert.DeserializeObject<IEnumerable<Employees>>(content);
                ViewBag.ApprovedBy = new SelectList(lstEmp, "EmployeeCounter", "Name", selectedValue);
            }


        }

        private async Task PopulateEngDropDownList(object selectedValue = null)
        {
            var client = IQCWebHttpClient.GetClient();

            HttpResponseMessage response = await client.GetAsync("api/employees?empFunction=ENG");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var lstEmp = JsonConvert.DeserializeObject<IEnumerable<Employees>>(content);
                ViewBag.Engineering = new SelectList(lstEmp, "EmployeeCounter", "Name", selectedValue);
            }
        }

        private async Task PopulateMfrEngDropDownList(object selectedValue = null)
        {
            var client = IQCWebHttpClient.GetClient();

            HttpResponseMessage response = await client.GetAsync("api/employees?empFunction=MFG");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var lstEmp = JsonConvert.DeserializeObject<IEnumerable<Employees>>(content);
                ViewBag.MfrEngineering = new SelectList(lstEmp, "EmployeeCounter", "Name", selectedValue);
            }

        }

        private async Task PopulateProdControlDropDownList(object selectedValue = null)
        {
            var client = IQCWebHttpClient.GetClient();

            HttpResponseMessage response = await client.GetAsync("api/employees?empFunction=PC");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var lstEmp = JsonConvert.DeserializeObject<IEnumerable<Employees>>(content);
                ViewBag.ProdControl = new SelectList(lstEmp, "EmployeeCounter", "Name", selectedValue);
            }


        }

        private async Task PopulatePurchasingDropDownList(object selectedValue = null)
        {
            var client = IQCWebHttpClient.GetClient();

            HttpResponseMessage response = await client.GetAsync("api/employees?empFunction=PUR");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var lstEmp = JsonConvert.DeserializeObject<IEnumerable<Employees>>(content);
                ViewBag.Purchasing = new SelectList(lstEmp, "EmployeeCounter", "Name", selectedValue);
            }
        }

        private async Task PopulateQAEngDropDownList(object selectedValue = null)
        {
            var client = IQCWebHttpClient.GetClient();

            HttpResponseMessage response = await client.GetAsync("api/employees?empFunction=QAE");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var lstEmp = JsonConvert.DeserializeObject<IEnumerable<Employees>>(content);
                ViewBag.QAEngineering = new SelectList(lstEmp, "EmployeeCounter", "Name", selectedValue);
            }
        }

        private async Task PopulateMrbCoordDropDownList(object selectedValue = null)
        {
            var client = IQCWebHttpClient.GetClient();

            HttpResponseMessage response = await client.GetAsync("api/employees?empFunction=QCS");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var lstEmp = JsonConvert.DeserializeObject<IEnumerable<Employees>>(content);
                ViewBag.MrbCoordinator = new SelectList(lstEmp, "EmployeeCounter", "Name", selectedValue);
            }
        }


        private async Task PopulateReasonsDropDownList(object selectedValue = null)
        {
            var client = IQCWebHttpClient.GetClient();

            HttpResponseMessage response = await client.GetAsync("api/reasons");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var lstReasons = JsonConvert.DeserializeObject<IEnumerable<Reasons>>(content);
                ViewBag.Reason_ID = new SelectList(lstReasons, "Reason_ID", "ReasonCode", selectedValue);
            }


        }


       
    }
}
