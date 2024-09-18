namespace Rare.APIs
{
    public class CategoryAPI
    {
        public static void Map(WebApplication app)
        {
            // get all categories
            app.MapGet("/categories", (RareDbContext db) =>
            {
                var allCategories = db.Categories.OrderBy(c => c.Label).ToList();
                if (allCategories.Any())
                {
                    return Results.Ok(allCategories);
                }
                else
                {
                    return Results.Ok("There are no categories to display");
                }
            });

        }
    }
}