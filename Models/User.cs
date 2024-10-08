namespace Rare.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserName {  get; set; }
        public string Bio { get; set; } = "";
        public string ImageURL { get; set; } = "";
        public string? Email { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? Uid { get; set; }
        public List<Post> Posts { get; set; }
    }
}