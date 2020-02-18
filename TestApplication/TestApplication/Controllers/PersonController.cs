using Core;
using System;
using System.Linq;
using System.Web.Http;
using JetBrains.Annotations;

namespace TestApplication.Controllers
{
    [RoutePrefix("api/Person")]
    public class PersonController : ApiController
    {
        private readonly IPersonRepository _personRepository;

        public PersonController([NotNull] IPersonRepository personRepository)
        {
            _personRepository = personRepository ?? throw new ArgumentNullException(nameof(personRepository));
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetPerson([FromUri] int id)
        {
            try
            {
                var person = _personRepository.Get(id);

                return Ok(person);

            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
        [HttpGet]
        [Route("avg-salary")]
        public IHttpActionResult GetAverageSalary()
        {
            try
            {
                var persons = _personRepository.GetAll();
                var averageSalary = persons.Sum(d => d.Salary) / persons.Count; 
                return Ok(averageSalary);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
        [HttpGet]
        [Route("senior-employee")]
        public IHttpActionResult GetSeniorEmployee()
        {
            try
            {
                var persons = _personRepository.GetAll();
                var allEmployee = persons.OrderBy(f => f.BirthDay).FirstOrDefault();
                return Ok(allEmployee);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}