using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MongoCSharpCalendarServer
{
    using MongoCSharpCalendarServer.Models;
    using MongoDB.Bson;
    using MongoDB.Driver;
    using MongoDB.Driver.Builders;
    using Nancy;
    using Nancy.ModelBinding;

    public class TasksModule : NancyModule
    {
        private MongoCollection<Task> collection;

        public TasksModule(MongoDatabase database) : base("/api/tasks")
        {
            collection = database.GetCollection<Task>("tasks");

            /* Read */
            Get["/"] = _ => Response.AsJson(collection.FindAll());

            Get["/{id}"] = request =>
            {
                ObjectId id = new ObjectId(request.id);

                return Response.AsJson(collection.FindOneById(id));
            };

            Get["/for_date/{date}"] = request =>
            {
                DateTime start_time = DateTime.Parse(request.date);
                DateTime end_time = start_time.AddDays(1);

                return Response.AsJson(collection.Find(Query.And(
                    Query.GTE("date", start_time),
                    Query.LT("date", end_time)
                )).OrderByDescending(task => task.priority));
            };

            /* Create */
            Post["/"] = _ =>
            {
                Task newTask = this.Bind<Task>(new string[] { "id" });

                collection.Insert(newTask);

                return Response.AsJson(newTask);
            };

            /* Update */
            Put["/"] = request =>
            {
                Task modifiedTask = this.Bind<Task>();

                collection.Save(modifiedTask);

                return Response.AsJson(collection.FindOneById(modifiedTask.id));
            };

            /* Delete */
            Delete["/{id}"] = request =>
            {
                ObjectId id = new ObjectId(request.id);

                collection.Remove(Query.EQ("_id", id));

                return HttpStatusCode.OK;
            };
        }
    }
}