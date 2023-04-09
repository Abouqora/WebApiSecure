using AspApiCours.Interfaces;
using AspApiCours.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AspApiCours.Services
{
    public class UserService : IUserService
    {
        private IConfiguration _configuration = null;
        public List<User> Users { get; set; }
        public UserService(IConfiguration configuration)
        {
            _configuration = configuration;
            Users = new List<User>() {
            new User() { Id = 1, Nom = "Wick", Prenom = "John", Username = "Wick",
            Email = "w@w.fr", Password = "John", Role = Role.Admin },
            new User() { Id = 2, Nom = "Dalton", Prenom = "Jack", Username = "Dalton",
                Email = "d@d.fr", Password = "Jack", Role = Role.User },
            new User() { Id = 3, Nom = "Abouqora", Prenom = "Youness", Username = "Abouqora",
                Email = "abouqora@d.fr", Password = "Youness", Role = Role.User }
            };
        }
        public User Add(User user)
        {
            Users.Add(user);
            return user;

        }

        public User? CheckUser(ConnectionData data)
        {
            return Users.Find(elt => elt.Username == data.Username && elt.Password == data.Password);
           // return Users.Find(elt => elt.Username == data.Username && BCrypt.Net.BCrypt.Verify(data.Password, elt.Password));
        }

        public string GenerateJWT(User user)
        {
            var key = _configuration["Jwt:Key"];
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            Claim userClaim = new Claim("id", user.Id.ToString());
            Claim roleClaim = new Claim("role", user.Role);
            var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: new Claim[] { userClaim, roleClaim },
            signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public User? GetOneById(int id)
        {
            return Users.Find(elt => elt.Id == id);
        }
    }
}
