using System;
using System.ComponentModel.DataAnnotations;

namespace BlogPostsFrontend.Models.BlogPosts
{
    public class BlogPost
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please provide a description")]
        public string Description { get; set; }

        public DateTime PublicationDate { get; set; } = DateTime.UtcNow;

        public string Author { get; set; }
    }
}
