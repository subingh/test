using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SSWalks.Data;
using SSWalks.Models;

namespace SSWalks.Controllers
{
    //https://localhost:1657/api/regions
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll(SSWalk _dbContext)
        {
            //Get All Regions
            var regions = new List<Region>
            {
                new() {
                    Id = Guid.NewGuid(),
                    Name="Chitlan",
                    Code="CTLN"

                },
                new() {
                    Id=Guid.NewGuid(),
                    Name="America",
                    Code="USA"
                }
            };
            return Ok(regions);
       
        }
    }
}
