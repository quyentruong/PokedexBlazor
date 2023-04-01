#pragma warning disable CS8618

using Newtonsoft.Json;
using PokedexBlazor.Models;
using PokedexBlazor.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFunction.FlattenJson;
/*
 *
 * Query to get pokemon from Graphql
query samplePokeAPIquery {
  pokemon_v2_pokemon(limit: 1008) {
    id
    name
    height
    weight
    base_experience
    pokemon_v2_pokemonstats {
      base_stat
      pokemon_v2_stat {
        name
      }
    }
    pokemon_v2_pokemontypes {
      pokemon_v2_type {
        name
      }
    }
  }
}

 */

internal class FlattenPokemon
{
    public static void Run()
    {
        var filepath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "pokemon.json"));
        // Read the JSON from a file and parse it into an object
        string json = File.ReadAllText(filepath);
        PokemonData pokemonData = JsonConvert.DeserializeObject<PokemonData>(json)!;
        List<PokemonDiet> list = new();

        // Access the data
        foreach (var pokemon in pokemonData.data.pokemon_v2_pokemon)
        {
            list.Add(new PokemonDiet()
            {
                Id = pokemon.id,
                Name = pokemon.name,
                Height = pokemon.height,
                BaseExperience = pokemon.base_experience,
                Weight = pokemon.weight,
                Stats = new(),
                Types = new()
            });
            //Console.WriteLine($"{pokemon.name} has the following stats:");
            foreach (var stat in pokemon.pokemon_v2_pokemonstats)
            {
                list[^1].Stats.Add(new PokemonDietStat()
                {
                    Name = stat.pokemon_v2_stat.name,
                    Value = stat.base_stat
                });
                //Console.WriteLine($"{stat.pokemon_v2_stat.name}: {stat.base_stat}");
            }
            //Console.WriteLine($"And the following types:");
            foreach (var type in pokemon.pokemon_v2_pokemontypes)
            {
                list[^1].Types.Add(type.pokemon_v2_type.name);
                //Console.WriteLine($"{type.pokemon_v2_type.name}");
            }
        }

        var d = JsonConvert.SerializeObject(list);
        var dd = BasicUtility.CompressStringDeflate(d);
        var ss = BasicUtility.DecompressStringDeflate(dd);
        var s = JsonConvert.DeserializeObject<List<PokemonDiet>>(ss);

        var deflatePath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "..", "PokedexBlazor", "wwwroot", "data", "pokemonDeflate.txt"));

        File.WriteAllText(deflatePath, dd);
    }

    #region ignore

    public class PokemonData
    {
        public Data data { get; set; }
    }

    public class Data
    {
        public Pokemon[] pokemon_v2_pokemon { get; set; }
    }

    public class Pokemon
    {
        public int id { get; set; }
        public string name { get; set; }
        public int height { get; set; }
        public int weight { get; set; }
        public int base_experience { get; set; }
        public PokemonStat[] pokemon_v2_pokemonstats { get; set; }
        public PokemonType[] pokemon_v2_pokemontypes { get; set; }
    }

    public class PokemonStat
    {
        public int base_stat { get; set; }
        public Stat pokemon_v2_stat { get; set; }
    }

    public class Stat
    {
        public string name { get; set; }
    }

    public class PokemonType
    {
        public Type pokemon_v2_type { get; set; }
    }

    public class Type
    {
        public string name { get; set; }
    }

    #endregion ignore
}