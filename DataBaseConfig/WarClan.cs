using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace DataBaseConfig
{
    public class WarClan{
        public int WarID {get; set;}

        [InverseProperty("WarClans")]
        public War War {get; set;}

        public int ClanID {get; set;}

        [InverseProperty("WarClans")]
        public Clan Clan {get; set;}

        public int PricesGained {get; set;}
    }
}