using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace DataBaseConfig
{
    public class War{
        public int WarID {get; set;}

        [Column(TypeName = "datetime")]
        public DateTime? StartDate {get; set;}

        [InverseProperty(nameof(WarClan.War))]
        public virtual ICollection<WarClan> WarClans {get; set;}

        public War(){
            WarClans = new HashSet<WarClan>();
        }
    }
}