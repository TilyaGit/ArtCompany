using System;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestApplication;
using TestApplication.Controllers;

namespace Core.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public  void ItShouldGetPersonById()
        {
            var personRepository = new FeikPersonRepository();
            personRepository.Persons.Add(new Person {Id =  7});
            PersonController personController = new PersonController(personRepository);

            var contentResult = personController.GetPerson(7) as OkNegotiatedContentResult<Person>;
             Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(7, contentResult.Content.Id);
        }

        [TestMethod]
        public void ItShouldGetAverageSalary()
        {
            var personRepository = new FeikPersonRepository();
            personRepository.Persons.Add(new Person { Salary = 25000});
            personRepository.Persons.Add(new Person { Salary = 50000});
            personRepository.Persons.Add(new Person { Salary = 15000});
            PersonController personController = new PersonController(personRepository);

            var contentResult = personController.GetAverageSalary() as OkNegotiatedContentResult<decimal>;
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(30000, contentResult.Content);
        }

        [TestMethod]
        public void ItShouldGetAllEmployee()
        {
            var personRepository = new FeikPersonRepository();
            personRepository.Persons.Add(new Person { BirthDay = new DateTime(1991,11,22) });
            personRepository.Persons.Add(new Person { BirthDay = new DateTime(1991,04,30) });
            personRepository.Persons.Add(new Person { BirthDay = new DateTime(1991,07,15) });
            PersonController personController = new PersonController(personRepository);

            var contentResult = personController.GetSeniorEmployee() as OkNegotiatedContentResult<Person>;
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content.BirthDay);
            Assert.AreEqual(new DateTime(1991, 04, 30), contentResult.Content.BirthDay);
        }
    }
}
