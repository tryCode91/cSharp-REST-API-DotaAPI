using AutoMapper;
using DotaAPI.Models;

namespace DotaAPI.Dto.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Ability, AbilityDto>();
            CreateMap<AbilityDto, Ability>();
            CreateMap<AbilityDetail, AbilityDetailDto>();
            CreateMap<AbilityDetailDto, AbilityDetail>();
            CreateMap<Characteristic, CharacteristicDto>();
            CreateMap<Hero, HeroDto>();
            CreateMap<HeroDto, Hero>();
            CreateMap<Characteristic, CharacteristicDto>();
            CreateMap<CharacteristicDto, Characteristic>();
            CreateMap<Stats, StatsDto>();
            CreateMap<StatsDto, Stats>();
        }
    }
}
