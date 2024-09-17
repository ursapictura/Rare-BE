using Rare.Models;

namespace Rare_BE.DTOs
{
    public class CreatePostDto
    {
        public Post? Post { get; set; }
        public List<int>? TagIds { get; set; }
    }
}
