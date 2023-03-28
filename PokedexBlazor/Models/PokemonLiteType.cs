using PokeApiNet;
using PokedexBlazor.Utils;

namespace PokedexBlazor.Models;

public class PokemonLiteType
{
    public string Name { get; set; } = string.Empty;

    public PokemonLiteType()
    {
    }

    public PokemonLiteType(PokemonType pokemonType)
    {
        Name = pokemonType.Type.Name;
    }
}