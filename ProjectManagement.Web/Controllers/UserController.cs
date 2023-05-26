using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProjectManagement.Entities.Enums;
using ProjectManagement.Entities.Models;
using ProjectManagement.Repositories.Contexts;

namespace ProjectManagement.Web.Controllers
{
    public class UserController: ApiController
    {
        // private ApiContext apiContext { get; set; }

        // GET api/<controller>
        public User Get()
        {
            User user = null;

            using (var context = new StudentContext())
            {
                user = context.Students.Add(new Student(1, "Davi", "davi.sousa@ccc.ufcg.edu.br", "123456", Role.STUDENT, "UFCG"));
                context.SaveChanges();
                // context.Students.All()
                // user = context.Students.FirstOrDefault(student => student.Id == 1);
            }

            return user;
            // return 
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}