using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards_Generator.Source
{

    public enum eCardRarity
    {
        Common,
        Magic,
        Rare,
        Epic
    }


    class EnchantableCard : Card
    {

        public eCardRarity Rarity;

    }
}
