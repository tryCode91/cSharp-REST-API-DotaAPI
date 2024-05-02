using DotaAPI.Data;
using DotaAPI.Interface;
using DotaAPI.Models;

namespace DotaAPI.Repository
{
    public class AbilityDetailRepository : IAbilityDetailRepository
    {
        private readonly DataContext _context;

        public AbilityDetailRepository(DataContext context)
        {
            _context = context;
        }

        public bool AbilityDetailExists(int abilityDetailId)
        {
            return _context.AbilityDetails.Any(ad => ad.AbilityDetailId == abilityDetailId);
        }

        public AbilityDetail AbilityHaveDetails(int abilityId)
        {
            return _context.Abilities.Where(a => a.AbilityId == abilityId).Select(ad => ad.AbilityDetail).FirstOrDefault();
        }

        public bool CreateAbilityDetail(AbilityDetail abilityDetail)
        {
            _context.Add(abilityDetail);
            return Save();
        }

        public bool DeleteAbilityDetail(AbilityDetail abilityDetail)
        {
            _context.Remove(abilityDetail);
            return Save();
        }

        public Ability GetAbilityByDetail(int abilityDetailId)
        {
            return _context.AbilityDetails.Where(ad => ad.AbilityDetailId == abilityDetailId).Select(a => a.Ability).FirstOrDefault();
        }

        public AbilityDetail GetAbilityDetail(int abilityDetailId)
        {
            return _context.AbilityDetails.FirstOrDefault(ad => ad.AbilityDetailId == abilityDetailId);
        }

        public ICollection<AbilityDetail> GetAbilityDetails()
        {
            return _context.AbilityDetails.OrderBy(ad => ad.AbilityDetailId).ToList();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateAbilityDetail(AbilityDetail abilityDetail)
        {
            _context.Update(abilityDetail);
            return Save();
        }
    }
}
