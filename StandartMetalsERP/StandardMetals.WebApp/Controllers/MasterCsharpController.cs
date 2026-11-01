
using Newtonsoft.Json;
using StandardMetals.MODEL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Mvc;

namespace StandardMetals.WebApp.Controllers
{
    public class MasterCsharpController : Controller
    {
        // Read the Web API base URL from Web.config instead of hardcoding it in every method.
        private readonly string apiBaseUrl = ConfigurationManager.AppSettings["APIURL"];

        // Create one reusable method for configuring HttpClient.
        private HttpClient CreateApiClient()
        {
            // HttpClient is used to send HTTP requests from MVC to the Web API.
            HttpClient client = new HttpClient();

            // Read the token generated during login.
            string token = Convert.ToString(Session["Token"]);

            // Add the Basic Authentication header.
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", token);

            return client;
        }

        // Combine the base URL and API endpoint into one complete URL.
        private string GetApiUrl(string endpoint)
        {
            return apiBaseUrl.TrimEnd('/') + "/" + endpoint.TrimStart('/');
        }

        private void LoadDropDown()
        {
            // Create HttpClient using the reusable method.
            using (HttpClient client = CreateApiClient())
            {
                // This sends an HTTP GET request to get manufacturer details.
                var response1 = client.GetAsync(GetApiUrl("ItemMaster17DecApi/GetManufacturerDetails")).Result;

                if (response1.IsSuccessStatusCode)
                {
                    // ReadAsStringAsync() reads the response body as a string.
                    string data = response1.Content.ReadAsStringAsync().Result;

                    // Convert this JSON string into a List of ItemMaster_Modal_AprBtch objects.
                    ViewBag.Manufacturers = JsonConvert.DeserializeObject<List<ItemMaster_Modal_AprBtch>>(data);
                }

                // Get category details from the Web API.
                var response2 = client.GetAsync(GetApiUrl("ItemMaster17DecApi/GetCategoriesDetails")).Result;
                if (response2.IsSuccessStatusCode)
                {
                    string data = response2.Content.ReadAsStringAsync().Result;
                    ViewBag.Categories = JsonConvert.DeserializeObject<List<ItemMaster_Modal_AprBtch>>(data);
                }

                // Get colour details from the Web API.
                var response3 = client.GetAsync(GetApiUrl("ItemMaster17DecApi/GetAllColours")).Result;
                if (response3.IsSuccessStatusCode)
                {
                    string data = response3.Content.ReadAsStringAsync().Result;
                    ViewBag.ColourList = JsonConvert.DeserializeObject<List<ItemMaster_Modal_AprBtch>>(data);
                }

                // Get unit details from the Web API.
                var response4 = client.GetAsync(GetApiUrl("ItemMaster17DecApi/GetUnitDetails")).Result;
                if (response4.IsSuccessStatusCode)
                {
                    string data = response4.Content.ReadAsStringAsync().Result;
                    ViewBag.UnitList = JsonConvert.DeserializeObject<List<ItemMaster_Modal_AprBtch>>(data);
                }
            }
        }

        [HttpGet]
        public ActionResult ItemMasterCsharplist()
        {
            // Create an empty list to store the items returned by the Web API.
            List<ItemMaster_Modal_AprBtch> model = new List<ItemMaster_Modal_AprBtch>();

            using (HttpClient client = CreateApiClient())
            {
                // Build the API URL using the base URL stored in Web.config.
                string url = GetApiUrl("ItemMaster17DecApi/GetAllItemMaster");

                // Send an HTTP GET request and receive the response.
                HttpResponseMessage response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    // Read the API response as a string.
                    string data = response.Content.ReadAsStringAsync().Result;

                    // Convert JSON into a list of item models.
                    model = JsonConvert.DeserializeObject<List<ItemMaster_Modal_AprBtch>>(data);
                }
            }

            // Pass the model list to the MVC View to display the item table.
            return View(model);
        }

        [HttpGet]
        public JsonResult GetSubCategoryN(int id)
        {
            using (HttpClient client = CreateApiClient())
            {
                // Append the selected Category ID to the API endpoint.
                string url = GetApiUrl("ItemMaster17DecApi/GetSubCategoriesDetails/" + id);

                // Send a GET request to retrieve subcategories for the selected category.
                HttpResponseMessage responseMessage = client.GetAsync(url).Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    // Read the response and convert JSON into a list of models.
                    string data = responseMessage.Content.ReadAsStringAsync().Result;
                    var result = JsonConvert.DeserializeObject<List<ItemMaster_Modal_AprBtch>>(data);

                    // Return JSON so the JavaScript code can populate the SubCategory dropdown.
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
            }

            // Return null if the API request fails.
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddNewItem17Dec()
        {
            // Load Manufacturer, Category, Colour and Unit dropdown data.
            LoadDropDown();

            // Initially, no Category is selected, so the SubCategory list is empty.
            ViewBag.SubCategories = new List<ItemMaster_Modal_AprBtch>();

            // Return the Add partial View to be displayed inside the modal.
            return PartialView("_AddNewItem17Dec");
        }

        [HttpPost]
        public ActionResult AddNewItem17Dec(ItemMaster_Modal_AprBtch model)
        {
            // Check whether the submitted model passes MVC validation.
            if (ModelState.IsValid == true)
            {
                using (HttpClient client = CreateApiClient())
                {
                    // Build the API URL for creating a new item.
                    string url = GetApiUrl("ItemMaster17DecApi/CreateItem");

                    // Convert the C# model into a JSON string.
                    string json = JsonConvert.SerializeObject(model);

                    // Prepare JSON content with UTF-8 encoding and application/json content type.
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    // Send an HTTP POST request to the Web API.
                    HttpResponseMessage responseMessage = client.PostAsync(url, content).Result;

                    if (responseMessage.IsSuccessStatusCode)
                    {
                        // Read the API response, such as the generated ItemCode.
                        string result = responseMessage.Content.ReadAsStringAsync().Result;

                        // Return JSON to the AJAX success callback.
                        return Json(new { success = true, code = result, message = "Item Saved Successfully" });
                    }
                }
            }

            // Return validation errors if the model is invalid or the save request fails.
            return Json(new
            {
                success = false,
                errors = ModelState.Where(x => x.Value.Errors.Count > 0).ToDictionary(x => x.Key, x => x.Value.Errors.Select(e => e.ErrorMessage).ToArray()),
                message = "Unable to save item. Please check the entered values and API response."
            });
        }

        [HttpGet]
        public ActionResult EditItem17Dec(int id)
        {
            // Create an empty model to hold the item details returned by the API.
            ItemMaster_Modal_AprBtch model = new ItemMaster_Modal_AprBtch();

            using (HttpClient client = CreateApiClient())
            {
                // Build the API URL using the selected item ID.
                string url = GetApiUrl("ItemMaster17DecApi/GetItemById/" + id);

                // Send a GET request to retrieve the selected item.
                var response = client.GetAsync(url).Result;

                if (!response.IsSuccessStatusCode)
                {
                    return HttpNotFound("Item not found or API request failed.");
                }

                // Read the response and convert JSON into one item model.
                string data = response.Content.ReadAsStringAsync().Result;
                model = JsonConvert.DeserializeObject<ItemMaster_Modal_AprBtch>(data);

                // Load Manufacturer, Category, Colour and Unit dropdown data.
                LoadDropDown();

                // Get the SubCategory records belonging to this item's selected Category.
                string subCategoryUrl = GetApiUrl("ItemMaster17DecApi/GetSubCategoriesDetails/" + model.CategoryId);
                var response1 = client.GetAsync(subCategoryUrl).Result;

                if (response1.IsSuccessStatusCode)
                {
                    string subCategoryData = response1.Content.ReadAsStringAsync().Result;
                    ViewBag.SubCategories = JsonConvert.DeserializeObject<List<ItemMaster_Modal_AprBtch>>(subCategoryData);
                }
                else
                {
                    // Use an empty list if the SubCategory request fails.
                    ViewBag.SubCategories = new List<ItemMaster_Modal_AprBtch>();
                }
            }

            // Pass the selected item and dropdown data to the Edit partial View.
            return PartialView("_EditItem17Dec", model);
        }

        [HttpPost]
        public ActionResult EditItem17Dec(ItemMaster_Modal_AprBtch model)
        {
            // Check whether the submitted model passes MVC validation.
            if (!ModelState.IsValid)
            {
                LoadDropDown();
                ViewBag.SubCategories = new List<ItemMaster_Modal_AprBtch>();
                return PartialView("_EditItem17Dec", model);
            }

            using (HttpClient client = CreateApiClient())
            {
                // Build the API URL using the ID of the item being updated.
                string url = GetApiUrl("ItemMaster17DecApi/UpdateItem/" + model.Id);

                // Convert the updated model into JSON.
                string json = JsonConvert.SerializeObject(model);

                // Prepare the JSON request body.
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                // Send an HTTP PUT request to update the existing item.
                HttpResponseMessage responseMessage = client.PutAsync(url, content).Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    // Return a success response to the AJAX caller.
                    return Json(new { success = true, message = "Item Updated Successfully" });
                }
            }

            // Reload dropdown data if the update fails and return the Edit partial View.
            LoadDropDown();
            ViewBag.SubCategories = new List<ItemMaster_Modal_AprBtch>();

            return PartialView("_EditItem17Dec", model);
        }
    }
}
