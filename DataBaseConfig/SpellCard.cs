using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace DataBaseConfig
{
    public class SpellCard : Card{
        public int Radio {get; set;}

        public decimal SpellDuration {get; set;}

        public int SpellDamage {get; set;}

        public virtual IEnumerable<Player> Players {get; set;}

        public virtual IEnumerable<PlayerSpellCard> PlayerSpellCards {get; set;}

        public virtual IEnumerable<SpellCardDonation> SpellCardDonations {get; set;}

        public SpellCard(){
            PlayerSpellCards = new HashSet<PlayerSpellCard>();
            Players = new HashSet<Player>();
        }
    }
}