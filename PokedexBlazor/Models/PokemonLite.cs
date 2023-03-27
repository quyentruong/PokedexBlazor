using PokeApiNet;

namespace PokedexBlazor.Models;

public class PokemonLite
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<PokemonType> Types { get; set; }
    public string FrontDefault { get; set; } = string.Empty;

    public PokemonLite()
    {
        Types = new List<PokemonType>();
    }

    public PokemonLite(int id, string name, List<PokemonType> types, string frontDefault)
    {
        Id = id;
        Name = name;
        Types = types;
        FrontDefault = frontDefault;
    }
}