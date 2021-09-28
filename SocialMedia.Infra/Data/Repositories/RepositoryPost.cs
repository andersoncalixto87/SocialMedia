using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces.Repositories;

namespace SocialMedia.Infra.Data.Repositories
{
    public class RepositoryPost : Repository<Post> ,IRepositoryPost
    {
        private readonly SocialMediaContext _socialMediaContext;
        public RepositoryPost(SocialMediaContext socialMediaContext) : base(socialMediaContext)
        {
            _socialMediaContext = socialMediaContext;
        }

        public IEnumerable<Post> GetPostsByUser(int userId)
        {
            return _socialMediaContext.Post.Where(c => c.UserId == userId).ToList();
        }

        public IEnumerable<Comment> GetComments(int id)
        {
            return _socialMediaContext.Comment.Where(c => c.PostId == id).ToList();
        }

    }
}