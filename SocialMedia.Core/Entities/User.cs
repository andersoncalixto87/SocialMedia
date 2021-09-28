using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialMedia.Core.Entities
{
    public class User : Base
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ProfileImage { get; set; }
        public string CoverImage { get; set; }        
        public string Bio { get; set; }
        public bool IsPrivate { get; set; }
        public IEnumerable<UserHobby> Hobbies { get; set; }
        public IEnumerable<UserLink> Links { get; set; }
        public UserDetails UserDetails { get; set; }
        

    }
}