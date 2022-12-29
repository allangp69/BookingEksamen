using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace BookingEksamenDataManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeavyWorkloadController : ControllerBase
    {
        // GET: api/heavyworkload>
        [HttpGet]
        public ActionResult<string> Get()
        {
            return DoHeavyWorkload();
        }

        private ActionResult<string> DoHeavyWorkload()
        {
            var random = new Random();
            var retval = new StringBuilder();
            for (var i = 0; i < 3000; i++)
            {
                var number = random.Next(33, 127);
                retval.Append(((char) number));
                Thread.Sleep(2);
            }
            return new ActionResult<string>(retval.ToString());
        }
    }
}
