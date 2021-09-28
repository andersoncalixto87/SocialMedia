using System.ComponentModel.DataAnnotations.Schema;

namespace SocialMedia.Core.Entities
{
    public class Hobby : Base
    {
        public string Description { get; set; }
        public string PathImage { get; set; }
    }
}