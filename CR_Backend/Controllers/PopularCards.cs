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
    // base address api/popularcards
    [ApiController]
    [Route("api/[controller]")]
    public class PopularCardsController : ControllerBase
    {
        private ClashRoyaleDB db;

        public PopularCardsController(ClashRoyaleDB db){
            this.db = db;
        }

        // Esta es la query 4
        [HttpGet]
        public IEnumerable<Tuple<Clan, MeleeCard, SpellCard, StructureCard>> PopularCards(){
            
            var res = new List<Tuple<Clan, MeleeCard, SpellCard, StructureCard>>();

            IQueryable<Clan> cl = db.Clans.Include(c => c.Players);

            foreach( var item in cl){

                List<int> meleeID = new List<int>();
                List<int> spellID = new List<int>();
                List<int> structureID = new List<int>();              

                foreach(var item2 in item.Players){
                    if (item2.MeleeID != null){
                        meleeID.Add((int)(item2.MeleeID));
                    }
                    if (item2.SpellID != null){
                        spellID.Add((int)(item2.SpellID));
                    }
                    if (item2.StructureID != null){
                        structureID.Add((int)(item2.StructureID));
                    }
                }

                int favMelee = Modes(meleeID).First();
                int favSpell = Modes(spellID).First();
                int favStructure = Modes(structureID).First();

                var mc = db.MeleeCards.Where(x => x.CardID == favMelee).First();
                var sc = db.SpellCards.Where(x => x.CardID == favSpell).First();
                var stc = db.StructureCards.Where(x => x.CardID == favStructure).First();

                res.Add(new Tuple<Clan, MeleeCard, SpellCard, StructureCard>(
                    new Clan {ClanID = item.ClanID, ClanName = item.ClanName},
                    new MeleeCard {CardID = mc.CardID, CardName = mc.CardName},
                    new SpellCard {CardID = sc.CardID, CardName = sc.CardName},
                    new StructureCard {CardID = stc.CardID, CardName = stc.CardName}
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