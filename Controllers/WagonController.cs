using Microsoft.AspNetCore.Mvc;
using TrainSystem.Models.ModelViews;

namespace TrainSystem.Controllers
{
	public class WagonController : Controller
	{
		public IActionResult Index()
		{
            var sessionData = HttpContext.Session.GetString("SelectTicket");
            var ticket = Newtonsoft.Json.JsonConvert.DeserializeObject<TicketViewModel>(sessionData);
            return View(ticket.Wagons);
		}
	}
}
