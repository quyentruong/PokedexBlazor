using PokeApiNet;

namespace PokedexBlazor.Models;

public class PokemonLite
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string FrontDefault { get; set; } = string.Empty;
    public List<PokemonLiteType> Types { get; set; } = null!;
    public List<PokemonLiteStat> Stats { get; set; } = null!;
    public List<PokemonWeakness> Weakness { get; set; } = null!;

    public PokemonLite()
    {
    }

    public PokemonLite(Pokemon _pokemon, List<PokemonWeakness> weaknewss)
    {
        Id = _pokemon.Id;
        Name = _pokemon.Name;
        FrontDefault = _pokemon.Sprites.Other.OfficialArtwork.FrontDefault;
        Types = _pokemon.Types.Select(t => new PokemonLiteType(t)).ToList();
        Stats = _pokemon.Stats.Select(stat => new PokemonLiteStat(stat)).ToList();
        Weakness = weaknewss;
    }
}