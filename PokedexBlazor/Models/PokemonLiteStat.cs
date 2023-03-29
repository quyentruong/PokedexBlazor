using PokeApiNet;

namespace PokedexBlazor.Models;

public class PokemonLiteStat
{
    public string N { get; set; } = string.Empty;
    public int V { get; set; }

    public PokemonLiteStat()
    {
    }

    public PokemonLiteStat(PokemonStat _pokemonStat)
    {
        N = _pokemonStat.Stat.Name;
        V = _pokemonStat.BaseStat;
    }
}