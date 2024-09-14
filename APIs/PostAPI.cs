using Microsoft.EntityFrameworkCore;

namespace Rare.APIs
{
    public class PostAPI
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/posts/{categoryId}", (RareDbContext db, int categoryId) =>
            {
                var postByCategory = db.Posts
                .Include(p => p.Category)
                .Select(post => new
                {
                    post.Id,
                    post.Title,
                    post.Content,
                    post.Category,
                    post.ImageURL,
                    post.PublicationDate,
                    Author = new
                    {
                        post.Author.Id,
                        post.Author.FirstName,
                        post.Author.LastName,
                        post.Author.ImageURL
                    }
                })
                .Include(p => p.Author)
                .Where(p => p.Category.Id == categoryId)
                .OrderByDescending(post => post.PublicationDate)
                .ToList();

                if (postByCategory.Any())
                {
                    return Results.Ok(postByCategory);
                }
                else
                {
                    bool categoryExist = db.Categories.Any(c => c.Id == categoryId);

                    if (categoryExist)
                    {
                        return Results.Ok($"There are no post for this category with an id of {categoryId}");

                    }
                    else
                    {
                        return Results.NotFound($"There is no category with an id of {categoryId}");
                    }
                }


            });
        }
    }
}