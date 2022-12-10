using MongoDB.Bson;

namespace MongoBackend.Models
{
    public class User
    {   
        public ObjectId? _id { get; set; } 
        public string? name { get; set; }
        public string? email { get; set; }
        public Int32? phone { get; set; }
        public string? address { get; set; }
        public DateTime? dateIn { get; set; }
    }
}
