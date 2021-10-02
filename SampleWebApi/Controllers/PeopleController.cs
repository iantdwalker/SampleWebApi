using Microsoft.AspNetCore.Mvc;
using SampleWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SampleWebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PeopleController : ControllerBase
	{
		private List<Person> _people = new();

		public PeopleController()
		{
			_people.Add(new Person { Id = 1, FirstName = "Ian", LastName = "Walker" });
			_people.Add(new Person { Id = 2, FirstName = "Darren", LastName = "Walker" });
			_people.Add(new Person { Id = 3, FirstName = "Trudy", LastName = "Walker" });
		}

		// GET: api/<PeopleController>
		[HttpGet]
		public List<Person> Get()
		{
			return _people;
		}

		// GET api/<PeopleController>/5
		[HttpGet("{id}")]
		public Person Get(int id)
		{
			return _people.Where(x => x.Id == id).FirstOrDefault();
		}

		[HttpGet]
		[Route("/FirstNames")]
		public List<string> GetFirstNames()
		{
			var firstNames = new List<string>();
			foreach (var person in _people)
			{
				firstNames.Add(person.FirstName);
			}

			return firstNames;
		}

		// POST api/<PeopleController>
		[HttpPost]
		public void Post([FromBody] Person person)
		{
			_people.Add(person);
		}

		// PUT api/<PeopleController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<PeopleController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
