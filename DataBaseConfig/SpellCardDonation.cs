using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace DataBaseConfig
{
    public class SpellCardDonation : Donation{
        public Clan Clan {get; set;}

        public SpellCard SpellCard {get; set;}

        public Player Player {get; set;}

        public Region Region {get; set;}
    }
}