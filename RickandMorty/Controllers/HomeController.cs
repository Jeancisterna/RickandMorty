using Microsoft.AspNetCore.Mvc;
using RickandMorty.Models;
using System.Diagnostics;
using System.Text.Json;

namespace RickandMorty.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public async Task<IActionResult> Index()
		{
			string url = "https://rickandmortyapi.com/api/character";
			var client = new HttpClient();
			var response = await client.GetAsync(url);
			var body = await response.Content.ReadAsStringAsync();
			var rick = JsonSerializer.Deserialize<Root>(body);


			return View("Index", rick);
			
		}

		public async Task<IActionResult> Privacy()
		{
			return View("Privacy");
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}