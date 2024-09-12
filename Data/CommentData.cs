using Rare.Models;

namespace Rare.Data
{
    public class CommentData
    {
        public static List<Comment> Comments = new()
        {
            new()
            {
                Id = 1,
                AuthorId = 4,
                PostId = 4,
                Content = "Sounds like a good anime",
                CreatedOn = new DateTime(2024, 09, 10)
            },
            new()
            {
                Id = 2,
                AuthorId = 5,
                PostId = 4,
                Content = "Pitching it to Warner Brothers!",
                CreatedOn = new DateTime(2024, 09, 11)
            }
        };
    }
}