using Microsoft.EntityFrameworkCore;

namespace Rare.APIs
{
    public class SubscriptionAPI
    {
        public static void Map(WebApplication app)
        {
            // Get User Subscriptions
            app.MapGet("/subscribe/{userId}", (RareDbContext db, int userId) =>
            {
                var userSubscriptions = db.Subscriptions
                .Include(s => s.Author)
                .ThenInclude(a => a.Posts)
                .Where(s => s.FollowerId == userId)
                .Where(s => s.EndedOn == null)
                .ToList();

                if (!userSubscriptions.Any())
                {
                    return Results.Ok("No subscriptions found");
                }

                return Results.Ok(userSubscriptions);

            });

        }
    }
}
