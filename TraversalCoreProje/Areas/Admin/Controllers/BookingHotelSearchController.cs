using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Protocol;
using TraversalCoreProje.Areas.Admin.Models;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class BookingHotelSearchController : Controller
	{
		public async Task<IActionResult> Index()
		{
			//var city = "-1456928";

			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://booking-com.p.rapidapi.com/v2/hotels/search?locale=en-gb&filter_by_currency=EUR&checkin_date=2024-09-14&dest_type=city&dest_id=-1456928&adults_number=2&checkout_date=2024-09-15&order_by=popularity&room_number=1&units=metric&children_number=2&children_ages=5%2C0&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1&include_adjacency=true&page_number=0"),
				Headers =
	{
		{ "X-RapidAPI-Key", "1d67c6e122msh2230c6baee64e7ep13fd08jsncecf114d3848" },
		{ "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
	},
			};
			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
				var bodyReplace = body.Replace(".", "");
				var values = JsonConvert.DeserializeObject<BookingHotelSearchViewModel>(bodyReplace);

				// wishlistName alanını ViewBag'e atamak
				if (values != null && values.results != null && values.results.Any())
				{
					var wishlistName = values.results.First().wishlistName; // İlk sonucu alarak wishlistName'e erişim
					ViewBag.WishlistName = wishlistName;
				}

				return View(values.results.OrderByDescending(x=> x.reviewScore).Take(10));
			}
		}

		[HttpGet]
		public IActionResult GetCityDestID()
		{
			return View();
		}


		[HttpPost]
		public async Task<IActionResult> GetCityDestID(string p)
		{
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?locale=en-gb&name={p}"),
				Headers =
	{
	{ "X-RapidAPI-Key", "1d67c6e122msh2230c6baee64e7ep13fd08jsncecf114d3848" },
		{ "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
	},
			};
			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();

				return View();
			}
		}

	}
}
