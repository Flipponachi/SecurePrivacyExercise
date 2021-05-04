using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace SecurePrivacyExercise.Models
{
    public class Student
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        public Int32 Age { get; set; }

        public string Address { get; set; }

    }
}
