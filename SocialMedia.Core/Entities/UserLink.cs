using System.ComponentModel.DataAnnotations.Schema;
using SocialMedia.Core.Enums;

namespace SocialMedia.Core.Entities
{
    public class UserLink : Base
    {
        public string Description { get; set; }
        public LinkType LinkType { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

    }
}