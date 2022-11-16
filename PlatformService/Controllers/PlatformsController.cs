using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Dtos;
using PlatformService.Inteface;
using PlatformService.Models;

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformRepo _repository;
        private readonly IMapper _mapper;

        public PlatformsController(IPlatformRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
        {
            Console.WriteLine("-->Getting Platforms....");
            var plaformsItem = _repository.GetAllPlatforms();
            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(plaformsItem));
        }

        [HttpGet("{id}", Name = "GetPlatformById")]
        public ActionResult<PlatformReadDto> GetPlatformById(int id)
        {
            Console.WriteLine("-->Getting Platform By Id....");
            var platformItem = _repository.GetPlatformById(id);
            if(platformItem == null) return NotFound();
            
            return Ok(_mapper.Map<PlatformReadDto>(platformItem));
        }


        [HttpPost]
        public ActionResult<PlatformReadDto> CreatePlatform(PlatformCreateDto platformCreateDto)
        {
            if(platformCreateDto==null) return BadRequest(ModelState);
            
            var platformModel = _mapper.Map<Platform>(platformCreateDto);
            _repository.CreatePlatform(platformModel);
            _repository.SaveChanges();

            var PlatformReadDto = _mapper.Map<PlatformReadDto>(platformModel);
            
            return CreatedAtRoute(nameof(GetPlatformById), new {Id = PlatformReadDto.Id}, PlatformReadDto);
        }

        // First Part => name of the route where we can get to our resource  : nameof(resource)
        // Second Part => Returning => Generating Id which is basically a resource Id 
        // Third Part => passing back the response

    }
}