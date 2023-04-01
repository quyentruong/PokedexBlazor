using PokedexBlazor.Models;

namespace PokedexBlazor.Services;

public class PokemonService
{
    private PokemonDiet _data = null!;

    public PokemonDiet Data
    {
        get => _data;
        set
        {
            _data = value;
            NotifyStateChanged();
        }
    }

    private bool _isDarkMode = false;

    public bool IsDarkMode
    { get => _isDarkMode; set { _isDarkMode = value; NotifyStateChanged(); } }

    private Dictionary<string, TypeDamageRelation> _typeDamageDict = new();

    public Dictionary<string, TypeDamageRelation> TypeDamageDict
    {
        get { return _typeDamageDict; }
        set { _typeDamageDict = value; NotifyStateChanged(); }
    }

    private List<PokemonDiet> _pokemonlist = new();

    public List<PokemonDiet> PokemonList
    {
        get => _pokemonlist;
        set { _pokemonlist = value; NotifyStateChanged(); }
    }

    public void Add(PokemonDiet pokemon)
    {
        _pokemonlist.Add(pokemon);
        NotifyStateChanged();
    }

    public void Remove(PokemonDiet pokemon)
    {
        _pokemonlist.Remove(pokemon);
        NotifyStateChanged();
    }

    public event Action? OnChange;

    private void NotifyStateChanged() => OnChange?.Invoke();
}