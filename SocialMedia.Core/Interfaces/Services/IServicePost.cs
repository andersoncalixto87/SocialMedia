using System.Collections.Generic;
using SocialMedia.Core.Entities;

namespace SocialMedia.Core.Interfaces.Services
{
    public interface IServicePost
    {
        IEnumerable<Post> GetPosts();
        IEnumerable<Post> GetPostsByUser(int id);
        IEnumerable<Comment> GetComments(int id);

        Post GetPost(int id);

        void InsertPost(Post post);

        bool UpdatePost(Post post);

        bool DeletePost(int id);
    }
}