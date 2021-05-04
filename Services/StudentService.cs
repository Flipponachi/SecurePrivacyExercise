using MongoDB.Bson;
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
        private IMongoCollection<Student> _students;
        private IMongoDatabase _database;
        private MongoClient _client;
        public StudentService(IDatabaseSettings settings)
        {
            _client = new MongoClient(settings.ConnectionString);
            _database = _client.GetDatabase(settings.DatabaseName);

            if(!IsCollectionExistsAsync(_database, "Student"))
            {
                _database.CreateCollection("Student");
            }


            _students = _database.GetCollection<Student>("Student");
        }

        public List<Student> Get()
        {
           return  _students.Find(student => true).ToList();
        }
            

        public Student Get(string id) =>
            _students.Find<Student>(student => student.Id == id).FirstOrDefault();

        public Student Create(Student student)
        {
            student.CreationTime = DateTime.UtcNow;
            _students.InsertOne(student);
            return student;
        }

        public void Update(string id, Student student) =>
            _students.ReplaceOne(book => book.Id == id, student);

        public void Remove(string id) =>
            _students.DeleteOne(stu => stu.Id == id);

        /// <summary>
        /// Determines if a collection exists
        /// </summary>
        /// <param name="database"></param>
        /// <param name="collectionName"></param>
        /// <returns></returns>
        private bool IsCollectionExistsAsync(IMongoDatabase database, string collectionName)
        {
           
            IMongoCollection<BsonDocument> mongoCollection = database.GetCollection<BsonDocument>(collectionName);

            if (mongoCollection != null)
            {
                return true;
            }

            return false;
        }
    }
}
