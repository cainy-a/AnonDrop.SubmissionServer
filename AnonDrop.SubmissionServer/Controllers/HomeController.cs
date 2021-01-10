using System.Diagnostics;
using AnonDrop.SubmissionServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AnonDrop.SubmissionServer.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly TargetService           _targetService;

		public HomeController(ILogger<HomeController> logger, TargetService targetService)
		{
			_logger        = logger;
			_targetService = targetService;
		}

		public IActionResult Index() => View(new IndexViewModel
		{
			Action = _targetService.TargetUrl
		});

		public IActionResult Configure() => View();

		[HttpPost]
		public IActionResult SetTargetUrl(string newUrl)
		{
			_targetService.TargetUrl = newUrl;
			return RedirectToAction("Index");
		}

		public IActionResult Privacy() => View();

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error() => View(new ErrorViewModel
			                                     {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
	}
}