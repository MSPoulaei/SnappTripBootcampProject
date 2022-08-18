using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using SnappTrip.BusinessLayer.Interfaces;
using SnappTrip.DataAccessLayer.DTO;
using SnappTrip.DataAccessLayer.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SnappTrip.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApplyController : ControllerBase
    {
        private readonly IMemoryCache memoryCache;
        private readonly IApplyRepos applyRepos;

        // GET: api/<ApplyController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}
        public ApplyController(IApplyRepos applyRepos)
        {
            this.applyRepos = applyRepos;
        }
        // GET /apply
        [HttpGet]
        public ApplyResponse Get(decimal price,string usertype)
        {
            //return memoryCache.Get<List<RCA>>("rca");
            //return SnappTrip.BusinessLayer.MemoryCache.RCAs;
            return applyRepos.GetApplyResponse(new Input()
            {
                price = price,
                UserType = applyRepos.GetUserType(usertype)
            });
        }

    }
}
