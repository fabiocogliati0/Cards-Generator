using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Cards_Generator
{
    public struct CardsGeneratorSettings
    {
        public Dictionary<ECardRarity, uint> EnchantmentsNumberPerRarity;
    }


    public class CardsGeneratorManager
    {

        public static CardsGeneratorManager GetInstance()
        {
            if(_Instance == null)
            {
                _Instance = new CardsGeneratorManager();
            }

            return _Instance;
        }


        private CardsGeneratorManager()
        {

        }

        public void LoadData()
        {

            // Load all data
            try
            {
                // Load cards generator setting
                using (StreamReader reader = new StreamReader(Paths.CardsGeneratorSettingsDataPath))
                {
                    string json = reader.ReadToEnd();
                    _settings = JsonConvert.DeserializeObject<CardsGeneratorSettings>(json);

                } 
                
                // Load enchantments
                using (StreamReader reader = new StreamReader(Paths.EnchantmentsDataPath))
                {
                    string json = reader.ReadToEnd();
                    _enchantments = JsonConvert.DeserializeObject<List<Enchantment>>(json);

                }

                // Load creatures card
                using (StreamReader reader = new StreamReader(Paths.CreatureCardsDataPath))
                {
                    string json = reader.ReadToEnd();
                    _creatureCards = JsonConvert.DeserializeObject<List<CreatureCard>>(json);

                }

                // Load equipments card
                using (StreamReader reader = new StreamReader(Paths.EquipmentCardsDataPath))
                {
                    string json = reader.ReadToEnd();
                    _equipmentCards = JsonConvert.DeserializeObject<List<EquipmentCard>>(json);

                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public CardClass GenerateRandomCard<CardClass>(ECardRarity rarity) where CardClass : Card
        {
            CardClass generatedCard = default(CardClass);

            if(typeof(CardClass) == typeof(CreatureCard))
            {
                if (_creatureCards.Count > 0)
                {
                    int selectedCard = Globals.RandomNumberGenerator.Next(0, _creatureCards.Count);
                    generatedCard = GenerateCard<CardClass>(_creatureCards[selectedCard], rarity);
                }
            }
            else if(typeof(CardClass) == typeof(EquipmentCard))
            {
                if (_equipmentCards.Count > 0)
                {
                    int selectedCard = Globals.RandomNumberGenerator.Next(0, _equipmentCards.Count);
                    generatedCard = GenerateCard<CardClass>(_equipmentCards[selectedCard], rarity);
                }
            }

            return generatedCard;
        }

        public CardClass GenerateCard<CardClass>(Card baseCard, ECardRarity rarity) where CardClass : Card
        {
            Card generatedCard = null;

            if (baseCard != null)
            {
                generatedCard = baseCard.Clone() as Card;

                // Enchant card
                if (_settings.EnchantmentsNumberPerRarity.ContainsKey(rarity))
                {
                    uint numberOfEnchantments = _settings.EnchantmentsNumberPerRarity[rarity];

                    int[] selectedEnchantments = Globals.GenerateUniqueRandomNumbers(numberOfEnchantments, 0, _enchantments.Count);

                    if (selectedEnchantments != null)
                    {
                        for (var i = 0; i < numberOfEnchantments; ++i)
                        {
                            generatedCard.Enchantments.Add(_enchantments[selectedEnchantments[i]]);
                        }
                    }
                    else
                    {
                        Console.Error.WriteLine("Error during generation of a card, not enough enchantments in DB");
                    }
                }
                else
                {
                    Console.Error.WriteLine("Error during generation of a card, rarity not found : " + rarity.ToString());
                }
            }
            else
            {
                Console.Error.WriteLine("Error during generation of card creature, null base card");
            }

            return (CardClass)(Convert.ChangeType(generatedCard, typeof(CardClass)));
        }



        private static CardsGeneratorManager _Instance = null;


        private CardsGeneratorSettings _settings;

        private List<Enchantment> _enchantments;

        private List<CreatureCard> _creatureCards;

        private List<EquipmentCard> _equipmentCards;

    }
}
