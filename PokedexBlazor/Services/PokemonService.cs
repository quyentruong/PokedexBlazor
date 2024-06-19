using PokedexBlazor.Models;

namespace PokedexBlazor.Services;

public class PokemonService
{
    public List<string> UNIQUE_TYPE =
    [
        "bug",
        "dark",
        "dragon",
        "electric",
        "fairy",
        "fighting",
        "fire",
        "flying",
        "ghost",
        "grass",
        "ground",
        "ice",
        "normal",
        "poison",
        "psychic",
        "rock",
        "steel",
        "water"
    ];
    private bool _isDarkMode = false;

    public bool IsDarkMode
    {
        get => _isDarkMode;
        set
        {
            _isDarkMode = value;
            NotifyStateChanged();
        }
    }

    private bool _isFilterOn = false;

    public bool IsFilterOn
    {
        get => _isFilterOn;
        set
        {
            _isFilterOn = value;
            NotifyStateChanged();
        }
    }

    private PokemonDiet? _data = null;

    public PokemonDiet? Data
    {
        get => _data;
        set
        {
            _data = value;
            NotifyStateChanged();
        }
    }

    private Dictionary<string, TypeDamageRelation> _typeDamageDict = [];

    public Dictionary<string, TypeDamageRelation> TypeDamageDict
    {
        get { return _typeDamageDict; }
        set
        {
            _typeDamageDict = value;
            NotifyStateChanged();
        }
    }

    private List<PokemonDiet> _pokemonlist = [];

    public List<PokemonDiet> PokemonList
    {
        get => _pokemonlist;
        set
        {
            _pokemonlist = value;
            NotifyStateChanged();
        }
    }

    private List<PokemonDiet> _pokemonFilterlist = [];

    public List<PokemonDiet> PokemonFilterList
    {
        get => _pokemonFilterlist;
        set
        {
            _pokemonFilterlist = value;
            NotifyStateChanged();
        }
    }

    private IEnumerable<string> _searchList = [];
    public IEnumerable<string> SearchList
    {
        get => _searchList;
        set
        {
            _searchList = value;
            NotifyStateChanged();
        }
    }

    private List<PokemonFilterType> _uniquePokemonType = [];

    public List<PokemonFilterType> UniquePokemonType
    {
        get => _uniquePokemonType;
        set
        {
            _uniquePokemonType = value;
            NotifyStateChanged();
        }
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
