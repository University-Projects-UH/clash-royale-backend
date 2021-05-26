using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DataBaseConfig;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace CR_Backend.Controllers
{
    // base address api/bestclans
    [ApiController]
    [Route("api/[controller]")]
    public class BestClansController : ControllerBase
    {
        private ClashRoyaleDB db;

        public BestClansController(ClashRoyaleDB db){
            this.db = db;
        }

        // Esta es la query 2
        [HttpGet]
        public IEnumerable<Tuple<Region, Clan>> BestClans(){

            var res = new List<Tuple<Region, Clan>>();

            IQueryable<Region> r = db.Regions.Include(x => x.Clans);
            foreach( var x in r){

                if (x.Clans.Count() > 0){
                    var c = x.Clans.OrderBy(x => x.TrophysGetCount).First();

                    res.Add(new Tuple<Region, Clan>(
                        new Region {RegionID = x.RegionID, RegionName = x.RegionName},
                        new Clan {ClanID = c.ClanID, ClanName = c.ClanName})
                    );
                }
            }
            return res;
        }
    }
}