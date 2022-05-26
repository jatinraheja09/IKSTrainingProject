using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Microsoft.Extensions.Configuration;

using System.Text;
using System.Threading.Tasks;
using MovieApp.Entity;
using System.Collections.Generic;
using System.Text.Json;
using Newtonsoft.Json;

namespace MovieApp.UI.Controllers
{
    public class UserController : Controller
    {
        IConfiguration _configuration;


        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IActionResult> Showuserdetails()
        {
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiURL"] + "User/SelectUser";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var userModel = System.Text.Json.JsonSerializer.Deserialize<List<UserModel>>(result);
                        
                       return View(userModel);
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong entries!";
                    }
                }
                return View();

        }

        
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserModel userInfo)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(userInfo), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiURL"] + "User/Register";
                using (var response = await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Register successfully!";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong entries!";
                    }
                }
            }
            return View();
        }
    }
}