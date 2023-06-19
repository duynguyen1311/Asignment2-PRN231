using BusinessObject.Model;
using eBookStore.Models.Author;
using eBookStore.Models.Publisher;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace eBookStore.Controllers
{
    public class ManageController : Controller
    {
        private readonly HttpClient client = null;
        private string ApiUrl = "";
        public ManageController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            ApiUrl = "https://localhost:44322/odata";
        }

        public class ResponseObject<T> where T : class
        {
            public string odataContext { get; set; }
            public List<T> value { get; set; }
        }

        /*public class ResponseDetail<T> where T: class
        {
            public string odataContext { get; set; }
            public int pub_id { get; set; }
            public string publisher_name { get; set; }
            public string? city { get; set; }
            public string? state { get; set; }
            public string? country { get; set; }
        }*/

        public class ResponseDetail<T> where T : class
        {
            public T Value { get; set; }
        }


        #region Publisher

        [HttpGet]
        public async Task<IActionResult> Publisher()
        {
            HttpResponseMessage response = await client.GetAsync(ApiUrl + "/Publisher");
            string strData = await response.Content.ReadAsStringAsync();
            ResponseObject<Publisher> rootObject = System.Text.Json.JsonSerializer.Deserialize<ResponseObject<Publisher>>(strData);
            ViewBag.model = rootObject.value;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddPublisher()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddPublisher(PublisherRequestViewModel model)
        {
            var body = new
            {
                publisher_name = model.publisher_name,
                city = model.city,
                state = model.state,
                country = model.country
            };

            var json = JsonConvert.SerializeObject(body);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(ApiUrl + "/Publisher", content);
            return RedirectToAction("Publisher", "Manage");
        }

        [HttpGet]
        public async Task<IActionResult> UpdatePublisher(PublisherRequestViewModel model, string pid, bool isEdit)
        {
            HttpResponseMessage response = await client.GetAsync(ApiUrl + $"/Publisher/{pid}");
            string strData = await response.Content.ReadAsStringAsync();
            var pub = new ResponseDetail<Publisher>().Value;
            pub = System.Text.Json.JsonSerializer.Deserialize<Publisher>(strData);
            model.pub_id = pub.pub_id;
            model.publisher_name = pub.publisher_name;
            model.state = pub.state;
            model.country = pub.country;
            model.city = pub.city;
            model.IsEdited = isEdit;
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> UpdatePublisher(PublisherRequestViewModel model)
        {
            var body = new
            {
                pub_id = model.pub_id,
                publisher_name = model.publisher_name,
                city = model.city,
                state = model.state,
                country = model.country
            };

            var json = JsonConvert.SerializeObject(body);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync(ApiUrl + $"/Publisher/{model.pub_id}", content);
            return RedirectToAction("Publisher", "Manage");
        }

        [HttpGet]
        public async Task<IActionResult> DeletePublisher(string pid)
        {
            HttpResponseMessage response = await client.DeleteAsync(ApiUrl + $"/Publisher/{pid}");
            return RedirectToAction("Publisher", "Manage");
        }

        #endregion


        #region Book
        [HttpGet]
        public async Task<IActionResult> Book()
        {
            HttpResponseMessage response = await client.GetAsync(ApiUrl + "/Book");
            string strData = await response.Content.ReadAsStringAsync();
            ResponseObject<Book> rootObject = System.Text.Json.JsonSerializer.Deserialize<ResponseObject<Book>>(strData);
            ViewBag.model = rootObject.value;
            return View();
        }

        #endregion

        #region Author

        [HttpGet]
        public async Task<IActionResult> AddAuthor()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAuthor(AuthorRequestViewModel model)
        {
            var body = new
            {
                author_id = model.author_id,
                last_name = model.last_name,
                first_name = model.first_name,
                email_address = model.email_address,
                phone = model.phone,
                address = model.address,
                city = model.city,
                state = model.state,
                zip = model.zip
            };

            var json = JsonConvert.SerializeObject(body);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(ApiUrl + "/Author", content);
            return RedirectToAction("Author", "Manage");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateAuthor(AuthorRequestViewModel model, string aid, bool isEdit)
        {
            HttpResponseMessage response = await client.GetAsync(ApiUrl + $"/Author/{aid}");
            string strData = await response.Content.ReadAsStringAsync();

            var aut = new ResponseDetail<Author>().Value;
            aut = System.Text.Json.JsonSerializer.Deserialize<Author>(strData);
            model.author_id = aut.author_id;
            model.first_name = aut.first_name;
            model.last_name = aut.last_name;
            model.email_address = aut.email_address;
            model.phone = aut.phone;
            model.address = aut.address;
            model.city = aut.city;
            model.state = aut.state;
            model.zip = aut.zip;
            model.IsEdited = isEdit;
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateAuthor(AuthorRequestViewModel model)
        {
            var body = new
            {
                author_id = model.author_id,
                last_name = model.last_name,
                first_name = model.first_name,
                email_address = model.email_address,
                phone = model.phone,
                address = model.address,
                city = model.city,
                state = model.state,
                zip = model.zip
            };

            var json = JsonConvert.SerializeObject(body);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync(ApiUrl + $"/Author/{model.author_id}", content);
            return RedirectToAction("Author", "Manage");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteAuthor(string aid)
        {
            HttpResponseMessage response = await client.DeleteAsync(ApiUrl + $"/Author/{aid}");
            return RedirectToAction("Author", "Manage");
        }

        [HttpGet]
        public async Task<IActionResult> Author()
        {
            HttpResponseMessage response = await client.GetAsync(ApiUrl + "/Author");
            string strData = await response.Content.ReadAsStringAsync();
            ResponseObject<Author> rootObject = System.Text.Json.JsonSerializer.Deserialize<ResponseObject<Author>>(strData);
            ViewBag.model = rootObject.value;
            return View();
        }

        #endregion
    }
}
