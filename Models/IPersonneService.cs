namespace AspApiCours.Models
{
    public interface IPersonneService
    {
        List<Personne> GetAll();
        Personne? GetOneById(int? id);
        Personne Add(Personne personne);
        bool Delete(int? id);
        Personne? Update(Personne personne);
    }
}
