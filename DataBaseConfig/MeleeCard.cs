using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace DataBaseConfig
{
    public class MeleeCard : Card{
        public int LifePoints {get; set;}

        public int RangeDamage {get; set;}

        public int UnitsCount {get; set;}

        public virtual IEnumerable<Player> Players {get; set;}

        public virtual IEnumerable<PlayerMeleeCard> PlayerMeleeCards {get; set;}

        public virtual IEnumerable<MeleeCardDonation> MeleeCardDonations {get; set;}

        public MeleeCard(){
            PlayerMeleeCards = new HashSet<PlayerMeleeCard>();
            Players = new HashSet<Player>();
            MeleeCardDonations = new HashSet<MeleeCardDonation>();

            CardDescription = "Melee Card";
            ElixirCost = 1;
            Quality = "common";
            LifePoints = 1;
            RangeDamage = 1;
            UnitsCount = 1;
        }
    }
}