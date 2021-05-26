using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace DataBaseConfig
{
    public class PlayerChallenge{
        public int PlayerID {get; set;}

        [InverseProperty("PlayerChallenges")]
        public Player Player {get; set;}

        public int ChallengeID {get; set;}

        [InverseProperty("PlayerChallenges")]
        public Challenge Challenge {get; set;}

        public int PricesGained {get; set;}
    }
}