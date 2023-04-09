using AspApiCours.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspApiCours.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PersonnesController : ControllerBase
    {
        private readonly IPersonneService personneService;
        public PersonnesController(IPersonneService personneService)
        {
            this.personneService = personneService;
        }
        //[Authorize(Roles = Role.Admin)]
        [HttpGet]
        public IEnumerable<Personne>   Get()
        {
            return this.personneService.GetAll();
        }
        //[Authorize(Roles = Role.User)]
        [HttpGet("{id}.{format?}")]
        public IActionResult Get(int id)
        {    var personne= personneService.GetOneById(id);
            if (personne == null)
            {
                return NotFound();
            }
            return Ok(personne);
        }
        [HttpPost]
        public Personne? Post(Personne personne)
        {
            Console.WriteLine(personne.Nom);
            return personneService.Add(personne);
        }
        [HttpDelete("{id}")]
        public bool delete(int id)
        {
            return personneService.Delete(id);
        }
        [HttpPut("{id}")]
        public Personne? put(Personne personne)
        {
            return personneService.Update(personne);
        }

    }
}
