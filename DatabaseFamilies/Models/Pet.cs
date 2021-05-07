using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace DatabaseFamilies.Models
{
    public class Pet
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Species { get; set; }
        [Required]
        public string Name { get; set; }
        public int Age { get; set; }
        
        public override string ToString()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions
            {
                WriteIndented = true
            });
        }
    }
}