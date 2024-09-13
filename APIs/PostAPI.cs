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
                .Include(p => p.Author)
                .Include(p => p.Category)
                .Where(c => c.CategoryId == categoryId)
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
                        return Results.Ok($"There are no post for this category with an if of {categoryId}");

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