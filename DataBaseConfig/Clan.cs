using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace DataBaseConfig
{
    public class Clan{
        public int ClanID {get; set;}

        public string ClanName {get; set;}

        public string ClanDescription {get; set;}

        public string Type {get; set;}

        public int MembersCount {get; set;}

        public int TrophysGetCount {get; set;}

        public int NecesaryTrophys {get; set;}

        public int RegionID {get; set;}

        public Region Region {get; set;}

        // los miembros del clan
        [InverseProperty(nameof(ClanMember.Clan))]
        public virtual ICollection<ClanMember> ClanMembers {get; set;}

        [InverseProperty(nameof(WarClan.Clan))]
        public virtual ICollection<WarClan> WarClans {get; set;}

        public virtual ICollection<MeleeCardDonation> MeleeCardDonations {get; set;}

        public virtual ICollection<SpellCardDonation> SpellCardDonations {get; set;}

        public virtual ICollection<StructureCardDonation> StructureCardDonations {get; set;}

        public Clan(){
            ClanMembers = new HashSet<ClanMember>();
            WarClans = new HashSet<WarClan>();
            MeleeCardDonations = new HashSet<MeleeCardDonation>();
            SpellCardDonations = new HashSet<SpellCardDonation>();
            StructureCardDonations = new HashSet<StructureCardDonation>();
        }
    }
}