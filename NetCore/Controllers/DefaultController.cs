using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace NetCore.Controllers
{
    public class DefaultController : Controller
    {
        private readonly ILogger<DefaultController> _logger;
        public DefaultController(ILogger<DefaultController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            _logger.LogInformation("Hello World");
            return View();
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<string>> Get(int id)
        {
            _logger.LogInformation("Start : Getting item details for {ID}", id);

            List<string> list = new List<string>();

            list.Add("A");
            list.Add("B");

            _logger.LogInformation($"Completed : Item details for  {{{string.Join(", ", list)}}}");

            return list;
        }
    }
}