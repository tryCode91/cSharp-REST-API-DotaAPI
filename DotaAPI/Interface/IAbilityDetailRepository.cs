using DotaAPI.Models;

namespace DotaAPI.Interface
{
    public interface IAbilityDetailRepository
    {
        ICollection<AbilityDetail> GetAbilityDetails();
        AbilityDetail GetAbilityDetail(int abilityDetailId);
        bool CreateAbilityDetail(AbilityDetail abilityDetail);
        AbilityDetail AbilityHaveDetails(int abilityId);
        bool DeleteAbilityDetail(AbilityDetail abilityDetail);
        bool UpdateAbilityDetail(AbilityDetail abilityDetail);
        bool AbilityDetailExists(int abilityDetailId);
        Ability GetAbilityByDetail(int abilityDetailId);
        bool Save();
    }
}
