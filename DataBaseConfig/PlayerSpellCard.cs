using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace DataBaseConfig
{
    public class PlayerSpellCard : PlayerCard{

        [InverseProperty("PlayerSpellCards")]
        public SpellCard SpellCard {get; set;}

        [InverseProperty("PlayerSpellCards")]
        public Player Player {get; set;}
    }
}