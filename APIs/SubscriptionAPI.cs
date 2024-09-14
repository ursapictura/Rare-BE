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
                // Find Active Subscriptions for Current User. Include Author and Author's Posts.
                var userSubscriptions = db.Subscriptions
                .Include(s => s.Author)
                .ThenInclude(a => a.Posts)
                .Where(s => s.FollowerId == userId)
                .Where(s => s.EndedOn == null)
                .ToList();

                // If an active subscription cannot be found, return NotFound
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


                // Check if User currently has an active subscription to this author
                if (db.Subscriptions.Any(s => s.AuthorId == authorId
                                        && s.FollowerId == userId
                                        && s.EndedOn == null))
                {
                    return Results.Ok("This user is already subscribed to this author");
                };

                // Create new subscription
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

            // End a User's subscription
            app.MapPatch("/subscribe/{authorId}/{userId}", (RareDbContext db, int authorId, int userId) =>
            {
                // Find User's active subscription to author.
                var subscription = db.Subscriptions.SingleOrDefault(s => s.AuthorId == authorId
                                                                    && s.FollowerId == userId
                                                                    && s.EndedOn == null);

                // If an active subscription cannot be found, return NotFound.
                if (subscription == null)
                {
                    return Results.NotFound("This user is not currently subscribed to this author");
                }

                // update EndedOn for active subscription
                subscription.EndedOn = DateTime.UtcNow;

                db.SaveChanges();
                return Results.Ok($"Subscription ended on {subscription.EndedOn}");
            });

        }
    }
}
