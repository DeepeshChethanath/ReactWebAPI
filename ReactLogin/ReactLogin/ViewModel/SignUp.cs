using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReactLogin.ViewModel
{
    public class SignUp
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string EmployeeName { get; set; }

        public string City { get; set; }

        public string Department { get; set; }
    }
}