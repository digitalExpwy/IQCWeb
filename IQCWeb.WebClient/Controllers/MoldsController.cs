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
    public class MoldsController : Controller
    {
        // GET: Molds/Create
        public ActionResult Create(int inspID)
        {
            ViewBag.InspID = inspID;
            return View();
        }

        // POST: Molds/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Molds mold)
        {
            try
            {
                var client = IQCWebHttpClient.GetClient();


                var serializedItemToCreate = JsonConvert.SerializeObject(mold);

                var response = await client.PostAsync("api/molds",
                    new StringContent(serializedItemToCreate,
                        System.Text.Encoding.Unicode,
                        "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Details", "Inspections", new { id = mold.InspID });
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

        // GET: Molds/Edit/5

        public async Task<ActionResult> Edit(int id)
        {
            var client = IQCWebHttpClient.GetClient();

            HttpResponseMessage response = await client.GetAsync("api/molds/" + id);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<Molds>(content);
               
                return View(model);
            }

            return Content("An error occurred.");

        }

        // POST: Molds/Edit/5   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Molds mold)
        {
            try
            {
                var client = IQCWebHttpClient.GetClient();

                // serialize & PUT
                var serializedItemToUpdate = JsonConvert.SerializeObject(mold);

                var response = await client.PutAsync("api/molds/" + id,
                    new StringContent(serializedItemToUpdate,
                    System.Text.Encoding.Unicode, "application/json"));


                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Details", "Inspections", new { id = mold.InspID });
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


        // POST: Molds/Delete/5
        public async Task<ActionResult> Delete(int inspId, int id)
        {
            try
            {
                var client = IQCWebHttpClient.GetClient();

                var response = await client.DeleteAsync("api/molds/" + id);

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
    }
}