using DotaAPI.Models;

namespace DotaAPI.Interface
{
    public interface IAbilityRepository
    {
        ICollection<Ability> GetAbilities();
        Ability GetAbility(string title);
        Ability GetAbility(int id);
        bool CreateAbility(Ability ability, Hero hero);
        bool AbilityExists(int abilityId);
        bool DeleteAbility(Ability ability);
        bool UpdateAbility(Ability ability);
        ICollection<Ability>? GetAbilityByAHero(int heroId);
        bool Save();
    }
}
