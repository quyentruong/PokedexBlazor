// See https://aka.ms/new-console-template for more information
using PokeApiNet;
using PokedexBlazor.Utils;
using PokedexBlazor.Models;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using TestFunction.FlattenJson;

//PokeApiClient pokeClient = new PokeApiClient();
//Pokemon pikachu = await pokeClient.GetResourceAsync<Pokemon>("Mewtwo");
//PokemonSpecies species = await pokeClient.GetResourceAsync(pikachu.Species);
//var t = await pokeClient.GetResourceAsync(pikachu.Types[0].Type);
//var s = await pokeClient.GetResourceAsync(pikachu.Types.Select(ty => ty.Type));

//List<string> names = s.SelectMany(item => item.DamageRelations.DoubleDamageFrom)
//                      .Select(item1 => item1.Name)
//                      .ToList();

//foreach (var item in names)
//{
//    Console.WriteLine(item);
//}
////Console.WriteLine(t.DamageRelations.DoubleDamageFrom[0].Name);

//List<Move> allMoves = await pokeClient.GetResourceAsync(pikachu.Moves.Select(move => move.Move));
//FlattenPokemon.Run();
//await FlattenPokemonDamageRelation.Run();
Console.WriteLine("test");
//FlattenPokemon.Run();
//FlattenPokemonType.Run();