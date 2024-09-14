using Microsoft.EntityFrameworkCore;
using Rare.Models;

namespace Rare.APIs
{
    public class SubscriptionAPI
    {
        public static void Map(WebApplication app)
        {
            // Get User Subscriptions
            app.MapGet("/subscription/{userId}", (RareDbContext db, int userId) =>
            {
                // Get all subscriptions that match FollowerId. Then 
                var subList = db.Subscriptions
                    .Where(s => s.FollowerId == userId && s.EndedOn == null)
                    .Select(s => s.AuthorId)
                    .ToList();

                var includeAuthorsList = db.Posts
                                        .Where(p => subList.Contains(p.AuthorId))  
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
                                        .OrderByDescending(post => post.PublicationDate)
                                        .ToList();

                return Results.Ok(includeAuthorsList);

            });

            // Add New Subscription for User
            app.MapGet("/subscription/{userId}/add/{authorId}", (RareDbContext db, int authorId, int userId) =>
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
            app.MapPatch("/subscription/{userId}/end/{authorId}", (RareDbContext db, int authorId, int userId) =>
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
