using Microsoft.AspNetCore.Mvc;
using s17_l3.Models;

namespace s17_l3.Controllers
{
    public class ScarpaController : Controller
    {
        private readonly ScarpeDbContext _context;

        public ScarpaController(ScarpeDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var scarpe = _context.GetAll();
            return View(scarpe);
        }


        [HttpGet]
        public IActionResult Details([FromRoute] int? id)
        {
            if (id.HasValue)
            {
                var scarpa = _context.GetById(id.Value);
                if (scarpa is null)
                {
                    return View("Error");
                }
                return View(scarpa);
            }
            else
            {
                return RedirectToAction("Index", "Scarpa");
            }
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Scarpa scarpa)
        {
            _context.Scarpe.Add(scarpa);
            _context.SaveChanges();
            return RedirectToAction("Details", new { id = scarpa.ID });
        }

        [HttpGet]
        public IActionResult Edit([FromRoute] int? id)
        {
            if (id is null) return RedirectToAction("Index", "Scarpa");

            var scarpa = _context.GetById(id.Value);
            if (scarpa is null) return View("Error");
            return View(scarpa);
        }

        [HttpPost]
        public IActionResult Edit(Scarpa scarpa)
        {
            _context.Modify(scarpa);
            _context.SaveChanges();
            return RedirectToAction("Details", new { id = scarpa.ID });
        }
    }
}
