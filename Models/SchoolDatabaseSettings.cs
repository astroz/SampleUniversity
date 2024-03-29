namespace SampleUniversity.Models {
    public class SchoolDatabaseSettings : ISchoolDatabaseSettings {
        public string StudentCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface ISchoolDatabaseSettings {
        string StudentCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}