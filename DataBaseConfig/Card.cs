using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace DataBaseConfig
{
    public abstract class Card{
        public int CardID {get; set;}

        public string CardName {get; set;}

        public string CardDescription {get; set;}

        public int ElixirCost {get; set;}

        public string Quality {get; set;}
    }
}