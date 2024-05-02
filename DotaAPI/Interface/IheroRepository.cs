using DotaAPI.Models;

namespace DotaAPI.Interface
{
    public interface IheroRepository
    {
        ICollection<Hero> GetHeroes();
        Hero GetHero(int heroId);
        Hero GetHero(string name);
        bool CreateHero(Hero hero);
        bool HeroExists(int heroId);
        bool HeroExists(string name);
        bool HeroStats(int heroId);
        bool DeleteHero(Hero hero, Characteristic characteristic, Stats stats);
        Characteristic GetHeroCharacteristic(int heroId);
        Stats GetHeroStats(int heroId);
        ICollection<HeroAbility> GetHeroAbilities(int heroId);
        bool UpdateHero(Hero hero);
        bool Save();
    }
}
