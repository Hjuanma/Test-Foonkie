using MonkeyCache.FileStore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Test_Foonkie.Models;
using Xamarin.Essentials;

namespace Test_Foonkie.Services
{
   public static class PersistenceService
   {
      public static async Task<T> GetAsync<T>(string url, int days = 7, bool forceRefresh = false)
      {

         var json = string.Empty;

         if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            json = Barrel.Current.Get<string>(url);

         if (!forceRefresh && !Barrel.Current.IsExpired(url))
            json = Barrel.Current.Get<string>(url);

         try
         {

            var client = new HttpClient();
            if (string.IsNullOrWhiteSpace(json))
            {
               json = await client.GetStringAsync(url);
               Barrel.Current.Add(url, json, TimeSpan.FromDays(days));
            }

            JObject googleSearch = JObject.Parse(json);

            var aux = googleSearch["data"].ToString();

            return JsonConvert.DeserializeObject<T>(aux);
         }
         catch (Exception ex)
         {
            Console.WriteLine($"Unable to get information from server {ex}");
            //probably re-throw here :)
         }

         return default(T);
      }
   }
}
