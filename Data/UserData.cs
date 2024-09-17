using Rare.Models;

namespace Rare.Data
{
    public class UserData
    {
        public static List<User> Users = new()
        {
            new()
            {
                Id = 1,
                FirstName = "Virginia",
                LastName = "Woolf",
                UserName = "deceased",
                Email = "whosafraid@me.com",
                Bio = "Now deceased but still at it.",
                CreatedOn = new DateTime(2024, 07, 10)
            },
            new()
            {
                Id = 2,
                FirstName = "Alex",
                LastName = "Jones",
                UserName = "DJ Hot",
                Email = "alexjones@gmail.com",
                Bio = "Local weatherman turned vigilante techno DJ",
                CreatedOn = new DateTime(2019, 03, 20)
            },
            new()
            {
                Id = 3,
                FirstName = "Taylor",
                LastName = "Harrison",
                UserName = "Banana",
                Email = "funkyfrog@yahoo.com",
                Bio = "Shoulda bought Apple",
                CreatedOn = new DateTime(1998, 07, 10)
            },
            new()
            {
                Id = 4,
                FirstName = "Odie",
                LastName = "Dicaprio",
                UserName = "coding.wizard",
                Email = "lastnamejoseph@aol.com",
                Bio = "I'm watching anime",
                CreatedOn = new DateTime(2023, 09, 01)
            },
            new()
            {
                Id = 5,
                FirstName = "Quincy",
                LastName = "Quayle",
                UserName = "quincy",
                Email = "notdan@notdan.com",
                Bio = "Born in 1955, Quincy Quayle grew up in the city of New Mammoth, Montana. He is predeceased by carnival employees Jack and Barbara. No relation.",
                CreatedOn = new DateTime(2024, 04, 01)
            },
        };
    }
}