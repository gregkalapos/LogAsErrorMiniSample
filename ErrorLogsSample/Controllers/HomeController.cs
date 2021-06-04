using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ErrorLogsSample.Models;

namespace ErrorLogsSample.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			try
			{
				// if (ModelState.IsValid)
				// 	return RedirectToAction("FinalIndex", "Final");
				// else
				// -- always thow:
				throw new Exception("Looks like you did not type something!");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Empty textfield!");
				return RedirectToAction("FinalIndex");
			}

			return View();
		}

		public IActionResult FinalIndex()
		{
			return Ok();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
		}
	}
}