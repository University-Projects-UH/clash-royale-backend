using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace DataBaseConfig
{
    public class Challenge{
        public int ChallengeID {get; set;}

        public string ChallengeName {get; set;}

        public string ChallengeDescription {get; set;}

        public int Cost {get; set;}

        public int PricesOffer {get; set;}

        public int ChallengeDuration {get; set;}

        public int MinLevel {get; set;}

        public int DefeatCount {get; set;}

        public virtual ICollection<PlayerChallenge> PlayerChallenges {get; set;}

        public Challenge(){
            PlayerChallenges = new HashSet<PlayerChallenge>();
        }
    }
}