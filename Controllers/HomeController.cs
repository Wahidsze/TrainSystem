using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrainSystem.Services;

namespace TrainSystem.Controllers
{
    public class HomeController : Controller
    {
        private ITicketService _service {  get; set; }
        public HomeController(ITicketService service) 
        {
			_service = service;
		}
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
