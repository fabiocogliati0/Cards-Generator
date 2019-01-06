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
        public uint MaxGenerationAttempts;
        public uint RoadsTilesToPlace;
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

        public BoardMap GenerateMap(int SizeX, int SizeY)
        {

            BoardMap boardMap = new BoardMap(SizeX, SizeY);

            int currentAttempt = 0;

            bool generationOk;

            do
            {
                generationOk = true;

                //Clear map
                boardMap.Clear();

                //Choose random  starting point on the edges
                int startPointX, startPointY;
                int edge = Globals.RandomNumberGenerator.Next(0, 4);
                switch (edge)
                {
                    case 0:
                        startPointX = 0;
                        startPointY = Globals.RandomNumberGenerator.Next(0, SizeY);
                        break;
                    case 1:
                        startPointX = SizeX - 1;
                        startPointY = Globals.RandomNumberGenerator.Next(0, SizeY);
                        break;
                    case 2:
                        startPointX = Globals.RandomNumberGenerator.Next(0, SizeX);
                        startPointY = 0;
                        break;
                    default:
                        startPointX = Globals.RandomNumberGenerator.Next(0, SizeX);
                        startPointY = SizeX - 1;
                        break;
                }
                boardMap.Tiles[startPointX, startPointY] = BoardMap.ETileType.StartPoint;


                //Place a random road
                int currentPosX = startPointX;
                int currentPosY = startPointY;
                for (var i = 0; i < _settings.RoadsTilesToPlace; ++i)
                {
                    //Calculate possible direction
                    bool[] directionOk = new bool[4];   // order = up, right, down, left
                    Point[] nextPoint = new Point[4];     // order = up, right, down, left
                    directionOk[0] = currentPosY - 1 >= 0 && boardMap.Tiles[currentPosX, currentPosY - 1] == BoardMap.ETileType.Empty;
                    directionOk[1] = currentPosX + 1 < SizeX && boardMap.Tiles[currentPosX + 1, currentPosY] == BoardMap.ETileType.Empty;
                    directionOk[2] = currentPosY + 1 < SizeY && boardMap.Tiles[currentPosX, currentPosY + 1] == BoardMap.ETileType.Empty;
                    directionOk[3] = currentPosX - 1 >= 0 && boardMap.Tiles[currentPosX - 1, currentPosY] == BoardMap.ETileType.Empty;
                    nextPoint[0] = new Point(currentPosX, currentPosY - 1);
                    nextPoint[1] = new Point(currentPosX + 1, currentPosY);
                    nextPoint[2] = new Point(currentPosX, currentPosY + 1);
                    nextPoint[3] = new Point(currentPosX - 1, currentPosY);
                    int possibleDirections = directionOk.Count(x => x == true);
                    if (possibleDirections == 0)
                    {
                        generationOk = false;
                        Console.Error.WriteLine("Generation Failed");
                        break; //impossible to continue
                    }

                    //Generate random direction
                    int selectedDirection = Globals.RandomNumberGenerator.Next(0, possibleDirections);
                    ++selectedDirection;  // ranges [1, possibleDirections]
                    int directionIndex;

                    // count "selectedDirection" good directions
                    for (directionIndex = 0; directionIndex < 4; ++directionIndex)
                    {
                        if (directionOk[directionIndex])
                        {
                            --selectedDirection;
                        }

                        if (selectedDirection == 0)
                        {
                            break;
                        }
                    }
                    // Update current position
                    currentPosX = nextPoint[directionIndex].X;
                    currentPosY = nextPoint[directionIndex].Y;

                    // assign road to selected tiles
                    boardMap.Tiles[currentPosX, currentPosY] = BoardMap.ETileType.Road;
                }

                ++currentAttempt;

            } while (!generationOk && currentAttempt < _settings.MaxGenerationAttempts);

            return boardMap;
        }


        private static CardsGeneratorManager _Instance = null;


        private CardsGeneratorSettings _settings;

        private List<Enchantment> _enchantments;

        private List<CreatureCard> _creatureCards;

        private List<EquipmentCard> _equipmentCards;

        private const int _MinTileValue = 0;

        private const int _MaxTileValue = 5;

    }
}
