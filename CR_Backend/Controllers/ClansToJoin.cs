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
    // base address api/clanstojoin
    [ApiController]
    [Route("api/[controller]")]
    public class ClansToJoinController : ControllerBase
    {
        private ClashRoyaleDB db;

        public ClansToJoinController(ClashRoyaleDB db){
            this.db = db;
        }

        // Esta es la query 5
        [HttpGet]
        public IEnumerable<Clan> ClansToJoin(string name){

            var players = db.Players.Where(x => x.Alias == name);

            var res = new List<Clan>();

            if(players.Count() == 0){
                return null;
            }
            int trophys = players.First().MaxTrophysGet;

            var posibleClans =  db.Clans.Where(x => x.NecesaryTrophys <= trophys).AsEnumerable();

            foreach(var item in posibleClans){
                res.Add(new Clan {
                    ClanID = item.ClanID, 
                    ClanName = item.ClanName, 
                    ClanDescription = item.ClanDescription, 
                    NecesaryTrophys = item.NecesaryTrophys, 
                    TrophysGetCount = item.TrophysGetCount, 
                    Type = item.Type, 
                    MembersCount = item.MembersCount});
            }
            return res;
        }
    }
}