using System.ComponentModel.DataAnnotations.Schema;
using SocialMedia.Core.Enums;

namespace SocialMedia.Core.Entities
{
    public class UserDetails : Base
    {
        public string CurrentCity { get; set; }
        public string Hometown { get; set; }
        public RelationshipStatus Relationship { get; set; }
        public string WorkCompany { get; set; }
        public string JobTitle { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}