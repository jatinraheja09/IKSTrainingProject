using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using MovieApp.Entity;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.UI.Controllers
{
    public class BookingController : Controller
    {
        IConfiguration _configuration;

        public BookingController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IActionResult> BookingReg(int movieId)
        {

            ViewBag.MovieId = movieId;
            using (HttpClient client = new HttpClient())
            {
                string endpoint = _configuration["WebApiURL"] + "User/SelectUsers";
                using (var response = await client.GetAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        // var userModels = Newtonsoft.Json.JsonSerializer.Deserialize<List<UserModel>>(result);
                        var userModels = JsonConvert.DeserializeObject<IEnumerable<UserModel>>(result);
                        List<SelectListItem> selectListItems = new List<SelectListItem>();
                        foreach (var item in userModels)
                        {
                            SelectListItem selectListItem2 = new SelectListItem();
                            selectListItem2.Text = item.FirstName;
                            selectListItem2.Value = item.UserId.ToString();
                            selectListItems.Add(selectListItem2);
                            ViewBag.UserData = selectListItems;
                        }
                    }
                }
            }


            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiURL"] + "MovieShowTime/GetShowTimesAndDateForSpecificTheatreAndMovie?movieId=" + movieId;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var movieShowTimeModel = JsonConvert.DeserializeObject<List<MovieShowTimeModel>>(result);
                        List<SelectListItem> selectListItems = new List<SelectListItem>();
                        foreach (var item in movieShowTimeModel)
                        {
                            SelectListItem selectListItem2 = new SelectListItem();
                            selectListItem2.Text = item.TheatreId.ToString();
                            selectListItem2.Value = item.TheatreId.ToString();
                            selectListItems.Add(selectListItem2);
                            ViewBag.TheatreData = selectListItems;
                        }
                        List<SelectListItem> selectListItemss = new List<SelectListItem>();
                        foreach (var item in movieShowTimeModel)
                        {
                            SelectListItem selectListItem2 = new SelectListItem();
                            selectListItem2.Text = item.ShowTime;
                            selectListItem2.Value = item.ShowTime;
                            selectListItemss.Add(selectListItem2);
                            ViewBag.TimeData = selectListItemss;
                        }
                        List<SelectListItem> selectListItemsss = new List<SelectListItem>();
                        foreach (var item in movieShowTimeModel)
                        {
                            SelectListItem selectListItem2 = new SelectListItem();
                            selectListItem2.Text = item.Date;
                            selectListItem2.Value = item.Date;
                            selectListItemsss.Add(selectListItem2);
                            ViewBag.DateData = selectListItemsss;
                        }
                    }
                }
            }
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            List<SelectListItem> selectListItem = new List<SelectListItem>();
            foreach (int item in arr)
            {
                SelectListItem selectListItems1 = new SelectListItem();
                selectListItems1.Text = item.ToString();
                selectListItems1.Value = item.ToString();
                selectListItem.Add(selectListItems1);
                ViewBag.SeatsData = selectListItem;
            }

            //for(int i=0;i<arr.Length;i++)
            //{
            //    SelectListItem selectListItems1 = new SelectListItem();
            //    selectListItems1.Text = arr[i].ToString();
            //    selectListItems1.Value = arr[i].ToString();
            //    selectListItem.Add(selectListItems1);
            //    ViewBag.SeatsData = selectListItem;
            //}


            // List<SelectListItem> selectListItem = new List<SelectListItem>();
            // SelectListItem selectListItems1 = new SelectListItem();
            //selectListItems1.Text = "1";
            //selectListItems1.Value = "1";
            //selectListItem.Add(selectListItems1);

            //selectListItems1 = new SelectListItem();
            //selectListItems1.Text = "2";
            //selectListItems1.Value = "2";
            //selectListItem.Add(selectListItems1);


            //selectListItems1 = new SelectListItem();
            //selectListItems1.Text = "3";
            //selectListItems1.Value = "3";
            //selectListItem.Add(selectListItems1);



            //selectListItems1 = new SelectListItem();
            //selectListItems1.Text = "4";
            //selectListItems1.Value = "4";
            //selectListItem.Add(selectListItems1);


            //selectListItems1 = new SelectListItem();
            //selectListItems1.Text = "5";
            //selectListItems1.Value = "5";
            //selectListItem.Add(selectListItems1);



            //selectListItems1 = new SelectListItem();
            //selectListItems1.Text = "6";
            //selectListItems1.Value = "6";
            //selectListItem.Add(selectListItems1);



            //selectListItems1 = new SelectListItem();
            //selectListItems1.Text = "7";
            //selectListItems1.Value = "7";
            //selectListItem.Add(selectListItems1);



            //selectListItems1 = new SelectListItem();
            //selectListItems1.Text = "9";
            //selectListItems1.Value = "9";
            //selectListItem.Add(selectListItems1);


            //selectListItems1 = new SelectListItem();
            //selectListItems1.Text = "10";
            //selectListItems1.Value = "10";
            //selectListItem.Add(selectListItems1);
            //ViewBag.SeatsData = selectListItem;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BookingReg(BookingModel bookingModel)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(bookingModel), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiURL"] + "Booking/AddBooking";
                using (var response = await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Success";
                        ViewBag.message = "Inserted!";
                        return RedirectToAction("GetBookings", "Booking");
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

        public async Task<IActionResult> GetBookings()
        {
            using (HttpClient client = new HttpClient())
            {
                string endpoint = _configuration["WebApiURL"] + "Booking/GetAllBookings";
                using (var response = await client.GetAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var bookingModels = JsonConvert.DeserializeObject<IEnumerable<BookingModel>>(result);
                        return View(bookingModels);
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong entries";
                    }
                }
            }
            return View();
        }
    }
}