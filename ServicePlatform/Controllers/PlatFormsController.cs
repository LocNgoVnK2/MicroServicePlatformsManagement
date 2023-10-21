using AutoMapper;
using MicroservicePlatform.Data;
using MicroservicePlatform.Dtos;
using MicroservicePlatform.Model;
using MicroservicePlatform.SyncDataServices.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroservicePlatform.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlatFormController : ControllerBase
    {
        private IPlatFormRepo _platFormRepo;
        private IMapper _mapper;
        private readonly ICommandDataClient _commandDataClient;

        public PlatFormController(IPlatFormRepo platFormRepo, IMapper mapper, ICommandDataClient commandData)
        {
            _platFormRepo = platFormRepo;
            _mapper = mapper;
            _commandDataClient = commandData;
        }

        [HttpGet("GetPlatForms")]
        public ActionResult<IEnumerable<PlatformReadDto>> GetPlatForms()
        {
            var Platform = _platFormRepo.GetPlatforms();
            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(Platform));
        }
        [HttpGet("GetPlatFormsById/{id}", Name = "GetPlatFormsById")]
        public ActionResult<PlatformReadDto> GetPlatFormsById(int id)
        {
            var Platform = _platFormRepo.GetPlatformById(id);
            if (Platform != null)
                return Ok(_mapper.Map<PlatformReadDto>(Platform));
            else
                return NotFound();
        }
        [HttpPost("CreatePlatForm")]
        public async Task<ActionResult<PlatformReadDto>> CreatePlatFormAsync(PlatformCreateDto platformCreateDto)
        {
            var platformModel = _mapper.Map<Platform>(platformCreateDto);
            _platFormRepo.CreatePlatform(platformModel);
            _platFormRepo.SaveChanges();
            
            var platformReadDto = _mapper.Map<PlatformReadDto>(platformModel);
            
            // Send Sync Message
            try
            {
                await _commandDataClient.SendPlatformToCommand(platformReadDto);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"--> Could not send synchronously: {ex.Message}");
            }
         
            return CreatedAtRoute(nameof(GetPlatFormsById), new { id = platformReadDto.Id }, platformReadDto);
        }
        [HttpDelete("DeletePlatForm")]
        public ActionResult<PlatformReadDto> DeletePlatForm(int Id)
        {
            try{
          
            var Platform = _platFormRepo.GetPlatformById(Id);
            if (Platform != null)
            {
                _platFormRepo.RemovePlatform(Platform);
                _platFormRepo.SaveChanges();
                return Ok();
            }
            else
                return NotFound();
            }catch{
                return NotFound();
            }
            
        }
        [HttpPut("UpdatePlatForm/{id}")]
        public ActionResult<PlatformReadDto> UpdatePlatForm(int id, PlatformCreateDto platformUpdateDto)
        {
            var existingPlatform = _platFormRepo.GetPlatformById(id);

            if (existingPlatform == null)
            {
                return NotFound();
            }

            // Update the existing platform with data from the platformUpdateDto
            _mapper.Map(platformUpdateDto, existingPlatform);

            _platFormRepo.SaveChanges();

            var updatedPlatform = _mapper.Map<PlatformReadDto>(existingPlatform);
            return Ok(updatedPlatform);
        }
    }
}