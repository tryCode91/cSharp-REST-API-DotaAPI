using DotaAPI.Models;

namespace DotaAPI.Interface
{
    public interface IStatsRepository
    {
        ICollection<Stats> GetStats();
        Stats GetStats(int statsId);
        bool StatsExists(int statsId);
        bool CreateStats(Stats stats);
        bool DeleteStats(Stats stats);
        bool UpdateStats(Stats stats);
        bool HeroStatsExists(int heroId);
        Stats GetStatsByAHero(int heroId);
        bool Save();
        
    }
}
