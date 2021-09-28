using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialMedia.Core.Entities
{
    public class Comment : Base
    {
        public string Description { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int PostId { get; set; }
 
        public Post Post { get; set; }
        public IEnumerable<CommentLike> Likes { get; set; }
    }
}