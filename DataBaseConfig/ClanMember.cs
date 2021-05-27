using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBaseConfig
{
    // agragación entre clan y jugador
    public class ClanMember{
        // llave foránea
        public int PlayerID {get; set;}

        public Player Player {get; set;}

        // llave foránea
        public int ClanID {get; set;}

        public Clan Clan {get; set;}

        public string Charge {get; set;}

        public ClanMember(){
            Charge = "member";
        }
    }
}