using Microsoft.EntityFrameworkCore;
using Rare.Models;

namespace Rare.APIs
{
    public class CommentAPI
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/comments/posts/{postId}", (RareDbContext db, int postId) =>
            {
                var allComments = db.Comments
                .Include(c => c.Author)
                .Where(c => c.PostId == postId)
                .ToList();
                if (allComments.Any())
                {
                    return Results.Ok(allComments);
                }
                else
                {
                    bool postExist = db.Posts.Any(p => p.Id == postId);

                    if (postExist)
                    {
                    return Results.Ok("There are no comments for this post");

                    }
                    else
                    {
                        return Results.NotFound($"There is no post with an id of {postId}");
                    }
                }
            });

            app.MapPost("/comments", (RareDbContext db, Comment newComment) =>
            {
                newComment.CreatedOn = DateTime.Now;
                db.Comments.Add(newComment);
                db.SaveChanges();
                return Results.Ok(newComment);
            });

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