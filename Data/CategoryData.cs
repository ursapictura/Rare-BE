using Rare.Models;

namespace Rare.Data
{
    public class CategoryData
    {
        public static List<Category> Categories = new()
        {
            new() { Id = 1, Label = "Drama" },
            new() { Id = 2, Label = "Arts" },
            new() { Id = 3, Label = "Technology" },
            new() { Id = 4, Label = "Astronomy" },
            new() { Id = 5, Label = "Science" },
            new() { Id = 6, Label = "Sci-Fi" },
            new() { Id = 7, Label = "Fanfic" },
            new() { Id = 8, Label = "Music" },
            new() { Id = 9, Label = "Business" },
            new() { Id = 10, Label = "Health" },
            new() { Id = 11, Label = "Travel" },
            new() { Id = 12, Label = "Politics" },
            new() { Id = 13, Label = "Sports" },
            new() { Id = 14, Label = "Culture" },
            new() { Id = 15, Label = "Food" }
        };
    }
}