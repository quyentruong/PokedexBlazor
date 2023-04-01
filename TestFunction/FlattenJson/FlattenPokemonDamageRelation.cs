using Newtonsoft.Json;
using PokeApiNet;
using PokedexBlazor.Models;
using PokedexBlazor.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFunction.FlattenJson;
/*
 * Fetch Api to get damage relation to publish to wwwroot
 */

public class FlattenPokemonDamageRelation
{
    public static async Task Run()
    {
        PokeApiClient pokeClient = new PokeApiClient();
        Dictionary<string, TypeDamageRelation> dict = new();
        for (int i = 1; i <= 18; i++)
        {
            var t = await pokeClient.GetResourceAsync<PokeApiNet.Type>(i);
            dict.Add(t.Name, new TypeDamageRelation()
            {
                Strength = new(),
                Weakness = new()
            });

            foreach (var s in t.DamageRelations.DoubleDamageTo)
            {
                dict[t.Name].Strength.Add(s.Name);
            }

            foreach (var w in t.DamageRelations.DoubleDamageFrom)
            {
                dict[t.Name].Weakness.Add(w.Name);
            }
        }
        var d = JsonConvert.SerializeObject(dict);
        var dd = BasicUtility.CompressStringDeflate(d);
        var ss = BasicUtility.DecompressStringDeflate(dd);
        var sss = JsonConvert.DeserializeObject<Dictionary<string, TypeDamageRelation>>(ss);

        var deflatePath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "..", "PokedexBlazor", "wwwroot", "data", "pokemonTypeDamgeRelationDeflate.txt"));

        File.WriteAllText(deflatePath, dd);
        Console.WriteLine();
    }
}