using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SocialMedia.Core.Entities
{
    public class PostLike : Base
    {
        public int UserId { get; set; }      
        
        public User User { get; set; }
        public int PostId { get; set; }
       
        public Post Post { get; set; }
    }
}