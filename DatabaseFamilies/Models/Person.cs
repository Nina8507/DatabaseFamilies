using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DatabaseFamilies.Models
{
    public class Person
    {
        [Key]
        [JsonPropertyName("personId")]
        public virtual int Id { get; set; }
        [Required]
        public virtual string FirstName { get; set; }
        [Required]
        public virtual string LastName { get; set; }
        [Required]
        public virtual string HairColor { get; set; }      
        [Required]
        public virtual int Age { get; set; }
        public virtual float Weight { get; set; }
        public virtual int Height { get; set; }
        [Required]
        public virtual string Sex { get; set; }
        
        public override string ToString()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions
            {
                WriteIndented = true
            });
        }
    }
}