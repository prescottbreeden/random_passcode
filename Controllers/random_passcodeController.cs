using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace random_passcode.Controllers
{
    public class random_passcode : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            int? counter = HttpContext.Session.GetInt32("Counter");
            if (counter == null)
            {
                counter = 1;
            }
            ViewBag.Counter = counter;
            HttpContext.Session.SetInt32("Counter", (int)counter);
            var randPasscode = KeyGenerator.GetUniqueKey(14);
            ViewBag.randPasscode = randPasscode;
            return View("index");
        }

        [HttpPost]
        [Route("process")]
        public IActionResult Proccess()
        {
            int? counter = HttpContext.Session.GetInt32("Counter");
            counter++;
            HttpContext.Session.SetInt32("Counter", (int)counter);
            

            return RedirectToAction("Index");
        }
    }
}