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
    // base address api/succesedchallenges
    [ApiController]
    [Route("api/[controller]")]
    public class SuccesedChallengesController : ControllerBase
    {
        private ClashRoyaleDB db;

        public SuccesedChallengesController(ClashRoyaleDB db){
            this.db = db;
        }

        // Esta es la query 6
        [HttpGet]
        public IQueryable<Challenge> SuccesChallenge(){

            var res = db.PlayerChallenges.Where(x => x.PricesGained == x.Challenge.PricesOffer).Select(x => x.Challenge);
            return res.Distinct();
        }
    }
}
