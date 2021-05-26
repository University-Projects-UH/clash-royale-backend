using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace DataBaseConfig
{
    public abstract class Donation{
        public int DonationID {get; set;}

        public int CardID {get; set;}

        public int ClanID {get; set;}

        public int PlayerID {get; set;}

        public int RegionID {get; set;}

        public DateTime DonationDate {get; set;}
    }
}