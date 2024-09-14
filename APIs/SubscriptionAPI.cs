using Microsoft.EntityFrameworkCore;
using Rare.Models;

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
                    return Results.NotFound("No subscriptions found");
                }

                return Results.Ok(userSubscriptions);

            });

            // Add New Subscription for User
            app.MapGet("/subscribe/{authorId}/{userId}", (RareDbContext db, int authorId, int userId) =>
            {
                User user = db.Users.SingleOrDefault(u => u.Id == authorId);

                if (user == null)
                {
                    return Results.NotFound("This user does not exist");
                };

                User author = db.Users.SingleOrDefault(u => u.Id == authorId);

                if (author == null)
                {
                    return Results.NotFound("This author does not exist");
                };

                if (db.Subscriptions.Any(s => s.AuthorId == authorId && s.FollowerId == userId))
                {
                    return Results.Ok("This user is already subscribed to this author");
                };

                Subscription newSubscription = new()
                {
                    AuthorId = authorId,
                    FollowerId = userId,
                    CreatedOn = DateTime.UtcNow,
                };

                db.Subscriptions.Add(newSubscription);
                db.SaveChanges();


                return Results.Ok(newSubscription);

            });

            // End/restart a User's subscription
            app.MapPatch("/subscribe/{authorId}/{userId}", (RareDbContext db, int authorId, int userId) =>
            {

            });

        }
    }
}
