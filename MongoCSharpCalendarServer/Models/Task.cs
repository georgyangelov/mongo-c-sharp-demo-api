using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MongoCSharpCalendarServer.Models
{
    public class Task
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }

        public string title { get; set; }
        
        public string text { get; set; }

        [BsonDefaultValue(false)]
        public bool completed { get; set; }

        public DateTime date { get; set; }

        public int priority { get; set; }
    }
}