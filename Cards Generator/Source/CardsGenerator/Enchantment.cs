using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Cards_Generator
{
    [DebuggerDisplay("{_infoString}")]
    public class Enchantment
    {

        public Name Name;

        public Name ImageKey;

        public string TextKey;

        public bool isApplicableToCreatures = true;

        public bool isApplicableToEquipments = true;



        public override string ToString()
        {
            return _infoString;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _infoString 
        {
            get
            {
                return "{ ENCHANTMENT : " + Name.ToString() + " }";
            }
        }
    }
}
