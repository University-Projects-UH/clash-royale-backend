using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace DataBaseConfig
{
    public abstract class PlayerCard{
        public int PlayerID {get; set;}

        public int CardID {get; set;}

        public int InitialLevel {get; set;}

        public int ActualLevel {get; set;}
    }
}