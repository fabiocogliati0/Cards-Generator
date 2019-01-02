using Cards_Generator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards_Generator
{
    public enum ECardType
    {
        None,
        Creature,
        Equipment,
        //Sorcery,  // #TODO
        COUNT
    }

    public enum ECardRarity
    {
        None,
        Common,     // Rarity for base blank cards
        Magic,      
        Rare,
        //Epic,     // #TODO
        COUNT
    }


    public abstract class Card : ICloneable
    {
        public Name Name;

        public LocalizableString Title;

        public Name BaseImageKey;

        public const ECardType CardType = ECardType.None;

        public const ECardRarity Rarity = ECardRarity.None;

        public List<Enchantment> Enchantments;


        public Card()
        {
            Enchantments = new List<Enchantment>();
        }

        /// <summary>
        /// Returns a random rarity from MinRarity to MaxRarity (Lower extreme included, Upper extreme exluded)
        /// </summary>
        /// <param name="MinRarity"></param>
        /// <param name="MaxRarity"></param>
        /// <returns></returns>
        public static ECardRarity GetRandomRarity(ECardRarity MinRarity = ECardRarity.Common, ECardRarity MaxRarity = ECardRarity.COUNT)
        {
            return (ECardRarity)(Globals.RandomNumberGenerator.Next((int)MinRarity, (int)MaxRarity));
        }

        public object Clone()
        {
            Card cloned = this.MemberwiseClone() as Card;
            cloned.Enchantments = new List<Enchantment>();

            return cloned;
        }
    }
}
