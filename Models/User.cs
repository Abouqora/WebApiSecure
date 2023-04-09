using System.Text.Json.Serialization;

namespace AspApiCours.Models
{
    public class User
    {
        public int? Id { get; set; }
        public string Username { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public string? Email { get; set; }
        public string Role { get; set; }
    }
}
