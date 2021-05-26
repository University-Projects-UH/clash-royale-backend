using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace DataBaseConfig
{
    public class Region{
        public int RegionID {get; set;}

        public string RegionName {get; set;}

        public virtual IEnumerable<Clan> Clans {get; set;}

        public virtual IEnumerable<MeleeCardDonation> MeleeCardDonations {get; set;}

        public virtual IEnumerable<SpellCardDonation> SpellCardDonations {get; set;}

        public virtual IEnumerable<StructureCardDonation> StructureCardDonations {get; set;}

        public Region(){
            Clans = new HashSet<Clan>();
            MeleeCardDonations = new HashSet<MeleeCardDonation>();
            SpellCardDonations = new HashSet<SpellCardDonation>();
            StructureCardDonations = new HashSet<StructureCardDonation>();
        }
    }
}