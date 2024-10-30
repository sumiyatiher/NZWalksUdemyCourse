using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalkz.API.CustomActionFilters;
using NZWalkz.API.Models.DomainModels;
using NZWalkz.API.Models.DTOs.Walks;
using NZWalkz.API.Repo.WalkRepo;
using System.Net;

namespace NZWalkz.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalksRepo walkRepo;

        public WalksController(IMapper mapper,IWalksRepo walkRepo)
        {
            this.mapper = mapper;
            this.walkRepo = walkRepo;
        }
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddRequestWalksDTO Data )
        {
           
                //MAP DTO to Domain Model
                var WalksDomainModel = mapper.Map<Walks>(Data);

                await walkRepo.CreateWalkAsync(WalksDomainModel);

                //MapDomainModel to dto
                return Ok(mapper.Map<WalkDTO>(WalksDomainModel));

        }

        //GET : /api/Walks?filterOn=Name&filterQuery=Track
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery
            , [FromQuery] string? sortBy, [FromQuery] bool? isAsc,
            [FromQuery] int pNumber = 1, [FromQuery] int pSize = 1000)
        {
           
                var listWalkDomainObject = await walkRepo.GetAllAsyc(filterOn, filterQuery, sortBy, isAsc ?? true, pNumber, pSize);

                return Ok(mapper.Map<List<WalkDTO>>(listWalkDomainObject));
           
        }

        [HttpGet]
        [Route("{WalkId:Guid}")]
        public async Task<IActionResult> GetDataById([FromRoute] Guid WalkId)
        {
            var walkDomainObject = await walkRepo.GetWalkById(WalkId);

            if (walkDomainObject == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<WalkDTO>(walkDomainObject));
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateWalk([FromRoute] Guid id, UpdateWalkDTO data)
        {
                var walkDomainModel = mapper.Map<Walks>(data);

                walkDomainModel = await walkRepo.UpdateWalk(id, walkDomainModel);

                if (walkDomainModel == null)
                {
                    return NotFound();
                }

                return Ok(mapper.Map<WalkDTO>(walkDomainModel));

        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteWalk([FromRoute] Guid id)
        {
            var data = await walkRepo.DeleteWalk(id);

            if (data == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<WalkDTO>(data));
        }
    }
}
