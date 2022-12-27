using BookingEksamenDataManager.Interface;
using BookingEksamenDataManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookingEksamenDataManager.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IArtists _IArtists;

        public ArtistController(IArtists iArtists)
        {
            _IArtists = iArtists;
        }

        // GET: api/artist>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artist>>> Get()
        {
            return await Task.FromResult(_IArtists.GetArtistDetails());
        }

        // GET api/artist/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Artist>> Get(int id)
        {
            var artist = await Task.FromResult(_IArtists.GetArtistDetails(id));
            if (artist is null)
            {
                return NotFound();
            }
            return artist;
        }

        // POST api/artist
        [HttpPost]
        public async Task<ActionResult<Artist>> Post(Artist artist)
        {
            _IArtists.AddArtist(artist);
            return await Task.FromResult(artist);
        }

        // PUT api/artist/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Artist>> Put(int id, Artist artist)
        {
            if (id != artist.ArtistID)
            {
                return BadRequest();
            }
            try
            {
                _IArtists.UpdateArtist(artist);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtistExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return await Task.FromResult(artist);
        }

        // DELETE api/artist/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Artist>> Delete(int id)
        {
            var artist = _IArtists.DeleteArtist(id);
            return await Task.FromResult(artist);
        }

        private bool ArtistExists(int id)
        {
            return _IArtists.CheckArtist(id);
        }
    }
}
