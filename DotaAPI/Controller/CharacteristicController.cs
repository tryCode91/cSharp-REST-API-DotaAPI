using AutoMapper;
using DotaAPI.Dto;
using DotaAPI.Interface;
using DotaAPI.Models;
using DotaAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DotaAPI
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CharacteristicController : Controller
    {
        private readonly ICharacteristicRepository _characteristicRepository;
        private readonly IMapper _mapper;
        private readonly IheroRepository _heroRepository;

        public CharacteristicController(ICharacteristicRepository characteristicRepository,
            IMapper mapper,
            IheroRepository HeroRepository)
        {
            _characteristicRepository = characteristicRepository;
            _mapper = mapper;
            _heroRepository = HeroRepository;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Characteristic>))]
        [ProducesResponseType(404)]
        public IActionResult GetCharacteristics()
        {
            var characteristics = _mapper.Map<List<CharacteristicDto>>(
                _characteristicRepository.GetCharacteristics());

            if (characteristics == null)
                return NotFound();

            return Ok(characteristics);
        }

        [HttpGet("{heroId}")]
        [ProducesResponseType(200, Type = typeof(Characteristic))]
        [ProducesResponseType(404)]
        public IActionResult GetCharacteristicByAHero(int heroId)
        {
            if(!_heroRepository.HeroExists(heroId))
                return NotFound();

            var heroCharacteristic = _characteristicRepository.GetCharacteristicByAHero(heroId);

            if (heroCharacteristic == null)
            {
                ModelState.AddModelError("", "Hero does not have characteristic");
                return StatusCode(500, ModelState);
            }

            var characteristicMap = _mapper.Map<CharacteristicDto>(heroCharacteristic);

            return Ok(characteristicMap);
        }

        [HttpPost("{heroId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult CreateCharacteristic([FromBody] CharacteristicDto characteristicDto, int heroId)
        {
            //hero doesn't exist
            if (!_heroRepository.HeroExists(heroId))
                return BadRequest();
            
            var characteristics = _characteristicRepository.HeroCharacteristicExists(heroId);
            
            //hero have characteristics
            if (characteristics != null)
            {
                ModelState.AddModelError("", "Hero already have characteristic");
                return StatusCode(403, ModelState);
            }
            
            if (!ModelState.IsValid)
                return BadRequest();
            
            //get hero and map characteristic
            var hero = _heroRepository.GetHero(heroId);

            var characteristicMap = _mapper.Map<Characteristic>(characteristicDto);
            characteristicMap.Hero = hero;
            //proceed with creation
            if(!_characteristicRepository.CreateCharacteristic(characteristicMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving characteristic");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created characteristic");
        }

        [HttpPut("{characteristicId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateCharacterisitic(int characteristicId, [FromBody] CharacteristicDto characteristicUpdate)
        {
            if (characteristicId != characteristicUpdate.CharacteristicId)
                return BadRequest(ModelState);

            if (!_characteristicRepository.CharacteristicExists(characteristicId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var characteristicMap = _mapper.Map<Characteristic>(characteristicUpdate);

            var hero = _characteristicRepository.GetCharacteristicByHero(characteristicId);

            characteristicMap.Hero = hero;

            if (!_characteristicRepository.UpdateCharacteristic(characteristicMap))
            {
                ModelState.AddModelError("", "Something went wrong while updating characteristic");
                return StatusCode(500, ModelState);
            }

            //return result
            return Ok("Succesfully updated characteristic");
        }

        [HttpDelete("{characteristicId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteCharacteristic(int characteristicId)
        {
            var characteristic = _characteristicRepository.GetCharacteristic(characteristicId);

            if (characteristic == null)
                return NotFound();

            if (!_characteristicRepository.DeleteCharacteristic(characteristic))
            {
                ModelState.AddModelError("", "Something went wrong while deleting characteristic");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully deleted characteristic");
        }


    }
}
