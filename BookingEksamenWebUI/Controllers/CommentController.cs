using System.Data;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BookingEksamenWebUI.Helpers;
using BookingEksamenWebUI.Models;

namespace BookingEksamen.Controllers
{
    public class CommentController : Controller
    {
        private readonly ILogger<CommentController> _logger;
        private readonly ICommentAPIHelper _commentApiHelper;
        
        public CommentController(ICommentAPIHelper commentApiHelper, ILogger<CommentController> logger)
        {
            _commentApiHelper = commentApiHelper;
            _logger = logger;
        }
        
        // GET: Comments
        public async Task<IActionResult> Index()
        {
            var comments = await _commentApiHelper.GetCommentsAsync();
            return View(comments);
        }
        
        
        // GET: Comments/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(new []{ "LastName", "FirstMidName", "EmailAddress", "CommentText" })]Comment comment)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _commentApiHelper.CreateCommentAsync(comment);
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
        
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _commentApiHelper.DeleteCommentAsync(id); 
                return RedirectToAction("Index", "Comment");
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return RedirectToAction("Index", "Comment");
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}