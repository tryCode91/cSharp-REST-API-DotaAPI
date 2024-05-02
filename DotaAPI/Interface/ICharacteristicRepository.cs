using DotaAPI.Models;

namespace DotaAPI.Interface
{
    public interface ICharacteristicRepository
    {
        ICollection<Characteristic> GetCharacteristics();
        Characteristic GetCharacteristic(int characteristicId);
        bool CreateCharacteristic(Characteristic characteristic);
        bool CharacteristicExists(int characteristicId);
        Characteristic HeroCharacteristicExists(int heroId);
        bool DeleteCharacteristic(Characteristic characteristic);
        bool UpdateCharacteristic(Characteristic characteristic);
        Hero GetCharacteristicByHero(int characteristicId);
        Characteristic GetCharacteristicByAHero(int heroId);
        bool Save();
    }
}
