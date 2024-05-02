using DotaAPI.Data;
using DotaAPI.Interface;
using DotaAPI.Models;

namespace DotaAPI.Repository
{
    public class StatsRepository : IStatsRepository
    {
        private readonly DataContext _context;

        public StatsRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateStats(Stats stats)
        {
            _context.Add(stats);

            return Save();
        }

        public bool DeleteStats(Stats stats)
        {
            _context.Remove(stats);
            return Save();
        }

        public ICollection<Stats> GetStats()
        {
            return _context.Stats.OrderBy(s => s.StatsId).ToList();
        }

        public Stats GetStats(int statsId)
        {
            return _context.Stats.FirstOrDefault(s => s.StatsId == statsId);
        }

        public Stats GetStatsByAHero(int heroId)
        {
            return _context.Heroes.Where(h => h.Id == heroId).Select(s => s.Stats).FirstOrDefault();    
        }

        public bool HeroStatsExists(int heroId)
        {
            return _context.Stats.Where(s => s.HeroId == heroId).Any();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool StatsExists(int statsId)
        {
            return _context.Stats.Any(s => s.StatsId == statsId);
        }

        public bool UpdateStats(Stats stats)
        {
            _context.Update(stats);
            return Save();
        }
    }
}
