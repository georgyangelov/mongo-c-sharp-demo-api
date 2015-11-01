using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using MongoDB.Driver;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    public class TasksController : Controller
    {
        private IMongoCollection<Task> tasks;

        public TasksController()
        {
            var client = new MongoClient("mongodb://10.0.2.2");
            var database = client.GetDatabase("testcsharpdb");

            tasks = database.GetCollection<Task>("tasks");
        }

        // GET: api/tasks
        [HttpGet]
        public async System.Threading.Tasks.Task<IEnumerable<Task>> Get()
        {
            return await tasks.Find(Builders<Task>.Filter.Empty).ToListAsync();
        }

        // GET api/tasks/5
        [HttpGet("{id}")]
        public async System.Threading.Tasks.Task<Task> Get(string id)
        {
            return await tasks.Find(Builders<Task>.Filter.Eq("id", id)).FirstAsync();
        }

        // GET api/tasks/5
        [HttpGet("for_date/{date}")]
        public async System.Threading.Tasks.Task<IEnumerable<Task>> GetForDate(string date)
        {
            var startOfDate = DateTime.Parse(date);
            var endOfDate = DateTime.Parse(date).AddDays(1);

            var builder = Builders<Task>.Filter;

            return await tasks.Find(
                builder.Gte("date", startOfDate) & builder.Lt("date", endOfDate)
            ).ToListAsync();
        }

        // POST api/tasks
        [HttpPost]
        public async void Post([FromBody]Task task)
        {
            await tasks.InsertOneAsync(task);
        }

        // PUT api/tasks
        [HttpPut]
        public async void Put([FromBody]Task task)
        {
            var filter = Builders<Task>.Filter.Eq("id", task.id);

            await tasks.ReplaceOneAsync(filter, task);
        }

        // DELETE api/tasks/5
        [HttpDelete("{id}")]
        public async void Delete(string id)
        {
            var filter = Builders<Task>.Filter.Eq("id", id);

            await tasks.DeleteOneAsync(filter);
        }
    }
}
