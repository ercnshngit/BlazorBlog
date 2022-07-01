using System.ComponentModel.DataAnnotations;

namespace BlazorBlog.Shared
{
    public class BlogPost
    {
        public int Id { get; set; }

        [Required, StringLength(20, ErrorMessage = "20 karakter en fazla")]
        public string Slug { get; set; }

        [Required]
        public string Title { get; set; }

        public string Content { get; set; }

        [Required]
        public string Author { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        public bool IsPublished { get; set; } = true;

        public bool IsDeleted { get; set; } = false;
    }
}
