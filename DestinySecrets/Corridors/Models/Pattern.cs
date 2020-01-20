using System.Collections.Generic;

namespace DestinySecrets.Corridors.Models
{
    public class Pattern
    {
        public string Center { get; set; }
        public List<bool> Walls { get; set; }        
        public List<List<string>> Nodes { get; set; }
    }
}
