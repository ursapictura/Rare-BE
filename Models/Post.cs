using System.ComponentModel.DataAnnotations;

namespace Rare.Models
{
    public class Post
    {
        public int Id { get; set; }
        [Required]
        public int AuthorId { get; set; }
        public User Author { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [Required]
        public string Title { get; set; }
        public DateTime PublicationDate { get; set; }
        public string ImageURL { get; set; } = "";
        public string Content { get; set; }
        public List<Tag>? Tags { get; set; }
    }
}