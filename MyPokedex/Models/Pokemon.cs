namespace MyPokedex.Models
{
    public class Pokemon
    {
        public int id { get; set; }
        public string entry_number { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public List<PokemonType> Types { get; set; }
        public Profile Profile { get; set; }
    }
    public class PokemonType
    {
        public int Slot { get; set; } // Per gestire l'ordine del tipo (es: primario o secondario)
        public Type Type { get; set; }
    }

    public class Type
    {
        public string Name { get; set; }
        public string Url { get; set; } // URL per dettagli ulteriori sul tipo
    }
  
    public class Profile
    {
        public string FrontDefault { get; set; }
        public string BackDefault { get; set; }
    }

}
