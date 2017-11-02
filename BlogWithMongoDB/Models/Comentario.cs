using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BlogWithMongoDB.Models
{
    public class Comentario
    {
        [BsonId]
        public ObjectId id { get; set; }
        public string data { get; set; }
        public string usuario { get; set; }
        public string texto { get; set; }
    }
}