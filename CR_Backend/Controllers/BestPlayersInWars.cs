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
    // base address api/bestplayersinwars
    [ApiController]
    [Route("api/[controller]")]
    public class BestPlayersInWarsController : ControllerBase
    {
        private ClashRoyaleDB db;

        public BestPlayersInWarsController(ClashRoyaleDB db){
            this.db = db;
        }

        // Esta es la query 1
        [HttpGet]
        public IEnumerable<Tuple<War, Clan, Player>> BestPlayersInWars(){

            var res = new List<Tuple<War, Clan, Player>>();

            foreach(var x in db.Wars){
                int wKey = x.WarID;

                IQueryable<WarClan> w = db.WarClans.Include(x => x.Clan).Where( x => x.WarID == wKey);
                    
                foreach(var clm in w){
                    int cmKey = clm.ClanID;

                    IQueryable<ClanMember> clanMember = db.ClanMembers.Include(x => x.Player).Where(x => x.ClanID == cmKey);

                    var best = clanMember.Select(x => x.Player).OrderBy(x => x.MaxTrophysGet).First();

                    res.Add(new Tuple<War, Clan, Player>(
                        new War {WarID = x.WarID, StartDate = x.StartDate},
                        new Clan {ClanName = clm.Clan.ClanName, ClanID = clm.ClanID},
                        new Player {PlayerID = best.PlayerID, Alias = best.Alias}
                    ));
                }
            }
            return res;
        }
    }
}