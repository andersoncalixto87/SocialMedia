using AutoMapper;
using SocialMedia.Core.Entities;
using SocialMedia.WebApi.Models;

namespace SocialMedia.WebApi.Configuration
{
    public class AutoMapperConfig: Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Post, PostViewModel>().ReverseMap();
            CreateMap<PostLike, PostLikeViewModel>().ReverseMap();
            CreateMap<User, UserViewModel>().ReverseMap();
            CreateMap<Comment, CommentViewModel>().ReverseMap();
        }
    }
}