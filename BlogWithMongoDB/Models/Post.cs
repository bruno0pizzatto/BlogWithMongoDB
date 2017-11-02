using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Collections.Generic;


namespace BlogWithMongoDB.Models
{
    public class Post
    {
        public Post()
        {
            Tags = new List<Tag>();
            Comentarios = new List<Comentario>();
        }
        [BsonId]
        public ObjectId id { get; set; }
        public string titulo { get; set; }
        public string texto { get; set; }
        public string data { get; set; }
        public List<Tag> Tags { get; set; }
        public List<Comentario> Comentarios { set; get; }
    }
}