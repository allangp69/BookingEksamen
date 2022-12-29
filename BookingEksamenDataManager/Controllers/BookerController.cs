using BookingEksamenDataManager.Interface;
using BookingEksamenDataManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookingEksamenDataManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookerController : ControllerBase
    {
        private readonly IBookers _IBookers;

        public BookerController(IBookers iBookers)
        {
            _IBookers = iBookers;
        }

        // GET: api/booker>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booker>>> Get()
        {
            return await Task.FromResult(_IBookers.GetBookerDetails());
        }

        // GET api/booker/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Booker>> Get(int id)
        {
            var booker = await Task.FromResult(_IBookers.GetBookerDetails(id));
            if (booker is null)
            {
                return NotFound();
            }
            return booker;
        }

        // POST api/booker
        [HttpPost]
        public async Task<ActionResult<Booker>> Post(Booker booker)
        {
            _IBookers.AddBooker(booker);
            return await Task.FromResult(booker);
        }

        // PUT api/booker/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Booker>> Put(int id, Booker booker)
        {
            if (id != booker.BookerID)
            {
                return BadRequest();
            }
            try
            {
                _IBookers.UpdateBooker(booker);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return await Task.FromResult(booker);
        }

        // DELETE api/booker/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Booker>> Delete(int id)
        {
            var booker = _IBookers.DeleteBooker(id);
            return await Task.FromResult(booker);
        }

        private bool BookerExists(int id)
        {
            return _IBookers.CheckBooker(id);
        }
    }
}
