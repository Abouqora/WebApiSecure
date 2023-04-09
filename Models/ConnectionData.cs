using System.ComponentModel.DataAnnotations;

namespace AspApiCours.Models
{
    public class ConnectionData
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
