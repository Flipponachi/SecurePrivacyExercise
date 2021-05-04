using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace SecurePrivacyExercise.Models
{
    public class Student
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [Required]
        [BsonRequired]
        public string Name { get; set; }

        [Required]
        [BsonRequired]
        public Int32? Age { get; set; }

        [Required]
        [BsonRequired]
        public string Address { get; set; }

        [BsonElement]
        public DateTime CreationTime { get; set; }

    }
}
