using DotaAPI.Data;
using DotaAPI.Interface;
using DotaAPI.Models;

namespace DotaAPI.Repository
{
    public class HeroRepository : IheroRepository
    {
        private readonly DataContext _context;

        public HeroRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateHero(Hero hero)
        {
            _context.Add(hero);
            return Save();
        }

        public bool DeleteHero(Hero hero, Characteristic characteristic, Stats stats)
        {
            _context.Remove(stats);
            _context.Remove(characteristic);
            _context.Remove(hero);
            return Save();
        }

        public Hero GetHero(int heroId)
        {
            return _context.Heroes.FirstOrDefault(h => h.Id == heroId);
        }

        public Hero GetHero(string name)
        {
            return _context.Heroes.Where(h => h.Name.ToLower() == name.ToLower()).FirstOrDefault();
        }

        public ICollection<HeroAbility> GetHeroAbilities(int heroId)
        {
            return _context.HeroAbilities.Where(h => h.HeroId== heroId).ToList();
        }

        public Characteristic GetHeroCharacteristic(int heroId)
        {
            return _context.Heroes.Where(h => h.Id == heroId).Select(c => c.Characteristic).FirstOrDefault();
        }

        public ICollection<Hero> GetHeroes()
        {
            return _context.Heroes.OrderBy(h => h.Id).ToList();
        }

        public Stats GetHeroStats(int heroId)
        {
            return _context.Heroes.Where(h => h.Id == heroId).Select(s => s.Stats).FirstOrDefault();
        }

        public bool HeroExists(int heroId)
        {
            return _context.Heroes.Any(h => h.Id == heroId);
        }

        public bool HeroExists(string name)
        {
            return _context.Heroes.Any(h => h.Name.ToLower() == name.ToLower());
        }

        public bool HeroStats(int heroId)
        {
            return _context.Heroes.Select(h => h.Stats).Any();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateHero(Hero hero)
        {
            _context.Update(hero);
            return Save();
        }
    }
}
