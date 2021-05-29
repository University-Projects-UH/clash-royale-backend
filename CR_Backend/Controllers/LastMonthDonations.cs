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
        public IEnumerable<Tuple<Region, MeleeCard, SpellCard, StructureCard>> LastMonthDonations(){

            DateTime aMonthAgo = DateTime.Now.AddMonths(-1);
            var res = new List<Tuple<Region, MeleeCard, SpellCard, StructureCard>>();

            IQueryable<Region> reg = db.Regions.Include(x => x.Clans);

            foreach( var item in reg){
                List<Card> donation = new List<Card>();

                var mcd = db.MeleeCardDonations.AsEnumerable().Where(x => x.DonationDate >= aMonthAgo && x.RegionID == item.RegionID).Select(x => x.CardID);
                var scd = db.SpellCardDonations.AsEnumerable().Where(x => x.DonationDate >= aMonthAgo && x.RegionID == item.RegionID).Select(x => x.CardID);
                var stcd = db.StructureCardDonations.AsEnumerable().Where(x => x.DonationDate >= aMonthAgo && x.RegionID == item.RegionID).Select(x => x.CardID);

                var moreMelee = Modes(mcd);
                var moreSpell = Modes(scd);
                var moreStructure = Modes(stcd);

                MeleeCard melee = null;
                if(moreMelee != -1){
                    var c = db.MeleeCards.Where(x => x.CardID == moreMelee).First();
                    melee = new MeleeCard{
                        CardID = c.CardID, 
                        CardName = c.CardName, 
                        ElixirCost = c.ElixirCost,
                        Quality = c.Quality,
                        UnitsCount = c.UnitsCount,
                        LifePoints = c.LifePoints,
                        RangeDamage = c.RangeDamage
                    };
                }
                SpellCard spell = null;
                if(moreSpell != -1){
                    var c = db.SpellCards.Where(x => x.CardID == moreSpell).First();
                    spell = new SpellCard{
                        CardID = c.CardID, 
                        CardName = c.CardName,
                        ElixirCost = c.ElixirCost,
                        Quality = c.Quality,
                        SpellDamage = c.SpellDamage,
                        SpellDuration = c.SpellDuration,
                        Radio = c.Radio
                    };
                }
                StructureCard structure = null;
                if(moreStructure != -1){
                    var c = db.StructureCards.Where(x => x.CardID == moreStructure).First();
                    structure = new StructureCard{
                        CardID = c.CardID, 
                        CardName = c.CardName,
                        ElixirCost = c.ElixirCost,
                        Quality = c.Quality,
                        LifePoints = c.LifePoints,
                        RangeDamage = c.RangeDamage,
                        AttackSpeed = c.AttackSpeed
                    };
                }

                res.Add(new Tuple<Region, MeleeCard, SpellCard, StructureCard>(
                    new Region {
                        RegionID = item.RegionID, 
                        RegionName = item.RegionName},
                    melee,
                    spell,
                    structure
                ));
            }
            return res;
        }
        public static int Modes(IEnumerable<int> list){
            int times = 0;
            int modes = -1;

            IEnumerable<int> dist = list.Distinct();
            foreach( var item in dist){
                int temp = list.Where(x => x == item).Count();
                if (temp > times){
                    times = temp;
                    modes = item;
                }
            }
            return modes;
        }
    }
}