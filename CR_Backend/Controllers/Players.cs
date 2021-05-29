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
    public class PlayersController : ControllerBase
    {
        private ClashRoyaleDB db;

        public PlayersController(ClashRoyaleDB db){
            this.db = db;
        }

        // Esta es la query 5
        [HttpGet]
        public IEnumerable<Player> Players(){
            var res = new List<Player>();

            foreach(var item in db.Players){
                res.Add(new Player{
                    PlayerID = item.PlayerID,
                    Alias = item.Alias,
                    VictoryCount = item.VictoryCount,
                    TrophysCount = item.TrophysCount,
                    MaxTrophysGet = item.MaxTrophysGet,
                    Level = item.Level,
                    MeleeID = item.MeleeID,
                    SpellID = item.SpellID,
                    StructureID = item.StructureID,
                    CardsCount = item.CardsCount
                });
            }
            return res;

        }
    }
}