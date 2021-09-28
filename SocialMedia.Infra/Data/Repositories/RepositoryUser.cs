using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces.Repositories;

namespace SocialMedia.Infra.Data.Repositories
{
    public class RepositoryUser : Repository<User>, IRepositoryUser
    {
        private readonly SocialMediaContext _socialMediaContext;
        public RepositoryUser(SocialMediaContext socialMediaContext) : base(socialMediaContext)
        {
            _socialMediaContext = socialMediaContext;
        }
    }
}