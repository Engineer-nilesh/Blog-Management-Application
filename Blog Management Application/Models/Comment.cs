using Blog_Management_Application.ValidationAttributes;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Blog_Management_Application.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required,StringLength(1000)]
        [CommentTextValidator]
        public string Text { get; set; }
        public DateTime PostedOn { get; set; }
        // Foreign key for BlogPost
        public int BlogPostId { get; set; }
        public BlogPost? BlogPost { get; set; }
    }
}
