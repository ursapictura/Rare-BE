using Rare.Models;

namespace Rare.Data
{
    public class TagData
    {
        public static List<Tag> Tags = new()
        {
            new() { Id = 1, Label = "America" },
            new() { Id = 2, Label = "Olympics" },
            new() { Id = 3, Label = "Election" },
            new() { Id = 4, Label = "Budget" },
            new() { Id = 5, Label = "Fusion" },
            new() { Id = 6, Label = "Moscow" },
            new() { Id = 7, Label = "Europe" },
            new() { Id = 8, Label = "Opinion" },
            new() { Id = 9, Label = "Currency" },
            new() { Id = 10, Label = "Gardening" },
            new() { Id = 11, Label = "Parenthood" },
            new() { Id = 12, Label = "DIY" },
            new() { Id = 13, Label = "Bird Beaks <>" }
        };
    }
}