using PokedexBlazor.Models;

namespace PokedexBlazor.Services;

public class PokemonTransferService
{
    private PokemonLite _data = null!;

    public PokemonLite Data
    {
        get => _data;
        set
        {
            _data = value;
            NotifyStateChanged();
        }
    }

    private List<PokemonLite> _list = new();

    public List<PokemonLite> List
    {
        get => _list;
        set { _list = value; NotifyStateChanged(); }
    }

    public void Add(PokemonLite pokemon)
    {
        _list.Add(pokemon);
        NotifyStateChanged();
    }

    public void Remove(PokemonLite pokemon)
    {
        _list.Remove(pokemon);
        NotifyStateChanged();
    }

    public event Action? OnChange;

    private void NotifyStateChanged() => OnChange?.Invoke();
}