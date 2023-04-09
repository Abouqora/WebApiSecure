using Microsoft.AspNetCore.Mvc;

namespace AspApiCours.Models
{
    public class PersonneService : IPersonneService
    {
        public List<Personne> Personnes { get; set; }
        public PersonneService()
        {
            Personnes = new List<Personne>()
            {
            new Personne(){ Num = 1, Nom = "Wick", Prenom = "John", Age = 45},
            new Personne(){ Num = 2, Nom = "Dalton", Prenom = "Jack", Age = 40},
            new Personne(){ Num = 3, Nom = "Maggio", Prenom = "Sophie", Age = 20},
            };
        }
        public List<Personne> GetAll()
        {
            return Personnes;
        }
        public Personne? GetOneById(int? id)
        {
            return Personnes.Find(elt => elt.Num == id);
        }
        public Personne Add(Personne personne)
        {
            Personnes.Add(personne);
            return personne;
        }
        
        public bool Delete(int? id)
        {
          return   Personnes.Remove(GetOneById(id));
        }
        
        public Personne? Update(Personne personne)
        {
            var p = GetOneById(personne.Num);
            if (p != null)
            {
                Personnes.Remove(p);
                Personnes.Add(personne );
                return personne;
            }
            return null;

        }
    }
}
