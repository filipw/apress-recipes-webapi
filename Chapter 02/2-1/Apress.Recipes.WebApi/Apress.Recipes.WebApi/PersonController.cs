using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace Apress.Recipes.WebApi
{
    public class PersonController : ApiController
    {
        private static List<Person> people = new List<Person>
        {
            new Person {Id =1, Name = "Filip"},
            new Person {Id =2, Name = "Felix"}
        };

        [Route("person")]
        public IEnumerable<Person> Get()
        {
            return people;
        }

        [Route("person/{id:int}", Name = "PersonById")]
        public Person GetById(int id)
        {
            var person = people.FirstOrDefault(x => x.Id == id);
            if (person == null) throw new HttpResponseException(HttpStatusCode.NotFound);

            return person;
        }

        [Route("person")]
        public IHttpActionResult Post(Person p)
        {
            people.Add(p);
            return CreatedAtRoute("PersonById", new {id = p.Id}, p);
        }
    }
}