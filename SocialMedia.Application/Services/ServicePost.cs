using System;
using System.Collections.Generic;
using System.Linq;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Exceptions;
using SocialMedia.Core.Interfaces.Repositories;
using SocialMedia.Core.Interfaces.Services;

namespace SocialMedia.Core.Services
{
    public class ServicePost : IServicePost
    {
        private readonly IRepositoryPost _repositoryPost;
        private readonly IRepositoryUser _repositoryUser;
        public ServicePost(IRepositoryPost repositoryPost,IRepositoryUser repositoryUser)
        {
            _repositoryPost = repositoryPost;
            _repositoryUser = repositoryUser;
        }
        public bool DeletePost(int id)
        {   
            var post = _repositoryPost.GetById(id);            
            _repositoryPost.Remove(post);
            return true;
        }

        public Post GetPost(int id)
        {
            return _repositoryPost.GetById(id);
        }

        public IEnumerable<Post> GetPosts()
        {
            var posts = _repositoryPost.GetAll(); 
            return posts;
        }

        public IEnumerable<Post> GetPostsByUser(int id)
        {
            var posts = _repositoryPost.GetPostsByUser(id); 
            return posts;
        }

        public IEnumerable<Comment> GetComments(int id)
        {
            var comments = _repositoryPost.GetComments(id); 
            return comments;
        }

        public void InsertPost(Post post)
        {
            var user = _repositoryUser.GetById(post.UserId);
            if (user == null)
            {
                throw new BusinessException($"User {post.UserId} doesn't exist");
            }

            var userPost = _repositoryPost.GetPostsByUser(post.UserId);
            if (userPost.Count() < 10)
            {
                var lastPost = userPost.OrderByDescending(x=> x.CreatedDate).FirstOrDefault();
                if (lastPost != null && (DateTime.Now - lastPost.CreatedDate).TotalDays < 7)
                {
                    throw new BusinessException("You are not able to publish the post");
                }
            }

            if (post.Description.ToLower().Contains("sex"))
            {
                throw new BusinessException($"Content not allowed");
            }

            _repositoryPost.Add(post);            
        }

        public bool UpdatePost(Post post)
        {
            if (post.Description.ToLower().Contains("sex"))
            {
                throw new BusinessException($"Content not allowed");
            }
            var existingPost = _repositoryPost.GetById(post.Id);
            existingPost.Image = post.Image;
            existingPost.Description = post.Description;

            _repositoryPost.Update(existingPost);            
            return true;
        }
    }
}