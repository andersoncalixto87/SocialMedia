using System;

namespace SocialMedia.WebApi.Models
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
 
        
    }
}