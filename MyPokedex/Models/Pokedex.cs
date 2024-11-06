using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace MyPokedex.Models
{
    public class Description
    {
        public string description { get; set; }
        public Language language { get; set; }
    }

    public class Language
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Name
    {
        public Language language { get; set; }
        public string name { get; set; }
    }

    public class PokemonEntry
    {
        public int entry_number { get; set; }
        public PokemonSpecies pokemon_species { get; set; }
    }

    public class PokemonSpecies
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Region
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Pokedex
    {
        public List<Description> descriptions { get; set; }
        public int id { get; set; }
        public bool is_main_series { get; set; }
        public string name { get; set; }
        public List<Name> names { get; set; }
        public List<PokemonEntry> pokemon_entries { get; set; }
        public Region region { get; set; }
        public List<VersionGroup> version_groups { get; set; }
    }

    public class VersionGroup
    {
        public string name { get; set; }
        public string url { get; set; }
    }


}
