using DotaAPI.Data;
using DotaAPI.Interface;
using DotaAPI.Models;

namespace DotaAPI.Repository
{
    public class CharacteristicRepository : ICharacteristicRepository
    {
        private readonly DataContext _context;

        public CharacteristicRepository(DataContext context)
        {
            _context = context;
        }

        public bool CharacteristicExists(int characteristicId)
        {
            return _context.Characteristics.Any(c => c.CharacteristicId == characteristicId);
        }

        public bool CreateCharacteristic(Characteristic characteristic)
        {
            _context.Add(characteristic);
            return Save();
        }

        public bool DeleteCharacteristic(Characteristic characteristic)
        {
            _context.Remove(characteristic);
            return Save();
        }

        public Characteristic GetCharacteristic(int characteristicId)
        {
            return _context.Characteristics.FirstOrDefault(c => c.CharacteristicId == characteristicId);
        }

        public Characteristic GetCharacteristicByAHero(int heroId)
        {
            return _context.Heroes.Where(h => h.Id == heroId).Select(c => c.Characteristic).FirstOrDefault();
        }

        public Hero GetCharacteristicByHero(int characteristicId)
        {
            return _context.Heroes.Where(h => h.Characteristic.CharacteristicId == characteristicId).FirstOrDefault();
        }

        public ICollection<Characteristic> GetCharacteristics()
        {
            return _context.Characteristics.OrderBy(c => c.CharacteristicId).ToList();
        }

        public Characteristic HeroCharacteristicExists(int heroId)
        {
            return _context.Heroes.Where(h => h.Id == heroId).Select(c => c.Characteristic).FirstOrDefault();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateCharacteristic(Characteristic characteristic)
        {
            _context.Update(characteristic);
            return Save();
        }
    }
}
