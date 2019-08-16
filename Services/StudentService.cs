using System.Collections.Generic;
using MongoDB.Driver;
using SampleUniversity.Models;

namespace SampleUniversity.Services {
    public class StudentService {
        private readonly IMongoCollection<Student> _students;

        public StudentService(ISchoolDatabaseSettings settings) {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _students = database.GetCollection<Student>(settings.StudentCollectionName);
        }

        public List<Student> Get() =>
            _students.Find(student => true).ToList();

        public Student Get(string id) =>
            _students.Find<Student>(student => student.Id == id).FirstOrDefault();

        public Student Create(Student student) {
            _students.InsertOne(student);
            return student;
        }

        public void Update(string id, Student updatedStudent) =>
            _students.ReplaceOne(student => student.Id == id, updatedStudent);

        public void Remove(Student updatedStudent) =>
            _students.DeleteOne(student => student.Id == updatedStudent.Id);

        public void Remove(string id) =>
            _students.DeleteOne(student => student.Id == id);
    }
}