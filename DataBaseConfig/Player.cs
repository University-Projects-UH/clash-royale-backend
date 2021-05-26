using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace DataBaseConfig
{
    public class Player
    {
        public int PlayerID {get; set;}

        public string Alias {get; set;}

        public int Level {get; set;}

        public int TrophysCount {get; set;}

        public int VictoryCount {get; set;}

        public int CardsCount {get; set;}

        public int MaxTrophysGet {get; set;}

        public int ClanID {get; set;}

        // la tupla en clan member que representa
        public ClanMember ClanMember {get; set;}

        public int MeleeID {get; set;}

        // carta melee favorita
        [ForeignKey(nameof(MeleeID))]
        public MeleeCard MeleeCard {get; set;}

        public int SpellID {get; set;}

        // carta hechizo favorita
        [ForeignKey(nameof(SpellID))]
        public SpellCard SpellCard {get; set;}

        public int StructureID {get; set;}

        // carta estructura favorita
        [ForeignKey(nameof(StructureID))]
        public StructureCard StructureCard {get; set;}

        [InverseProperty(nameof(PlayerChallenge.Player))]
        public virtual ICollection<PlayerChallenge> PlayerChallenges {get; set;}

        public virtual ICollection<PlayerSpellCard> PlayerSpellCards {get; set;}

        public virtual ICollection<PlayerMeleeCard> PlayerMeleeCards {get; set;}
        
        public virtual ICollection<PlayerStructureCard> PlayerStructureCards {get; set;}

        public virtual ICollection<Battle> Battles {get; set;}

        public virtual ICollection<MeleeCardDonation> MeleeCardDonations {get; set;}

        public virtual ICollection<SpellCardDonation> SpellCardDonations {get; set;}

        public virtual ICollection<StructureCardDonation> StructureCardDonations {get; set;}

        public Player(){
            PlayerChallenges = new HashSet<PlayerChallenge>();
            PlayerSpellCards = new HashSet<PlayerSpellCard>();
            PlayerStructureCards = new HashSet<PlayerStructureCard>();
            PlayerMeleeCards = new HashSet<PlayerMeleeCard>();
            Battles = new HashSet<Battle>();
            MeleeCardDonations = new HashSet<MeleeCardDonation>();
            StructureCardDonations = new HashSet<StructureCardDonation>();
            SpellCardDonations = new HashSet<SpellCardDonation>();
        }
    }
}
