using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DatabaseFamilies.Models
{
    public class Family
    {
        [Key]
        [JsonPropertyName("familyId")]
        public int Id { get; set; }
        [Required]
        [JsonPropertyName("streetName")]
        public string StreetName { get; set; }
        [Required]
        [JsonPropertyName("houseNumber")]
        public int HouseNumber{ get; set; }
        public List<Adult> Adults { get; set; }
        public List<Child> Children{ get; set; }
        public List<Pet> Pets{ get; set; }
                
        public Family() 
        {
            Adults = new List<Adult>();
            Children = new List<Child>();
            Pets = new List<Pet>();
        }
        
        public override string ToString()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions
            {
                WriteIndented = true
            });
        }
    }
}