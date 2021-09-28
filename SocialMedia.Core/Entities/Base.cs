using System;

namespace SocialMedia.Core.Entities
{
    public abstract class Base
    {
        public Base()
        {
            CreatedDate = DateTime.UtcNow;
        }
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}