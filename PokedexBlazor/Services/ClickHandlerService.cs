using Microsoft.AspNetCore.Components;
using PokedexBlazor.Models;

namespace PokedexBlazor.Services;

public class ClickHandlerService
{
    private readonly NavigationManager _navigationManager;
    private readonly PokemonService _pokemonService;

    public ClickHandlerService(NavigationManager navigationManager, PokemonService pokemonService)
    {
        _navigationManager = navigationManager;
        _pokemonService = pokemonService;
    }

    public void HandleClick(object p)
    {
        string name;

        if (p is PokemonDiet pokemon)
        {
            _pokemonService.Data = pokemon;
            name = pokemon.Name;
        }
        else if (p is string idAndName && !string.IsNullOrWhiteSpace(idAndName))
        {
            name = idAndName.Split(" - ")[1].Trim().ToLower();
            _pokemonService.Data = _pokemonService.PokemonFilterList.FirstOrDefault(pokemon =>
                pokemon.Name.ToLower().Equals(name)
            );
        }
        else
        {
            throw new ArgumentException("Unhandled parameter type", nameof(p));
        }

        _navigationManager.NavigateTo($"{_navigationManager.Uri}pokemon/{name}");
    }
}
