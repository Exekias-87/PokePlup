using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PokePlup.Model
{
    //Model de notre pokémon, il possède des informations de bases, ainsi que quelques autres plus spécifiques
    public class MyPokemon
    {
        [PrimaryKey,AutoIncrement]

        public int ID { get; set; }
        public string Nom { get; set; }
        public string Image { get; set; }
        public string ImageShiny { get; set; }
        public string Type { get; set; }
        public string Type2 { get; set; }
        public string CouleurType { get; set; }
        public string Description { get; set; }
        public int HP { get; set; }
        public int ATK { get; set; }
        public int DEF { get; set; }
        public int SATK { get; set; }
        public int SDEF { get; set; }
    }
}
