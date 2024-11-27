using MongoDB.Driver;
using Microsoft.Extensions.Options;
using PetApp.Models;

namespace PetApp.Repositories
{
    public class UserRepository
    {
        private readonly IMongoCollection<UserDB> _usersCollection;

        public UserRepository(IOptions<DatabaseSettings> dbSettings)
        {
            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);
            _usersCollection = mongoDatabase.GetCollection<UserDB>("Users");
        }

        public async Task CreateAsync(UserDB user) =>
            await _usersCollection.InsertOneAsync(user);

        public async Task<UserDB?> GetByUsernameAsync(string username) =>
            await _usersCollection.Find(u => u.Username == username).FirstOrDefaultAsync();
    }
}
