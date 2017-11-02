using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System.Collections.Generic;
using System.Linq;

namespace BlogWithMongoDB.Models
{
    public class Posts_Model : BaseModels
    {
        MongoCollection<Post> Posts;

        public Posts_Model()
        {
            Posts = this.db.GetCollection<Post>("Post");
        }

        public IEnumerable<Post> getPosts()
        {                       
            return this.Posts.FindAll().ToList();
        }

        public void Delete(string Guid)
        {
            this.Posts.FindAndRemove(Query.EQ("_id", ObjectId.Parse(Guid)), SortBy.Ascending("id"));
        }

        public Post Detalhe(string Guid)
        {            
            return this.Posts.FindOneById(ObjectId.Parse(Guid));
        }

        public void Insert(Post post)
        {                       
            this.Posts.Insert(post.ToBsonDocument());
        }

        public void CreateComment(string Guid, Comentario comentario)
        {            
            Post a = this.Posts.FindOneById(ObjectId.Parse(Guid));
            a.Comentarios.Add(comentario);
            this.Posts.Save<Post>(a);
        }
    }
}