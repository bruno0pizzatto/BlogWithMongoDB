using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogWithMongoDB.Models
{
    public class BaseModels
    {
        protected MongoDatabase db;        

        public BaseModels()
        {
            this.db = startDatabase();
        }

        private MongoDatabase startDatabase()
        {
            string connectionString = "mongodb://localhost";
            MongoClient client = new MongoClient(connectionString);
            MongoServer server = client.GetServer();
            MongoDatabase db = server.GetDatabase("Blog");
            return db;
        }
    }
}