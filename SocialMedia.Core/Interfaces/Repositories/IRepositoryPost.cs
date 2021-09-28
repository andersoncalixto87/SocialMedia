using System.Collections.Generic;
using SocialMedia.Core.Entities;

namespace SocialMedia.Core.Interfaces.Repositories
{
    public interface IRepositoryPost : IRepository<Post>
    {
        IEnumerable<Post> GetPostsByUser(int userId);   
        IEnumerable<Comment> GetComments(int id);    
    }
}