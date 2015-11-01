using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Task
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        
        public string title { get; set; }
        public string text { get; set; }
        public int priority { get; set; }
        public bool completed { get; set; }
        public DateTime date { get; set; }
    }
}
