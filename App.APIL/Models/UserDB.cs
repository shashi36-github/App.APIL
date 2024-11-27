using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PetApp.Models
{
    public class UserDB
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string? Email { get; set; }
        public string? Name { get; set; }
        public long? Phone { get; set; }
    }
}
