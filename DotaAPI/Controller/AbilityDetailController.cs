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
    public class AbilityDetailController : Controller
    {
        private readonly IAbilityDetailRepository _abilityDetailRepository;
        private readonly IMapper _mapper;
        private readonly IAbilityRepository _abilityRepository;

        public AbilityDetailController(IAbilityDetailRepository abilityDetailRepository,
            IMapper mapper,
            IAbilityRepository abilityRepository)
        {
            _abilityDetailRepository = abilityDetailRepository;
            _mapper = mapper;
            _abilityRepository = abilityRepository;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<AbilityDetail>))]
        [ProducesResponseType(404)]
        public IActionResult GetAbilityDetails()
        {
            var abilitiesDetails = _mapper.Map<List<AbilityDetailDto>>(_abilityDetailRepository.GetAbilityDetails());

            if (abilitiesDetails == null)
                return NotFound();

            return Ok(abilitiesDetails);
        }

        [HttpGet("{abilityId}")]
        [ProducesResponseType(200, Type = typeof(AbilityDetail))]
        [ProducesResponseType(404)]
        public IActionResult GetDetailByAbility(int abilityId)
        {

            if(!_abilityRepository.AbilityExists(abilityId))
            {
               
                ModelState.AddModelError("", "No ability found");
                return StatusCode(500, ModelState);

            }
            var abilityDetail = _abilityDetailRepository.AbilityHaveDetails(abilityId);
            
            if (abilityDetail == null)
            {
                ModelState.AddModelError("", "No details found");
                return StatusCode(500, ModelState);
            }

            var abilityDetails = _mapper.Map<AbilityDetailDto>(abilityDetail);

            return Ok(abilityDetails);
        }

        [HttpPost("{abilityId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult CreateAbilityDetail([FromBody] AbilityDetailDto abilityDetailDto, int abilityId)
        {
            if (!_abilityRepository.AbilityExists(abilityId))
            {
                ModelState.AddModelError("", "ability does not exist");
                return StatusCode(500, ModelState);
            }

            var abilityDetail = _abilityDetailRepository.AbilityHaveDetails(abilityId);

            if (abilityDetail != null)
            {
                ModelState.AddModelError("", "ability detail already exist");
                return StatusCode(500, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest();

            var abilityDetailMap = _mapper.Map<AbilityDetail>(abilityDetailDto);
            var ability = _abilityRepository.GetAbility(abilityId);
            abilityDetailMap.Ability = ability;

            if (!_abilityDetailRepository.CreateAbilityDetail(abilityDetailMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving ability detail");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created ability detail");
        }

        [HttpPut("{abilityDetailId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateAbilityDetail(int abilityDetailId, [FromBody] AbilityDetailDto abilityDetailUpdate)
        {
            if (abilityDetailId != abilityDetailUpdate.AbilityDetailId)
                return BadRequest(ModelState);

            //check if ability detail exists
            if (!_abilityDetailRepository.AbilityDetailExists(abilityDetailId))
                return NotFound();
            //check if modelstate is valid
            if (!ModelState.IsValid)
                return BadRequest();

            var ability = _abilityDetailRepository.GetAbilityByDetail(abilityDetailId);

            var abilityDetailMap = _mapper.Map<AbilityDetail>(abilityDetailUpdate);

            abilityDetailMap.Ability = ability;

            //perform update
            if (!_abilityDetailRepository.UpdateAbilityDetail(abilityDetailMap))
            {
                ModelState.AddModelError("", "Something went wrong while updating ability detail");
                return StatusCode(500, ModelState);
            }

            //return result
            return Ok("Succesfully updated ability detail");
        }

        [HttpDelete("{abilityDetailId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteAbilityDetail(int abilityDetailId)
        {
            // does ability exist
            var abilityDetail = _abilityDetailRepository.GetAbilityDetail(abilityDetailId);

            if (abilityDetail == null)
                return NotFound();
    
            if (!_abilityDetailRepository.DeleteAbilityDetail(abilityDetail))
            {
                ModelState.AddModelError("", "Something went wrong while deleting ability detail");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully deleted ability detail");
        }

    }
}
