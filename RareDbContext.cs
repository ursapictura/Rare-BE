using Microsoft.EntityFrameworkCore;
using Rare.Data;
using Rare.Models;

public class RareDbContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Subscription> Subscriptions { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<User> Users { get; set; }

    public RareDbContext(DbContextOptions<RareDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(CategoryData.Categories);
        modelBuilder.Entity<Comment>().HasData(CommentData.Comments);
        modelBuilder.Entity<Post>().HasData(PostData.Posts);
        modelBuilder.Entity<Subscription>().HasData(SubscriptionData.Subscriptions);
        modelBuilder.Entity<Tag>().HasData(TagData.Tags);
        modelBuilder.Entity<User>().HasData(UserData.Users);
    }
}