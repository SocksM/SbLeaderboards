using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
namespace SbLeaderboards.Resources.Models.HypixelApiResponseJson
{
    public class Root
    {
        public bool success { get; set; }
        public Profile profile { get; set; } = null!;
    }
}