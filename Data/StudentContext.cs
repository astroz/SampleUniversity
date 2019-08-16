using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SampleUniversity.Models;

namespace SampleUniversity.Data {
    public class StudentContext : DbContext, IStudentContext {
        private readonly IMongoDatabase _db;

        public StudentContext() {
        }

        public StudentContext(IOptions<SchoolDatabaseSettings> options) {
            var client = new MongoClient(options.Value.ConnectionString);
            _db = client.GetDatabase(options.Value.DatabaseName);
        }

        public IMongoCollection<Student> Students => _db.GetCollection<Student>("Students");
        public IMongoCollection<Student> Student { get; }
    }

    public interface IStudentContext {
        IMongoCollection<Student> Students { get; }
    }
}