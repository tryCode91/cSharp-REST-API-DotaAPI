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
    public class StatsController : Controller
    {
        private readonly IStatsRepository _statsRepository;
        private readonly IMapper _mapper;
        private readonly IheroRepository _heroRepository;

        public StatsController(IStatsRepository statsRepository,
            IMapper mapper,
            IheroRepository heroRepository)
        {
            _statsRepository = statsRepository;
            _mapper = mapper;
            _heroRepository = heroRepository;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Stats>))]
        [ProducesResponseType(404)]
        public IActionResult GetStats()
        {
            var stats = _mapper.Map<List<StatsDto>>(
                _statsRepository.GetStats());

            if (stats == null)
                return NotFound();

            return Ok(stats);
        }
        [HttpGet("{heroId}")]
        [ProducesResponseType(200, Type = typeof(Stats))]
        [ProducesResponseType(404)]
        public IActionResult GetStatsByAHero(int heroId)
        {
            if(!_heroRepository.HeroExists(heroId))
            {
                ModelState.AddModelError("", "Hero does not exist");
                return StatusCode(500, ModelState);
            }
            if (!_statsRepository.HeroStatsExists(heroId))
            {
                ModelState.AddModelError("", "Hero does not have stats");
                return StatusCode(500, ModelState);
            }

            var stats = _mapper.Map<StatsDto>(
                _statsRepository.GetStatsByAHero(heroId));

            return Ok(stats);
        
        }

        [HttpPost("{heroId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult CreateStats([FromBody] StatsDto statsDto, int heroId)
        {
            //hero doesn't exist
            if (!_heroRepository.HeroExists(heroId))
                return BadRequest();

            var hero = _heroRepository.GetHero(heroId);
            
            var heroStats = _statsRepository.HeroStatsExists(heroId);

            //hero have stats
            if (heroStats)
            {
                ModelState.AddModelError("", "Hero already have stats");
                return StatusCode(403, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest();

            var statsMap = _mapper.Map<Stats>(statsDto);
            //add in hero object
            statsMap.Hero = hero;

            //proceed with creation
           if(!_statsRepository.CreateStats(statsMap))
           {
                ModelState.AddModelError("", "Something went wrong while saving stats");
                return StatusCode(500, ModelState);
           }

            return Ok("Successfully created stats");
        }

        [HttpPut("{statsId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateStats(int statsId, [FromBody] StatsDto statsUpdate)
        {
            if (statsId != statsUpdate.StatsId)
                return BadRequest(ModelState);

            if (!_statsRepository.StatsExists(statsId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var statsMap = _mapper.Map<Stats>(statsUpdate);

            if (!_statsRepository.UpdateStats(statsMap))
            {
                ModelState.AddModelError("", "Something went wrong while updating stats");
                return StatusCode(500, ModelState);
            }

            //return result
            return Ok("Succesfully updated stats");
        }

        [HttpDelete("{statsId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteStats(int statsId)
        {
            if (!_statsRepository.StatsExists(statsId))
                return NotFound();

            var stats = _statsRepository.GetStats(statsId);

            if (!_statsRepository.DeleteStats(stats))
            {
                ModelState.AddModelError("", "Something went wrong while deleting stats");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully deleted stats");
        }
    }
}
