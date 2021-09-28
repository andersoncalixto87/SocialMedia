using System.ComponentModel.DataAnnotations.Schema;

namespace SocialMedia.Core.Entities
{

    public class UserHobby : Base
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int HobbyId { get; set; }
        public Hobby Hobby { get; set; }
        
    }
}