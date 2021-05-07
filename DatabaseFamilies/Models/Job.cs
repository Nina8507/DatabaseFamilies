using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DatabaseFamilies.Models
{
    public class Job
    {
        [Key]
        [JsonPropertyName("jobId")]
        public int Id { get; set; }
        [JsonPropertyName("jobTitle")]
        public string JobTitle { get; set; }
        [JsonPropertyName("salary")]
        public int Salary { get; set; }
    }
}