using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalkz.API.CustomActionFilters;
using NZWalkz.API.Data;
using NZWalkz.API.Models.DomainModels;
using NZWalkz.API.Models.DTOs.Region;
using NZWalkz.API.Repo.RegionRepo;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace NZWalkz.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class RegionsController : ControllerBase
    {

        private readonly NZWalkzDBContext dbContext;
        private readonly IRegionRepo regionRepo;
        private readonly IMapper mapper;
        private readonly ILogger<RegionsController> log;

        public RegionsController(NZWalkzDBContext dbContext,IRegionRepo regionRepo,IMapper mapper, ILogger<RegionsController> log)
        {
            this.dbContext = dbContext;
            this.regionRepo = regionRepo;
            this.mapper = mapper;
            this.log = log;
        }

        //Async Method
        [HttpGet]
        //[Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetAllRegAsyc()
        {
            log.LogInformation("GetAllRegAsync was invoked");
            var RegionList = await regionRepo.GetAllRegionAsyc();

            log.LogInformation($"Finished GetAllRegAsync with data {JsonSerializer.Serialize(RegionList)}");

            return Ok(mapper.Map<List<RegionDTO>>(RegionList));

        }

        [HttpGet]
        [Route("{RegID:Guid}")]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetRegionsByIdAsysc([FromRoute] Guid RegID)
        {
            var Region = await regionRepo.GetRegionById(RegID);

            if (Region == null)
            {
                return NotFound();
            }
           
            return Ok(mapper.Map<RegionDTO>(Region));
        }

        [HttpPost]
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> CreateRegion([FromBody] AddRegionReq DataRegion)
        {
          
                //Map DTO TO DOMAIN MODELS
                var regionDomainModel = mapper.Map<Region>(DataRegion);

                //USE DOMAIN OBJECT TO CRAETE REGION
                regionDomainModel = await regionRepo.CreateNewRegion(regionDomainModel);

                //Map Domain Model to DTO
                var RegionDTO = mapper.Map<RegionDTO>(regionDomainModel);

                return CreatedAtAction(nameof(GetRegionsByIdAsysc), new { RegID = RegionDTO.RegionId }, RegionDTO);
            
        }

        [HttpPut]
        [Route("{RegID:Guid}")]
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> UpdateRegion([FromRoute] Guid RegID, [FromBody] UpdateRegionReq Data)
        {
            
                var regionDomainModel = mapper.Map<Region>(Data);

                regionDomainModel = await regionRepo.UpdateRegion(RegID, regionDomainModel);

                if (regionDomainModel == null)
                {
                    return NotFound();
                }

                return Ok(mapper.Map<RegionDTO>(regionDomainModel));
            
        }

        [HttpDelete]
        [Route("{RegID:Guid}")]
        [Authorize(Roles = "Writer,Reader")]
        public async Task<IActionResult> DeleteRegion([FromRoute] Guid RegID)
        {
            var regionDomainModel = await regionRepo.DeleteRegion(RegID);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<RegionDTO>(regionDomainModel));
        }





        //Syncronus

        //https://localhost:7104/api/Regions
        //[HttpGet]
        //public IActionResult GetAllRegions()
        //{
        //    //Get Data From database = Domain Models
        //    var RegionList = dbContext.Regions.ToList();

        //    //Map Domain Models To DTOs
        //    var RegionsDTO = new List<RegionDTO>();

        //    foreach (var region in RegionList)
        //    {
        //        RegionsDTO.Add(new RegionDTO()
        //        {
        //            RegionId = region.RegionId,
        //            Code = region.Code,
        //            Name = region.Name,
        //            RegionImageURL = region.RegionImageURL
        //        });
        //    }

        //    return Ok(RegionsDTO);

        //}

        //https://localhost:7104/api/Regions/[RegID}

        //[HttpGet]
        //[Route("{RegID:Guid}")]
        //public IActionResult GetRegionsById([FromRoute] Guid RegID)
        //{
        //    //var Region = dbContext.Regions.Find(RegID);
        //    //Get from database = domain models
        //    var Region = dbContext.Regions.FirstOrDefault(x => x.RegionId == RegID);

        //    if (Region == null)
        //    {
        //        return NotFound();
        //    }

        //    //Map Domain Models to DTO
        //    var regionDTO = new RegionDTO
        //    {
        //        RegionId = Region.RegionId,
        //        Code = Region.Code,
        //        Name = Region.Name,
        //        RegionImageURL = Region.RegionImageURL
        //    };

        //    return Ok(regionDTO);
        //}

        //public IActionResult CreateRegion([FromBody] AddRegionReq DataRegion)
        //{
        //    //Map DTO TO DOMAIN MODELS
        //    var regionDomainModel = new Region
        //    {
        //        Code = DataRegion.Code,
        //        Name = DataRegion.Name,
        //        RegionImageURL = DataRegion.RegionImageURL
        //    };

        //    //USE DOMAIN OBJECT TO CRAETE REGION
        //    dbContext.Regions.Add(regionDomainModel);
        //    dbContext.SaveChanges();

        //    //Map Domain Model to DTO
        //    var RegionDTO = new RegionDTO
        //    {
        //        RegionId = regionDomainModel.RegionId,
        //        Code = regionDomainModel.Code,
        //        Name = regionDomainModel.Name,
        //        RegionImageURL = regionDomainModel.RegionImageURL
        //    };

        //    return CreatedAtAction(nameof(GetRegionsByIdAsysc), new { RegID = RegionDTO.RegionId }, RegionDTO);
        //}


        //Update Region


        //[HttpPut]
        //[Route("{RegID:Guid}")]
        //public IActionResult UpdateRegion([FromRoute] Guid RegID, [FromBody] UpdateRegionReq Data)
        //{
        //    var regionDomainModel = dbContext.Regions.FirstOrDefault(x => x.RegionId == RegID);

        //    if (regionDomainModel == null)
        //    {
        //        return NotFound();
        //    }

        //    //MAP DTO TO DOMAIN MODEL
        //    regionDomainModel.Code = Data.Code;
        //    regionDomainModel.Name = Data.Name;
        //    regionDomainModel.RegionImageURL = Data.RegionImageURL;

        //    dbContext.SaveChanges();

        //    //Convert DOMAIN MODEL TO DTO

        //    var regionDTO = new RegionDTO
        //    {
        //        RegionId = regionDomainModel.RegionId,
        //        Code = regionDomainModel.Code,
        //        Name = regionDomainModel.Name,
        //        RegionImageURL = regionDomainModel.RegionImageURL
        //    };

        //    return Ok(regionDTO);
        //}

        //DELETE 
        //[HttpDelete]
        //[Route("{RegID:Guid}")]
        //public IActionResult DeleteRegion([FromRoute] Guid RegID)
        //{
        //    var regionDomainModel = dbContext.Regions.FirstOrDefault(x => x.RegionId == RegID);

        //    if (regionDomainModel == null)
        //    {
        //        return NotFound();
        //    }

        //    //Delete 
        //    dbContext.Regions.Remove(regionDomainModel);
        //    dbContext.SaveChanges();

        //    return Ok();
        //}
    }
}
