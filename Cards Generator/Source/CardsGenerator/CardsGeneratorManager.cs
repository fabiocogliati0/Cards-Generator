using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Cards_Generator
{
    public struct CardsGeneratorSettings
    {
        public Dictionary<ECardRarity, uint> EnchantmentsNumberPerRarity;
        public int MapSizeX;
        public int MapSizeY;
        public uint MaxGenerationAttempts;
        public uint RoadsTilesToPlace;
        public uint MinRoadsDistance;
        public uint MinNumberOfRoadsForks;
        public uint MaxNumberOfRoadsForks;
        public uint MinNumberOfMonsters;
        public uint MaxNumberOfMonsters;
        public uint MinNumberOfShops;
        public uint MaxNumberOfShops;

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

        public BoardMap GenerateMap()
        {

            BoardMap boardMap = new BoardMap(_settings.MapSizeX, _settings.MapSizeY);

            int currentAttempt = 0;

            bool generationOk;

            do
            {
                generationOk = true;

                // Create a map that will contains the validity of each direction
                Dictionary<BoardMap.EDirection, bool> validDirection = new Dictionary<BoardMap.EDirection, bool>();

                //Clear map
                boardMap.Clear();

                //Choose random starting point on the edges
                BoardPoint startPoint = boardMap.GetRandomEdgePosition();
                boardMap.SetTile(startPoint, BoardMap.ETileType.StartPoint);


                // Generate roads
                BoardPoint currentPos = startPoint;
                for (var i = 0; i < _settings.RoadsTilesToPlace; ++i)
                {
                    //Calculate possible directions
                    int possibleDirections = 0;
                    for (var dirI = 0; dirI < (uint)BoardMap.EDirection.COUNT; ++dirI)
                    {
                        BoardMap.EDirection direction = (BoardMap.EDirection)dirI;
                        bool validDir = validDirection[direction] = boardMap.IsClearDirection(currentPos, direction);
                        if(validDir)
                        {
                            ++possibleDirections;
                        }
                    }

                    if (possibleDirections > 0)
                    {
                        BoardMap.EDirection randomValidDirection = GetRandomValidDirection(validDirection, possibleDirections);

                        // Set this position neighbors unusable
                        boardMap.setNeighborsUnusableIfEmpty(currentPos);

                        // Update current position
                        currentPos = boardMap.GetNextTilePosition(currentPos, randomValidDirection);

                        // assign road to selected tiles
                        boardMap.SetTile(currentPos, BoardMap.ETileType.Road);
                    }
                    else
                    {
                        generationOk = false;
                        Console.Error.WriteLine("Generation Failed");
                        break; //impossible to continue
                    }
                }

                ++currentAttempt;

            } while (!generationOk && currentAttempt < _settings.MaxGenerationAttempts);


            return boardMap;
        }


        private BoardMap.EDirection GetRandomValidDirection(Dictionary<BoardMap.EDirection,bool> validDirectionMap, int validDirections)
        {
            int selectedDir = 0;

            if (validDirections > 0)
            {
                //Generate random direction
                int directionsRemains = Globals.RandomNumberGenerator.Next(0, validDirections);
                ++directionsRemains;  // ranges [1, validDirections]

                // count "selectedDirection" good directions
                for (selectedDir = 0; selectedDir < (uint)BoardMap.EDirection.COUNT; ++selectedDir)
                {
                    if (validDirectionMap[(BoardMap.EDirection)selectedDir])
                    {
                        --directionsRemains;
                    }

                    if (directionsRemains == 0)
                    {
                        break;
                    }
                }
            }

            return (BoardMap.EDirection)selectedDir;
        }


        private static CardsGeneratorManager _Instance = null;


        private CardsGeneratorSettings _settings;

        private List<Enchantment> _enchantments;

        private List<CreatureCard> _creatureCards;

        private List<EquipmentCard> _equipmentCards;

    }
}
