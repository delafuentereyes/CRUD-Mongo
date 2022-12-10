using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using CRUD_Mongo.Models;
using System.Text.Json.Nodes;

namespace CRUD_Mongo.DatabaseHelper
{
    public class Database
    {
        public List<User> getUsers()
        {
            MongoClient mongoClient = new MongoClient("mongodb+srv://jesusdelafuente:TitoyMia17@basesdedatos2.qj80is6.mongodb.net/test");

            IMongoDatabase db = mongoClient.GetDatabase("MongoBD2");

            var users = db.GetCollection<BsonDocument>("Users");

            List<BsonDocument> userArray = users.Find(new BsonDocument()).ToList();

            List<User> userList = new List<User>();

            foreach (BsonDocument bsonUser in userArray)
            {
                User user = BsonSerializer.Deserialize<User>(bsonUser);
                userList.Add(user);
            }

            return userList;
        }

        public void insertUser(User user)
        {
            MongoClient mongoClient = new MongoClient("mongodb+srv://jesusdelafuente:TitoyMia17@basesdedatos2.qj80is6.mongodb.net/test");

            IMongoDatabase db = mongoClient.GetDatabase("MongoBD2");

            var users = db.GetCollection<BsonDocument>("Users");

            var doc = new BsonDocument
            {
                { "name", user.name },
                { "email", user.email },
                { "phone", user.phone },
                { "address", user.address},
                { "dateIn", user.dateIn }
            };

            users.InsertOne(doc);
        }

        public void deleteUser(User user)
        {
            MongoClient mongoClient = new MongoClient("mongodb+srv://jesusdelafuente:TitoyMia17@basesdedatos2.qj80is6.mongodb.net/test");

            IMongoDatabase db = mongoClient.GetDatabase("MongoBD2");

            var users = db.GetCollection<BsonDocument>("Users");

            var deleteFilter = Builders<BsonDocument>.Filter.Eq("_id", user._id);

            users.DeleteOne(deleteFilter);
        }

        public void updateUser(User user)
        {
            MongoClient mongoClient = new MongoClient("mongodb+srv://jesusdelafuente:TitoyMia17@basesdedatos2.qj80is6.mongodb.net/test");

            IMongoDatabase db = mongoClient.GetDatabase("MongoBD2");

            var users = db.GetCollection<BsonDocument>("Users");

            var filter = Builders<BsonDocument>.Filter.Eq("-_id", user._id);
            var doc = new BsonDocument
            {
                {"name",user.name },
                { "email", user.email},
                { "phone", user.phone },
                { "address", user.address},
            };

            db.GetCollection<BsonDocument>("Users").FindOneAndUpdate(filter, doc);
        }
    }
}
