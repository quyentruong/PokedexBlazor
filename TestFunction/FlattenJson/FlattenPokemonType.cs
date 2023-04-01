#pragma warning disable CS8618,CS8602

using Newtonsoft.Json;
using PokedexBlazor.Models;
using PokedexBlazor.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace TestFunction.FlattenJson;

/*
 *
 * Query to get damamge Type. But it still incorrect.
query MyQuery {
  pokemon_v2_typename(distinct_on: name, where: {name: {_neq: "???"}, language_id: {_eq: 9}}) {
    name
    language_id
    pokemon_v2_language {
      name
    }
    pokemon_v2_type {
      pokemonV2TypeefficaciesByTargetTypeId {
        damage_factor
        pokemon_v2_type {
          name
        }
      }
    }
  }
}
 */

public class FlattenPokemonType
{
    public static void Run()
    {
        var filePath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "pokemonType.json"));
        Dictionary<string, List<TypeDamageFactor>> dict = new();
        using (StreamReader reader = new StreamReader(filePath))
        {
            string json = reader.ReadToEnd();
            var parsedJson = JsonConvert.DeserializeObject<PokemonTypeData>(json);

            foreach (var type in parsedJson.Data.PokemonV2TypeName)
            {
                //Console.WriteLine($"Type: {type.Name}");
                dict.Add(type.Name, new List<TypeDamageFactor>());

                foreach (var effectiveness in type.PokemonV2Type.PokemonV2TypeEfficaciesByTargetTypeId)
                {
                    dict[type.Name].Add(new TypeDamageFactor()
                    {
                        Name = effectiveness.PokemonV2Type.Name,
                        DamageFactor = effectiveness.DamageFactor
                    });

                    //Console.WriteLine($"\t{effectiveness.PokemonV2Type.Name}: {effectiveness.DamageFactor}");
                }
            }
        }
        var d = JsonConvert.SerializeObject(dict);
        var dd = BasicUtility.CompressStringDeflate(d);
        var ss = BasicUtility.DecompressStringDeflate(dd);
        var s = JsonConvert.DeserializeObject<Dictionary<string, List<TypeDamageFactor>>>(ss);

        var deflatePath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "..", "PokedexBlazor", "wwwroot", "data", "pokemonTypeDeflate.txt"));

        File.WriteAllText(deflatePath, dd);
    }

    #region ignore

    public class PokemonTypeData
    {
        public Data Data { get; set; }
    }

    public class Data
    {
        [JsonProperty("pokemon_v2_typename")]
        public TypeName[] PokemonV2TypeName { get; set; }
    }

    public class TypeName
    {
        public string Name { get; set; }

        [JsonProperty("pokemon_v2_type")]
        public TypeDetails PokemonV2Type { get; set; }
    }

    public class TypeDetails
    {
        [JsonProperty("pokemonV2TypeefficaciesByTargetTypeId")]
        public Efficacy[] PokemonV2TypeEfficaciesByTargetTypeId { get; set; }

        public string Name { get; set; }
    }

    public class Efficacy
    {
        [JsonProperty("damage_factor")]
        public int DamageFactor { get; set; }

        [JsonProperty("pokemon_v2_type")]
        public TypeDetails PokemonV2Type { get; set; }
    }

    #endregion ignore
}