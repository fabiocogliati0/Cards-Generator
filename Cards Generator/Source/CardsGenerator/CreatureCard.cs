﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards_Generator
{
    public class CreatureCard : Card
    {
        public new const ECardType CardType = ECardType.Creature;

        public int Strength;

        public int Defence;
        
    }
}
