using Microsoft.EntityFrameworkCore;
using Rare.Models;

namespace Rare.APIs
{
    public class PostAPI
    {
        public static void Map(WebApplication app)
        {
            // get all posts
            app.MapGet("/posts", (RareDbContext db) =>
            {
                return db.Posts.ToList();
            });

            // get single post + post details
            app.MapGet("/posts/{id}", (RareDbContext db, int id) =>
            {
                Post post = db.Posts.SingleOrDefault(post => post.Id == id);

                if (post == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(post);
            });

            // create post
            app.MapPost("/posts", (RareDbContext db, Post newPost) =>
            {
                db.Posts.Add(newPost);
                db.SaveChanges();
                return Results.Created($"posts/{newPost.Id}", newPost);
            });

            // update post
            app.MapPut("/posts/{id}", (RareDbContext db, int id, Post post) =>
            {
                Post postToUpdate = db.Posts.SingleOrDefault(post => post.Id == id);

                if (postToUpdate == null)
                {
                    return Results.NotFound();
                }

                postToUpdate.Title = post.Title;
                postToUpdate.Content = post.Content;
                postToUpdate.ImageURL = post.ImageURL;
                postToUpdate.Category = post.Category;
                postToUpdate.Tags = post.Tags;

                db.SaveChanges();
                return Results.Ok(postToUpdate);
            });

            // delete post
            app.MapDelete("/posts/{id}", (RareDbContext db, int id) =>
            {
                Post post = db.Posts.SingleOrDefault(post => post.Id == id);

                if (post == null)
                {
                    return Results.NotFound();
                }

                db.Posts.Remove(post);
                db.SaveChanges();
                return Results.NoContent();
            });

            // search posts
            app.MapGet("/posts/search", (RareDbContext db, string searchValue) =>
            {
                var searchResults = db.Posts
                    .Include(post => post.Category)
                    .Where(post =>
                        post.Title.ToLower().Contains(searchValue.ToLower()) ||
                        post.Content.ToLower().Contains(searchValue.ToLower()) ||
                        post.Category != null && post.Category.Label.ToLower().Contains(searchValue.ToLower()) ||
                        post.Author.FirstName.ToLower().Contains(searchValue.ToLower()) ||
                        post.Author.LastName.ToLower().Contains(searchValue.ToLower()) ||
                        post.PublicationDate.ToString().Contains(searchValue)
                    )
                    .Select(post => new
                    {
                        post.Id,
                        post.Title,
                        post.Content,
                        Category = post.Category != null ? post.Category.Label : null,
                        post.Author.FirstName,
                        post.Author.LastName,
                        post.PublicationDate
                    })
                    .ToList();

                return searchResults.Any() ? Results.Ok(searchResults) : Results.StatusCode(204);
            });
        }
    }
}