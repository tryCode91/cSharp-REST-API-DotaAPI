using DotaAPI.Data;
using DotaAPI.Models;

namespace DotaAPI
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }
        public void SeedDataContext()
        {
            if (!dataContext.HeroAbilities.Any())
            {
                var heroAbility = new List<HeroAbility>()
                {
                    new HeroAbility()
                    {
                        Hero = new Hero()
                        {
                            Name = "Axe",
                            Characteristic = new Characteristic()
                            {
                                HP = "900",
                                Mana = "250",
                                Strength = "25",
                                Agility = "20",
                                Intelligence = "18",
                            },
                            Stats = new Stats()
                            {
                                Attack = 55,
                                AttackTime = 1.7,
                                AttackRange = 150,
                                ProjectileSpeed = 900,
                                Defence = 3.3,
                                MagicResist = "25%",
                                MovementSpeed = 315,
                                TurnRate = 0.6,
                                Vision = "1800 / 800"
                            },
                            HeroAbilities = new List<HeroAbility>()
                            {
                                new HeroAbility()
                                {
                                    Ability = new Ability()
                                    {
                                        Title = "BERSERKER'S CALL",
                                        Description = "Axe taunts nearby enemy units, forcing them to attack him at high speed, while he gains bonus armor during the duration.",
                                        IsScepterUpgradeable = false,
                                        Cooldown = "17 / 15 / 13 / 11",
                                        ManaCost = "80 / 90 / 100 / 110",

                                        AbilityDetail = new AbilityDetail()
                                        {
                                            Affects = "",
                                            DamageType = "",
                                            PiercesSpellImmunity = true,
                                            Dispellable = false,
                                            AttackDamageReduction = "",
                                            CastRangeReduction = "",
                                            Duration = "1.8 / 2.2 / 2.6 / 3",
                                            Damage = "",
                                            CastRange = "",
                                        }
                                    }
                                },
                                new HeroAbility()
                                {
                                    Ability = new Ability()
                                    {
                                        Title = "BATTLE HUNGER",
                                        Description = "Enrages an enemy unit, causing it to take damage over time until it kills another unit or the duration ends. The damage is increased by a factor of Axe's armor. The enemy is also slowed as long as they are facing away from Axe.",
                                        IsScepterUpgradeable = false,
                                        Cooldown = "20 / 15 / 10 / 5",
                                        ManaCost = "50 / 60 / 70 / 80",

                                        AbilityDetail = new AbilityDetail()
                                        {
                                            Affects = "Enemy Units",
                                            DamageType = "Physical",
                                            PiercesSpellImmunity = false,
                                            Dispellable = true,
                                            AttackDamageReduction = "",
                                            CastRangeReduction = "10 / 15 / 20 / 25",
                                            Duration = "1.8 / 2.2 / 2.6 / 3",
                                            Damage = "",
                                            CastRange = "700 / 775 / 850 / 925",
                                        }
                                    }
                                },
                                new HeroAbility()
                                {
                                    Ability = new Ability()
                                    {
                                        Title = "COUNTER HELIX",
                                        Description = "After a set number of attacks, Axe will perform a helix counter attack, dealing pure damage to all nearby enemies.",
                                        IsScepterUpgradeable = false,
                                        Cooldown = "0.3",
                                        ManaCost = "0",

                                        AbilityDetail = new AbilityDetail()
                                        {
                                            Affects = "",
                                            DamageType = "Pure",
                                            PiercesSpellImmunity = true,
                                            Dispellable = true,
                                            AttackDamageReduction = "",
                                            CastRangeReduction = "",
                                            Duration = "",
                                            Damage = "95 / 120 / 145 / 170",
                                            CastRange = "",
                                        }
                                    }
                                },
                                new HeroAbility()
                                {
                                    Ability = new Ability()
                                    {
                                        Title = "CULLING BLADE",
                                        Description = "Axe spots a weakness and strikes, dealing pure damage. When an enemy hero is killed with Culling Blade, its cooldown is reset, Axe gains bonus armor permanently and all nearby allied units gain bonus movement speed and armor.",
                                        IsScepterUpgradeable = false,
                                        Cooldown = "100 / 85 / 70",
                                        ManaCost = "100 / 125 / 150",

                                        AbilityDetail = new AbilityDetail()
                                        {
                                            Affects = "Enemy Units",
                                            DamageType = "Pure",
                                            PiercesSpellImmunity = true,
                                            Dispellable = true,
                                            AttackDamageReduction = "",
                                            CastRangeReduction = "",
                                            Duration = "",
                                            Damage = "275 / 375 / 475",
                                            CastRange = "",
                                        }
                                    }
                                },
                                new HeroAbility()
                                {
                                    Ability = new Ability()
                                    {
                                        Title = "BERSERKER'S CALL(Scepter ability upgrade)",
                                        Description = "Berserker's Call applies Battle Hunger to affected units. Reduces Berserker's Call cooldown.",
                                        IsScepterUpgradeable = true,
                                        Cooldown = "17 / 15 / 13 / 11",
                                        ManaCost = "80 / 90 / 100 / 110",

                                        AbilityDetail = new AbilityDetail()
                                        {
                                            Affects = "Enemy Units",
                                            DamageType = "",
                                            PiercesSpellImmunity = false,
                                            Dispellable = false,
                                            AttackDamageReduction = "",
                                            CastRangeReduction = "",
                                            Duration = "",
                                            Damage = "275 / 375 / 475",
                                            CastRange = "",
                                        }
                                    }
                                }
                            }
                        },
                        Ability = new Ability()
                        {
                            Title = "BATTLE HUNGER",
                            Description = "Enrages an enemy unit, causing it to take damage over time until it kills another unit or the duration ends. The damage is increased by a factor of Axe's armor. The enemy is also slowed as long as they are facing away from Axe.",
                            IsScepterUpgradeable = false,
                            Cooldown = "20 / 15 / 10 / 5",
                            ManaCost = "50 / 60 / 70 / 80",

                            AbilityDetail = new AbilityDetail()
                            {
                                Affects = "Enemy Units",
                                DamageType = "Physical",
                                PiercesSpellImmunity = false,
                                Dispellable = true,
                                AttackDamageReduction = "",
                                CastRangeReduction = "",
                                Duration = "1.8 / 2.2 / 2.6 / 3",
                                Damage = "10 / 15 / 20 / 25",
                                CastRange = "700 / 775 / 850 / 925",
                            }
                        }
                    },

                    new HeroAbility()
                    {
                        Hero = new Hero()
                        {
                            Name = "Anti-Mage",
                            Characteristic = new Characteristic()
                            {
                                HP = "538",
                                Mana = "219",
                                Strength = "19",
                                Agility = "24",
                                Intelligence = "12",
                            },
                            Stats = new Stats()
                            {
                                Attack = 53-57,
                                AttackTime = 1.4,
                                AttackRange = 150,
                                ProjectileSpeed = 0,
                                Defence = 5.0,
                                MagicResist = "25%",
                                MovementSpeed = 310,
                                TurnRate = 0.6,
                                Vision = "1800 / 800"
                            },
                            HeroAbilities = new List<HeroAbility>()
                            {
                                new HeroAbility()
                                {
                                    Ability = new Ability()
                                    {
                                        Title = "MANA BREAK",
                                        Description = "Burns an opponent's mana on each attack and deals damage equal to a percentage of the mana burnt. Enemies with no mana left are temporarily slowed.",
                                        IsScepterUpgradeable = false,
                                        Cooldown = "0",
                                        ManaCost = "0",

                                        AbilityDetail = new AbilityDetail()
                                        {
                                            Affects = "",
                                            DamageType = "Physical",
                                            PiercesSpellImmunity = false,
                                            Dispellable = false,
                                            AttackDamageReduction = "",
                                            CastRangeReduction = "",
                                            Duration = "0.75",
                                            Damage = "",
                                            CastRange = "",
                                        }
                                    }
                                },
                                new HeroAbility()
                                {
                                    Ability = new Ability()
                                    {
                                        Title = "COUNTERSPELL",
                                        Description = "Passively grants magic resistance. Counterspell may be activated to create an anti-magic shell around Anti-Mage that blocks and sends any targeted spells back towards enemies instead.",
                                        IsScepterUpgradeable = false,
                                        Cooldown = "15 / 11 / 7 / 3",
                                        ManaCost = "45",

                                        AbilityDetail = new AbilityDetail()
                                        {
                                            Affects = "",
                                            DamageType = "Physical",
                                            PiercesSpellImmunity = false,
                                            Dispellable = true,
                                            AttackDamageReduction = "",
                                            CastRangeReduction = "",
                                            Duration = "1.2",
                                            Damage = "",
                                            CastRange = "",
                                        }
                                    }
                                },
                                new HeroAbility()
                                {
                                    Ability = new Ability()
                                    {
                                        Title = "MANA VOID",
                                        Description = "For each point of mana missing by the target unit, damage is dealt to it and surrounding enemies.  The main target is also mini-stunned.",
                                        IsScepterUpgradeable = false,
                                        Cooldown = "70",
                                        ManaCost = "100 / 150 / 200",

                                        AbilityDetail = new AbilityDetail()
                                        {
                                            Affects = "Unit Target",
                                            DamageType = "Magical",
                                            PiercesSpellImmunity = false,
                                            Dispellable = false,
                                            AttackDamageReduction = "",
                                            CastRangeReduction = "",
                                            Duration = "0.3",
                                            Damage = "0.8 / 0.95 / 1.1",
                                            CastRange = "",
                                        }
                                    }
                                },
                                new HeroAbility()
                                {
                                    Ability = new Ability()
                                    {
                                        Title = "BLINK FRAGMENT",
                                        Description = "Blinks an illusion to the target enemy or location, which attacks for a brief time. Counterspell is replicated on the Blink Fragment illusion. Has 3 Charges.",
                                        IsScepterUpgradeable = true,
                                        Cooldown = "45",
                                        ManaCost = "0",

                                        AbilityDetail = new AbilityDetail()
                                        {
                                            Affects = "Enemy Units",
                                            DamageType = "Magical",
                                            PiercesSpellImmunity = false,
                                            Dispellable = false,
                                            AttackDamageReduction = "",
                                            CastRangeReduction = "",
                                            Duration = "7",
                                            Damage = "25%",
                                            CastRange = "",
                                        }
                                    }
                                },
                                new HeroAbility()
                                {
                                    Ability = new Ability()
                                    {
                                        Title = "BLINK",
                                        Description = "Short distance teleportation that allows Anti-Mage to move in and out of combat.",
                                        IsScepterUpgradeable = false,
                                        Cooldown = "13.5 / 11 / 8.5 / 6",
                                        ManaCost = "45",

                                        AbilityDetail = new AbilityDetail()
                                        {
                                            Affects = "",
                                            DamageType = "Point Target",
                                            PiercesSpellImmunity = false,
                                            Dispellable = false,
                                            AttackDamageReduction = "",
                                            CastRangeReduction = "",
                                            Duration = "",
                                            Damage = "",
                                            CastRange = "750 / 900 / 1050 / 1200",
                                        }
                                    }
                                },
                            }
                        },
                        Ability = new Ability()
                        {
                            Title = "COUNTERSPELL ALLY",
                            Description = "Counterspell Ally may be activated to create an anti-magic shell around an allied hero that blocks and sends any targeted spells back towards enemies instead. Any time a spell is reflected by Counterspell or Counterspell Ally, an illusion of Anti-Mage will be created next to the enemy.",
                            IsScepterUpgradeable = true,
                            Cooldown = "3",
                            ManaCost = "45",

                            AbilityDetail = new AbilityDetail()
                            {
                                Affects = "Allied Heroes",
                                DamageType = "",
                                PiercesSpellImmunity = false,
                                Dispellable = true,
                                AttackDamageReduction = "",
                                CastRangeReduction = "",
                                Duration = "",
                                Damage = "",
                                CastRange = "",
                            }
                        }
                    }


                };
                dataContext.HeroAbilities.AddRange(heroAbility);
                dataContext.SaveChanges();
            }
        }
    }
}