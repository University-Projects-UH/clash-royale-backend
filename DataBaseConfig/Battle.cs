using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace DataBaseConfig
{
    public class Battle
    {
        public int BattleID {get; set;}

        public int Player1ID {get; set;}

        public Player Player1 {get; set;}

        public int Player2ID {get; set;}

        public int BattleDuration {get; set;}

        public int TrophysBet {get; set;}

        public DateTime StartDate {get; set;}
    }
}
