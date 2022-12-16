using System.Data;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BookingEksamen.Data;
using BookingEksamenWebUI.Models;

namespace BookingEksamen.Controllers
{
    public class CommentController : Controller
    {
        private readonly ILogger<CommentController> _logger;
        private readonly ApplicationDbContext _context;
        
        public CommentController(ApplicationDbContext context, ILogger<CommentController> logger)
        {
            _context = context;
            _logger = logger;
        }
        
        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(new []{ "LastName", "FirstMidName", "EmailAddress", "CommentText" })]Comment comment)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Comments.Add(comment);
                    _context.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(comment);
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}