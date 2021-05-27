using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace DataBaseConfig
{
    public class StructureCard : Card{
        public int LifePoints {get; set;}

        public decimal RangeDamage {get; set;}

        public int AttackSpeed {get; set;}

        public virtual IEnumerable<PlayerStructureCard> PlayerStructureCards {get; set;}

        public virtual IEnumerable<Player> Players {get; set;}

        public virtual IEnumerable<StructureCardDonation> StructureCardDonations {get; set;}

        public StructureCard(){
            PlayerStructureCards = new HashSet<PlayerStructureCard>();
            Players = new HashSet<Player>();
            StructureCardDonations = new HashSet<StructureCardDonation>();

            CardDescription = "Structure Card";
            ElixirCost = 1;
            Quality = "common";
            LifePoints = 1;
            RangeDamage = 1;
            AttackSpeed = 1;
        }
    }
}