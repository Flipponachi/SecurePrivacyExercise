using MongoDB.Driver;
using SecurePrivacyExercise.Config;
using SecurePrivacyExercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurePrivacyExercise.Services
{
    public class StudentService
    {
        private readonly IMongoCollection<Student> _students;

        public StudentService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _students = database.GetCollection<Student>(settings.StudentCollectionName);
        }

        public List<Student> Get() =>
            _students.Find(book => true).ToList();

        public Student Get(string id) =>
            _students.Find<Student>(book => book.Id == id).FirstOrDefault();

        public Student Create(Student book)
        {
            _students.InsertOne(book);
            return book;
        }

        public void Update(string id, Student bookIn) =>
            _students.ReplaceOne(book => book.Id == id, bookIn);

        public void Remove(Student bookIn) =>
            _students.DeleteOne(book => book.Id == bookIn.Id);

        public void Remove(string id) =>
            _students.DeleteOne(book => book.Id == id);
    }
}
