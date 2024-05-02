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
    public class HeroController : Controller
    {
        private readonly IheroRepository _heroRepository;
        private readonly IMapper _mapper;
        private readonly IAbilityRepository _abilityRepository;
        private readonly ICharacteristicRepository _characteristicRepository;
        private readonly IStatsRepository _statsRepository;

        public HeroController(IheroRepository heroRepository,
            IMapper mapper,
            IAbilityRepository abilityRepository,
            ICharacteristicRepository characteristicRepository,
            IStatsRepository statsRepository)
        {
            _heroRepository = heroRepository;
            _mapper = mapper;
            _abilityRepository = abilityRepository;
            _characteristicRepository = characteristicRepository;
            _statsRepository = statsRepository;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Hero>))]
        [ProducesResponseType(404)]
        public IActionResult GetHeroes()
        {
            var heroes = _mapper.Map<List<HeroDto>>(
                _heroRepository.GetHeroes());

            if (heroes == null)
                return NotFound();

            return Ok(heroes);
        }

        [HttpGet("{heroId}")]
        [ProducesResponseType(200, Type = typeof(Hero))]
        [ProducesResponseType(404)]
        public IActionResult GetHero(int heroId)
        {
            if (!_heroRepository.HeroExists(heroId))
                return NotFound();

            var hero = _mapper.Map<HeroDto>(
                _heroRepository.GetHero(heroId));

            return Ok(hero);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult CreateHero([FromBody] HeroDto heroCreate)
        {
            //hero exist
            if (_heroRepository.HeroExists(heroCreate.Name))
                BadRequest();

            if (!ModelState.IsValid)
                return BadRequest();

            //hero map 
            var hero = _mapper.Map<Hero>(heroCreate);

            //proceed with creation
            if (!_heroRepository.CreateHero(hero))
            {
                ModelState.AddModelError("", "Something went wrong while saving characteristic");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created hero");
        }

        [HttpPut("{heroId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateHero(int heroId, [FromBody] HeroDto heroUpdate)
        {
            if (heroId != heroUpdate.Id)
                return BadRequest(ModelState);

            if (!_heroRepository.HeroExists(heroId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var heroMap = _mapper.Map<Hero>(heroUpdate);

            if (!_heroRepository.UpdateHero(heroMap))
            {
                ModelState.AddModelError("", "Something went wrong while updating hero");
                return StatusCode(500, ModelState);
            }

            //return result
            return Ok("Succesfully updated hero");
        }

        // when removing hero also removes the pertaining stats, characteristics, be carefull when removing a hero!
        [HttpDelete("{heroId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteHero(int heroId)
        {
            var hero = _heroRepository.GetHero(heroId);

            if (hero == null)
                return NotFound();
            
            var characteristic = _heroRepository.GetHeroCharacteristic(heroId);
            
            var stats = _heroRepository.GetHeroStats(heroId);

            if (!_heroRepository.DeleteHero(hero, characteristic, stats))
            {
                ModelState.AddModelError("", "Something went wrong while deleting hero");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully deleted hero");
        }
    }
}
