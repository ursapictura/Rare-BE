using Microsoft.EntityFrameworkCore;
using Rare.Models;

namespace Rare.APIs
{
    public class UserAPI
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/users/{userId}", (RareDbContext db, int userId) =>
            {
                User? user = db.Users
                    .Include(u => u.Posts)
                    .ThenInclude(p => p.Category)
                    .FirstOrDefault(u => u.Id == userId);

                if (user == null)
                {
                    return Results.NotFound("Invalid user Id");
                }

                return Results.Ok(new
                {
                    user.Id,
                    user.FirstName,
                    user.LastName,
                    user.UserName,
                    user.Bio,
                    user.ImageURL,
                    user.Email,
                    user.CreatedOn,
                    Posts = user.Posts.Select(p => new
                    {
                        p.Id,
                        p.Title,
                        p.Category,
                        p.PublicationDate,
                        p.ImageURL,
                        p.Content
                    }),
                    SubscriberCount = db.Subscriptions.Count(s => s.AuthorId == userId && s.EndedOn == null)
                });
            });

            app.MapGet("/checkuser/{uid}", (RareDbContext db, string uid) =>
            {
                User? userCheck = db.Users.FirstOrDefault(u => u.Uid == uid);

                if (userCheck == null)
                {
                    return Results.NotFound("User is not registered");
                }

                return Results.Ok(userCheck);
            });

            app.MapPost("/users", (RareDbContext db, User userRegister) =>
            {
                User newUser = new()
                {
                    FirstName = userRegister.FirstName,
                    LastName = userRegister.LastName,
                    UserName = userRegister.UserName,
                    Bio = userRegister.Bio,
                    ImageURL = userRegister.ImageURL,
                    Email = userRegister.Email,
                    CreatedOn = DateTime.Now,
                    Uid = userRegister.Uid
                };

                db.Users.Add(newUser);
                db.SaveChanges();

                return Results.Created($"/users/{newUser.Id}", newUser);
            });
        }
    }
}