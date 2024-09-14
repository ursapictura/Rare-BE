using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Rare.Models;

namespace Rare.APIs
{
    public class CommentAPI
    {
        public static void Map(WebApplication app)
        {

            // create a comment
            app.MapPost("/comments", (RareDbContext db, Comment newComment) =>
            {
                if (!db.Posts.Any(post => post.Id == newComment.PostId))
                {
                    return Results.NotFound("No post found.");
                }
                else if (!db.Users.Any(user => user.Id == newComment.AuthorId))
                {
                    return Results.NotFound("No user found.");
                }
                Comment addComment = new()
                {
                    AuthorId = newComment.AuthorId,
                    PostId = newComment.PostId,
                    Content = newComment.Content,
                    CreatedOn = DateTime.Now,


                };
                db.Comments.Add(addComment);
                db.SaveChanges();
                return Results.Ok(addComment);
            });

            //delete a comment
            app.MapDelete("/comments/{commentId}", (RareDbContext db, int commentId) =>
            {
                Comment removeComment = db.Comments.SingleOrDefault(c => c.Id == commentId);
                if (removeComment != null)
                {
                    db.Comments.Remove(removeComment);
                    db.SaveChanges();
                    return Results.NoContent();
                }
                else
                {
                    return Results.NotFound($"No comment was found with an id of {commentId}");
                };
            });
        }
    }
}