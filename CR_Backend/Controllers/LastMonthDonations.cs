using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DataBaseConfig;
using Microsoft.EntityFrameworkCore;

namespace CR_Backend.Controllers
{
    // base address api/lastmonthdonations
    [ApiController]
    [Route("api/[controller]")]
    public class LastMonthDonationsController : ControllerBase
    {
        private ClashRoyaleDB db;

        public LastMonthDonationsController(ClashRoyaleDB db){
            this.db = db;
        }

        // Esta es la query 3
        [HttpGet]
        public IEnumerable<Tuple<Region, IEnumerable<MeleeCard>, IEnumerable<SpellCard>, IEnumerable<StructureCard>>> LastMonthDonations(){

            DateTime aMonthAgo = DateTime.Now.AddMonths(-1);
            var res = new List<Tuple<Region, IEnumerable<MeleeCard>, IEnumerable<SpellCard>, IEnumerable<StructureCard>>>();

            IQueryable<Region> reg = db.Regions.Include(x => x.Clans);

            foreach( var item in reg){
                List<Card> donation = new List<Card>();

                var mcd = db.MeleeCardDonations.AsEnumerable().Where(x => x.DonationDate >= aMonthAgo && x.RegionID == item.RegionID).Select(x => x.CardID);
                var scd = db.SpellCardDonations.AsEnumerable().Where(x => x.DonationDate >= aMonthAgo && x.RegionID == item.RegionID).Select(x => x.CardID);
                var stcd = db.StructureCardDonations.AsEnumerable().Where(x => x.DonationDate >= aMonthAgo && x.RegionID == item.RegionID).Select(x => x.CardID);

                var moreMelee = Modes(mcd);
                var moreSpell = Modes(scd);
                var moreStructure = Modes(stcd);
                List<MeleeCard> melee = new List<MeleeCard>();
                List<SpellCard> spell = new List<SpellCard>();
                List<StructureCard> structure = new List<StructureCard>();

                foreach( var id in moreMelee){
                    var c = db.MeleeCards.Where(x => x.CardID == id).First();
                    melee.Add(new MeleeCard {CardID = c.CardID, CardName = c.CardName});     
                }

                foreach( var id in moreSpell){
                    var c = db.SpellCards.Where(x => x.CardID == id).First();
                    spell.Add( new SpellCard {CardID = c.CardID, CardName = c.CardName});
                }
                foreach( var id in moreStructure){
                    var c = db.StructureCards.Where(x => x.CardID == id).First();
                    structure.Add( new StructureCard {CardID = c.CardID, CardName = c.CardName});
                }
                res.Add(new Tuple<Region, IEnumerable<MeleeCard>, IEnumerable<SpellCard>, IEnumerable<StructureCard>>(
                    new Region {RegionID = item.RegionID, RegionName = item.RegionName},
                    melee,
                    spell,
                    structure
                ));
            }
            return res;
        }
        public static List<int> Modes(IEnumerable<int> list){
            int times = 0;
            List<int> modes = new List<int>();

            IEnumerable<int> dist = list.Distinct();
            foreach( var item in dist){
                int temp = list.Where(x => x == item).Count();
                if (temp == times){
                    modes.Add(item);
                }
                if (temp > times){
                    times = temp;
                    modes = new List<int>();
                    modes.Add(item);
                }
            }
            return modes;
        }
    }
}