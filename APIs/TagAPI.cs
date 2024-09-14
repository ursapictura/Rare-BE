using Rare.Models;

namespace Rare.APIs
{
    public class TagAPI
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/tags", (RareDbContext db) =>
            {
                return db.Tags.Select(t => new
                {
                    t.Id,
                    t.Label
                });
            });

            app.MapPost("/tags", (RareDbContext db, Tag addTag) =>
            {
                if (db.Tags.Any(t => t.Label == addTag.Label))
                {
                    return Results.Ok("Tag already exists");
                }

                Tag newTag = new() { Label = addTag.Label };

                db.Tags.Add(newTag);
                db.SaveChanges();
                return Results.Created($"/tags/{newTag.Id}", newTag);
            });
        }
    }
}