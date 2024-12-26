using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TrainSystem.Models.ModelViews;
namespace TrainSystem.Controllers
{
    public class TicketController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var sessionData = HttpContext.Session.GetString("Tickets");
            var tickets = Newtonsoft.Json.JsonConvert.DeserializeObject<List<TicketViewModel>>(sessionData);
            return View(tickets);
        }
        [HttpPost]
        public IActionResult Index(string selectTicket)
        {
            HttpContext.Session.SetString("SelectTicket", selectTicket);
            return RedirectToAction("Index", "Wagon");
        }
    }
}
