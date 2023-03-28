namespace PokedexBlazor.Models;

public class PokemonWeakness
{
    public string Name { get; set; } = string.Empty;

    public PokemonWeakness()
    {
    }

    public PokemonWeakness(string name)
    {
        Name = name;
    }
}