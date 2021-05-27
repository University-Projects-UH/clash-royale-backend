using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace DataBaseConfig
{
    public class PlayerStructureCard : PlayerCard{

        [InverseProperty("PlayerStructureCards")]
        public StructureCard StructureCard {get; set;}

        [InverseProperty("PlayerStructureCards")]
        public Player Player {get; set;}

        public PlayerStructureCard(){
            InitialLevel = 1;
            ActualLevel = 1;
        }
    }
}