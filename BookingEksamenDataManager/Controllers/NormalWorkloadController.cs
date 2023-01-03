using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace BookingEksamenDataManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NormalWorkloadController : ControllerBase
    {
        // GET: api/normalworkload>
        [HttpGet]
        public ActionResult<string> Get()
        {
            return DoNormalWorkload();
        }

        private ActionResult<string> DoNormalWorkload()
        {
            var random = new Random();
            var number = random.Next(33, 127);
            var retval = (char)number;
            Thread.Sleep(10);
            return new ActionResult<string>(retval.ToString());
        }
    }
}
