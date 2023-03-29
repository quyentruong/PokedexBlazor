using PokeApiNet;
using System.Collections.Generic;

namespace PokedexBlazor.Models;

public class PokemonLite
{
    public int Id { get; set; }

    // Name
    public string N { get; set; } = string.Empty;

    // https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/official-artwork/{id}.png
    //public string FrontDefault { get; set; } = string.Empty;
    // Type
    public List<string> Ts { get; set; } = null!;

    // Stat
    public List<PokemonLiteStat> Sts { get; set; } = null!;

    // Weakness
    public List<string> Wns { get; set; } = null!;

    // Strong
    public List<string> Sgs { get; set; } = null!;

    public PokemonLite()
    {
    }

    public PokemonLite(Pokemon _pokemon, List<PokeApiNet.Type> _types)
    {
        Initialize(_pokemon, _types);
    }

    public void Initialize(Pokemon _pokemon, List<PokeApiNet.Type> _types)
    {
        Id = _pokemon.Id;
        N = _pokemon.Name;
        //FrontDefault = _pokemon.Sprites.Other.OfficialArtwork.FrontDefault;
        Ts = _pokemon.Types.OrderBy(_ => _.Type.Name).Select(t => t.Type.Name).ToList();
        Sts = _pokemon.Stats.Select(stat => new PokemonLiteStat(stat)).ToList();
        Wns = _types.SelectMany(_ => _.DamageRelations.DoubleDamageFrom)
                                      .DistinctBy(_ => _.Name)
                                      .OrderBy(_ => _.Name)
                                      .Select(_ => (_.Name))
                                      .ToList();
        Sgs = _types.SelectMany(_ => _.DamageRelations.DoubleDamageTo)
                                      .DistinctBy(_ => _.Name)
                                      .OrderBy(_ => _.Name)
                                      .Select(_ => _.Name)
                                      .ToList();
    }
}