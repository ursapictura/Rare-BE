using Rare.Models;

namespace Rare.Data
{
    public class PostData
    {
        public static List<Post> Posts = new()
        {
            new() {
                Id = 1,
                AuthorId = 1,
                CategoryId = 2,
                Title = "Mr. Bennett and Mrs. Brown",
                PublicationDate = new DateTime(2024, 08, 18),
                Content = "Mr. Bennett says that it is only if the characters are real that the novel has any chance of surviving. Otherwise, die it must. But, I ask myself, what is reality? And who are the judges of reality?"
            },
            new() {
                Id = 2,
                AuthorId = 3,
                CategoryId = 10,
                Title = "The Frog That Couldn't Tie His Shoes",
                PublicationDate = new DateTime(2008, 01, 28),
                Content = "A young frog named Freddie struggles with a seemingly simple task: tying his shoes. Despite his best efforts and the helpful advice from his friends, Freddie's frustration grows as he faces a series of amusing mishaps. Ultimately, Freddie learns that perseverance and a bit of creativity can turn even the most challenging problems into opportunities for growth and friendship."
            },
            new() {
                Id = 3,
                AuthorId = 5,
                CategoryId = 11,
                Title = "Sparky Goes to Timbuktu",
                PublicationDate = new DateTime(2024, 05, 30),
                Content = "A curious young cat named Sparky embarks on a thrilling adventure to the distant city of Timbuktu. Along the way, Sparky encounters exotic landscapes, befriends fascinating characters, and uncovers the rich cultural tapestry of the region. Through his journey, Sparky discovers that true adventure lies not just in new places, but in the friendships and experiences that shape his path."
            },
            new() {
                Id = 4,
                AuthorId = 5,
                CategoryId = 6,
                Title = "The Bird Beak Conundrum",
                PublicationDate = new DateTime(2024, 06, 10),
                Content = "Set in a post-apocalyptic world where humans have vanished, the remaining wildlife faces a mysterious crisis: birds are evolving with deformed beaks, threatening their survival. A clever raven named Rook teams up with a resourceful squirrel named Nutmeg to investigate the cause of this anomaly. As they unravel the clues, they discover that the key to restoring balance lies in a hidden human artifact, leading them on a perilous journey to save their world from impending chaos."
            },
        };
    }
}