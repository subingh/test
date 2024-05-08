//GhumGhamDbContext : Database context for the connection with dependencies
//regionDomain and regionDto : Objects consisting list of (id, code, name, imageurl) in domain and DTOs respectively
//
using GhumGham.Data;
using GhumGham.Models.Domain;
using GhumGham.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GhumGham.Controllers
{
    //https://localhost:1234/api/Regions
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly GhumGhamDbContext _dbContext; //private section that is used for action result
        //construct constructor (ctor tab)
        public RegionsController(GhumGhamDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        //GET ALL REGIONS
        //GET: https://localhost:portnumber/api/regions
        [HttpGet]
        public IActionResult GetAll()
        {
            //Get Data From Database - Domain Models
            var regionsDomain = _dbContext.Regions.ToList();
            // Map Domain Models to DTOs (Data Transfer Objects)
            var regionsDto = new List<RegionDto>();
            foreach (var regionDomain in regionsDomain)
            {
                regionsDto.Add(new RegionDto()
                {
                    Id = regionDomain.Id,
                    Code = regionDomain.Code,
                    Name = regionDomain.Name,
                    RegionImageUrl = regionDomain.RegionImageUrl,
                });
            }
            //Return DTOs
            return Ok(regionsDto);
        }

        //GET SINGLE REGION (Get Region By ID)
        // GET: http://localhost:portnumber/api/regions/{id}
        [HttpGet]
        [Route ("{id:Guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            //var region = _dbContext.Regions.Find(id);
            //Get Region Domain Model From Database
            var regionDomain = _dbContext.Regions.FirstOrDefault(x => x.Id == id);
            if (regionDomain == null)
            {
                return NotFound();
            }
            //Map/Convert Region Domain Model to Region DTO
            //
            var regionsDto = new RegionDto
            {
               Id=regionDomain.Id,
               Code = regionDomain.Code,
               Name = regionDomain.Name,
               RegionImageUrl=regionDomain.RegionImageUrl
            };
            //Return DTO back to client
            return Ok(regionsDto);
        }

        //POST To Create New Region
        //POST: http://localhost:portnumber/api/regions
        [HttpPost]
        public IActionResult Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            //Map or convert DTO to Domain Model
            var regionDomainModel = new Region
            {
                Code = addRegionRequestDto.Code,
                Name = addRegionRequestDto.Name,
                RegionImageUrl = addRegionRequestDto.RegionImageUrl
            };

            //Use Domain Model to create Region
            _dbContext.Regions.Add(regionDomainModel);//for the insertion in the database while database save change function is called.
            _dbContext.SaveChanges();//save all the changes in the context

            //Map Domain model back to DTO
            var regionDto = new RegionDto
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl
            };
            return CreatedAtAction(nameof(GetById), new {id = regionDomainModel.Id}, regionDomainModel);
        }

    }
}
