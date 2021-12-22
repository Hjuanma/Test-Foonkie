using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test_Foonkie.Models
{
   public class User
   {
      [JsonProperty("id")]
      public int Id { get; set; }

      [JsonProperty("first_name")]
      public string FirstName { get; set; }

      [JsonProperty("last_name")]
      public string LastName { get; set; }

      [JsonProperty("avatar")]
      public string Avatar { get; set; }

      [JsonProperty("email")]
      public string Email { get; set; }

   }
}
