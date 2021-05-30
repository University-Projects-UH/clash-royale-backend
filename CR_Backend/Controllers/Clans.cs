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
    // base address api/players
    [ApiController]
    [Route("api/[controller]")]
    public class ClansController : ControllerBase
    {
        private ClashRoyaleDB db;

        public ClansController(ClashRoyaleDB db){
            this.db = db;
        }

        // Esta es la query 5
        [HttpGet]
        public IEnumerable<Clan> Clans(){
            var res = new List<Clan>();

            foreach(var item in db.Clans){
                res.Add(new Clan{
                    ClanID = item.ClanID,
                    ClanName = item.ClanName,
                    ClanDescription = item.ClanDescription,
                    MembersCount = item.MembersCount,
                    NecesaryTrophys = item.NecesaryTrophys,
                    TrophysGetCount = item.TrophysGetCount,
                    Type = item.Type
                });
            }
            return res;

        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Clan))]
        [ProducesResponseType(400)]
        public void Create([FromBody] Clan c){
            if (c == null){
                BadRequest();
                return;
            }
            if(!ModelState.IsValid){
                BadRequest();
                return;
            }

            db.Clans.Add(c);
            int state = db.SaveChanges();
            if (state == 1){
                return;
            }
            BadRequest();
        }
    }
}