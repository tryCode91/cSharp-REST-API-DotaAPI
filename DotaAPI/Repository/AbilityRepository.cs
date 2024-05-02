using DotaAPI.Data;
using DotaAPI.Interface;
using DotaAPI.Models;
using System.Reflection.Metadata.Ecma335;

namespace DotaAPI.Repository
{
    public class AbilityRepository : IAbilityRepository
    {
        private readonly DataContext _context;

        public AbilityRepository(DataContext context)
        {
            _context = context;
        }

        public bool AbilityExists(int abilityId)
        {
            return _context.Abilities.Any(a => a.AbilityId == abilityId);
        }

        public bool CreateAbility(Ability ability, Hero hero)
        {
            var heroAbility = new HeroAbility()
            {
                Ability = ability,
                Hero = hero,
            };
            _context.Add(heroAbility);
            _context.Add(ability);
            return Save();
        }

        public bool DeleteAbility(Ability ability)
        {
            _context.Remove(ability);
            return Save();
        }

        public ICollection<Ability> GetAbilities()
        {
            return _context.Abilities.OrderBy(a => a.AbilityId).ToList();
        }

        public Ability GetAbility(string title)
        {
            return _context.Abilities.Where(a => a.Title.ToLower() == title.ToLower()).FirstOrDefault();
        }

        public Ability GetAbility(int abilityId)
        {
            return _context.Abilities.Where(a => a.AbilityId == abilityId).FirstOrDefault();
        }

        public ICollection<Ability>? GetAbilityByAHero(int heroId)
        {
            // get all abilityIds pertaining to hero
            var abilities = _context.HeroAbilities.Where(ha => ha.HeroId == heroId).Select(a => a.AbilityId).ToList();


            return _context.Abilities.Where(a => abilities.Contains(a.AbilityId)).ToList();

        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateAbility(Ability ability)
        {
            _context.Update(ability);
            return Save();
        }
    }
}
