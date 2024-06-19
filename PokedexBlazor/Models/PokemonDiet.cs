#pragma warning disable CS8618

namespace PokedexBlazor.Models;

public class PokemonDiet
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Height { get; set; }
    public int Weight { get; set; }
    public int BaseExperience { get; set; }
    public List<PokemonDietStat> Stats { get; set; }
    public List<string> Types { get; set; }
    public SortedSet<string> Strength { get; set; } = new();
    public SortedSet<string> Weakness { get; set; } = new();
}

public class PokemonDietStat
{
    public string Name { get; set; }
    public double Value { get; set; }
}

public class PokemonFilterType
{
    public bool Default { get; set; }
    public string Text { get; set; }
}