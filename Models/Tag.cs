using System.ComponentModel.DataAnnotations;

namespace Rare.Models
{
    public class Tag
    {
        public int Id { get; set; }
        [Required]
        public string Label { get; set; }
        public List<Post>? Posts { get; set; }
    }
}