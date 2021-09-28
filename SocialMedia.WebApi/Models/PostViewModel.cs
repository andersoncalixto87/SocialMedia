using System;
using System.Collections.Generic;


namespace SocialMedia.WebApi.Models
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Location { get; set; }
        public int Privacy { get; set; }
        public int UserId { get; set; }
        
        
    }
}