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
    public class AbilityController : Controller
    {
        private readonly IAbilityRepository _abilityRepository;
        private readonly IMapper _mapper;
        private readonly IheroRepository _heroRepository;
        private readonly IAbilityDetailRepository _abilityDetailRepository;

        public AbilityController(IAbilityRepository abilityRepository,
            IMapper mapper,
            IheroRepository heroRepository,
            IAbilityDetailRepository abilityDetailRepository)
        {
            _abilityRepository = abilityRepository;
            _mapper = mapper;
            _heroRepository = heroRepository;
            _abilityDetailRepository = abilityDetailRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Ability>))]
        [ProducesResponseType(404)]
        public IActionResult GetAbilities()
        {
            var abilities = _mapper.Map<List<AbilityDto>>(_abilityRepository.GetAbilities());

            if (abilities == null)
                return NotFound();

            return Ok(abilities);
        }
        [HttpGet("{heroId}")]
        [ProducesResponseType(200, Type = typeof(Ability))]
        [ProducesResponseType(404)]
        public IActionResult GetAbilityByAHero(int heroId)
        {
            if (!_heroRepository.HeroExists(heroId))
            {
                ModelState.AddModelError("", "Hero does not exist");
                return StatusCode(500, ModelState);
            }
            
            var abilities = _abilityRepository.GetAbilityByAHero(heroId);

            if (abilities == null)
            {
                ModelState.AddModelError("", "Hero does not have any abilities");
                return StatusCode(500, ModelState);
            }

            var abilityMap = _mapper.Map<List<AbilityDto>>(abilities);

            return Ok(abilityMap);
        }

        [HttpPost("{heroId})")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult CreateAbility([FromBody] AbilityDto abilityDto, int heroId)
        {
            if (_abilityRepository.GetAbility(abilityDto.Title) != null) // ability exists
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var hero = _heroRepository.GetHero(heroId);
          
            var abilityMap = _mapper.Map<Ability>(abilityDto);

            if(!_abilityRepository.CreateAbility(abilityMap, hero)){
                ModelState.AddModelError("", "Something went wrong while saving ability");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created ability");
        }
        [HttpPut("{abilityId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateAbility(int abilityId, [FromBody] AbilityDto abilityUpdate)
        {
            if (abilityId != abilityUpdate.AbilityId)
                return BadRequest(ModelState);

            if (!_abilityRepository.AbilityExists(abilityId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var abilityMap = _mapper.Map<Ability>(abilityUpdate);

            if (!_abilityRepository.UpdateAbility(abilityMap))
            {
                ModelState.AddModelError("", "Something went wrong while updating ability");
                return StatusCode(500, ModelState);
            }

            //return result
            return Ok("Succesfully updated ability");
        }
        [HttpDelete("{abilityId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteAbility(int abilityId)
        {
            // does ability exist
            var ability = _abilityRepository.GetAbility(abilityId);

            if (ability == null)
                return NotFound();

            //if ability have details
            if(_abilityDetailRepository.AbilityHaveDetails(abilityId) != null)
            {
                ModelState.AddModelError("", "Could not delete ability, because it is tied to a detail page");
                return StatusCode(500, ModelState);
            }

            if (!_abilityRepository.DeleteAbility(ability))
            {
                ModelState.AddModelError("", "Something went wrong while deleting ability");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully deleted ability");
        }

    }
}
