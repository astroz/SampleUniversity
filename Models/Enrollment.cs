using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SampleUniversity.Models {
    public enum Grade {
        A,
        B,
        C,
        D,
        F
    }

    public class Enrollment {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int EnrollmentId { get; set; }

        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public Grade? Grade { get; set; }

        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}