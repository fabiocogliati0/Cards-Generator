using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards_Generator
{

    public enum EEquipmentType
    {
        None,
        Weapon,
        Shield,
        Armor,
        Helmet,
        Gloves,
        Boots,
        Ring,
        Amulet,
        COUNT
    }


    public class EquipmentCard : Card
    {

        public EEquipmentType EquipmentType;

        public int BaseStrenght;

        public int BaseDefence;

    }
}
