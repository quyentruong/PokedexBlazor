using PokeApiNet;

namespace PokedexBlazor.Models;

public class PokemonLiteStat
{
    public string Name { get; set; } = string.Empty;
    public int Value { get; set; }

    public PokemonLiteStat()
    {
    }

    public PokemonLiteStat(PokemonStat _pokemonStat)
    {
        Name = _pokemonStat.Stat.Name;
        Value = _pokemonStat.BaseStat;
    }
}