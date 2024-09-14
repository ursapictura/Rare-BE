using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
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
                .Select(comment => new
                {
                    comment.Id,
                    comment.Content,
                    comment.PostId,
                    comment.CreatedOn,
                    Author = new
                    {
                        comment.Author.Id,
                        comment.Author.FirstName,
                        comment.Author.LastName,
                        comment.Author.ImageURL
                    }
                })
                .Where(c => c.PostId == postId)
                .OrderByDescending(c => c.CreatedOn)
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

            app.MapDelete("/comments/{commentId}", (RareDbContext db, int addComment) =>
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