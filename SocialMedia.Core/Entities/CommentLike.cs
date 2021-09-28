using System.ComponentModel.DataAnnotations.Schema;

namespace SocialMedia.Core.Entities
{
    public class CommentLike : Base
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int CommentId { get; set; }
        public Comment Comment { get; set; }
    }
}