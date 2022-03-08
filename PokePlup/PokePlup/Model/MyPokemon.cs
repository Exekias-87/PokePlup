using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PokePlup.Model
{
    public class MyPokemon
    {
        [PrimaryKey,AutoIncrement]

        public int ID { get; set; }
        public string Nom { get; set; }
        public string image { get; set; }
        public string Type { get; set; }
        public string Type2 { get; set; }
        public string Description { get; set; }
        public int HP { get; set; }
        public int ATK { get; set; }
        public int DEF { get; set; }
        public int SATK { get; set; }
        public int SDEF { get; set; }
    }
}
