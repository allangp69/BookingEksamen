using BookingEksamenDataManager.Interface;
using BookingEksamenDataManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookingEksamenDataManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IComments _IComments;

        public CommentController(IComments iComments)
        {
            _IComments = iComments;
        }

        // GET: api/comment>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comment>>> Get()
        {
            return await Task.FromResult(_IComments.GetCommentDetails());
        }

        // GET api/comment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Comment>> Get(int id)
        {
            var comment = await Task.FromResult(_IComments.GetCommentDetails(id));
            if (comment is null)
            {
                return NotFound();
            }
            return comment;
        }

        // POST api/comment
        [HttpPost]
        public async Task<ActionResult<Comment>> Post(Comment comment)
        {
            _IComments.AddComment(comment);
            return await Task.FromResult(comment);
        }

        // PUT api/comment/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Comment>> Put(int id, Comment comment)
        {
            if (id != comment.Id)
            {
                return BadRequest();
            }
            try
            {
                _IComments.UpdateComment(comment);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return await Task.FromResult(comment);
        }

        // DELETE api/comment/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Comment>> Delete(int id)
        {
            var comment = _IComments.DeleteComment(id);
            return await Task.FromResult(comment);
        }

        private bool CommentExists(int id)
        {
            return _IComments.CheckComment(id);
        }
    }
}
