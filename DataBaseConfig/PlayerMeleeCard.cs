using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace DataBaseConfig
{
    public class PlayerMeleeCard : PlayerCard{

        [InverseProperty("PlayerMeleeCards")]
        public MeleeCard MeleeCard {get; set;}

        [InverseProperty("PlayerMeleeCards")]
        public Player Player {get; set;}
    }
}