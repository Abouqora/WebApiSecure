using AspApiCours.Models;

namespace AspApiCours.Interfaces
{
    public interface IUserService
    {
        User? CheckUser(ConnectionData data);
        string GenerateJWT(User user);
        User Add(User user);
        User? GetOneById(int id);
    }
}
