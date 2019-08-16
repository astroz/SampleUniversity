using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;


namespace SampleUniversity.Models {
    public class Student {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonProperty("Id")]
        public string Id { get; set; }

        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}