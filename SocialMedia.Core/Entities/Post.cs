using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using SocialMedia.Core.Enums;

namespace SocialMedia.Core.Entities
{
    public class Post : Base
    {
        public string Description { get; set; }
        public string Image { get; set; }
        public string Location { get; set; }
        public PrivacyStatus Privacy { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual IEnumerable<PostLike> Likes { get; set; }
        public virtual IEnumerable<Comment> Comments { get; set; }
        
    }
}