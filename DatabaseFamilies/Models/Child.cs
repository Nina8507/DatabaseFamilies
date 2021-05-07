using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace DatabaseFamilies.Models
{
    public class Child:Person 
    {
        public List<Interest> Interests { get; set; }
        public List<Pet> Pets { get; set; }
        [Key]
        public override int Id { get; set; }
        [Required]
        public override string FirstName { get; set; }
        [Required]
        public override string LastName { get; set; }
        [Required]
        public override string HairColor { get; set; }
        [Required]
        public override int Age { get; set; }
        public override float Weight { get; set; }
        public override int Height { get; set; }
        [Required]
        public override string Sex { get; set; }
        
        public override string ToString()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions
            {
                WriteIndented = true
            });
        }
    }
}