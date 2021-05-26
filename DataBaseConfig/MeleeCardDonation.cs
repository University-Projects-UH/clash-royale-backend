using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace DataBaseConfig
{
    public class MeleeCardDonation : Donation{
        public Clan Clan {get; set;}

        public MeleeCard MeleeCard {get; set;}

        public Player Player {get; set;}

        public Region Region {get; set;}
    }
}