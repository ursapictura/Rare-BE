using Microsoft.EntityFrameworkCore;
using Rare.Models;
using Rare_BE.DTOs;

namespace Rare.APIs
{
    public class PostAPI
    {
        public static void Map(WebApplication app)
        {
            // get all posts
            app.MapGet("/posts", (RareDbContext db) =>
            {
                return db.Posts
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
                                post.Author.UserName,
                                post.Author.ImageURL
                            }
                        })
                        .OrderByDescending(post => post.PublicationDate)
                        .ToList();
            });

            // get single post + post details
            app.MapGet("/posts/{postId}", (RareDbContext db, int postId) =>
            {
                Post post = db.Posts
                    .Include(post => post.Category)
                    .Include(post => post.Author)
                    .Include(post => post.Tags)
                    .Include(post => post.Comments)
                    .ThenInclude(comment => comment.Author)
                    .SingleOrDefault(post => post.Id == postId);

                if (post == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(new
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
                        post.Author.UserName,
                        post.Author.ImageURL
                    },
                    Tags = post.Tags.Select(tag => new
                    {
                        tag.Id,
                        tag.Label
                    }),
                    Comments = post.Comments
                        .OrderBy(c => c.CreatedOn)
                        .Select(comment => new
                    {
                        comment.Id,
                        comment.Content,
                        comment.CreatedOn,
                        Author = new
                        {
                            comment.Author.Id,
                            comment.Author.FirstName,
                            comment.Author.LastName,
                            comment.Author.UserName,
                            comment.Author.ImageURL
                        },
                    })
                 });
            });

            // create post
            app.MapPost("/posts", (RareDbContext db, Post newPost) =>
            {

                if (!db.Categories.Any(category => category.Id == newPost.CategoryId))
                {
                    return Results.NotFound("No category found.");
                }
                else if (!db.Users.Any(user => user.Id == newPost.AuthorId))
                {
                    return Results.NotFound("No user found.");
                }
                
                Post addPost = new()
                {
                    AuthorId = newPost.AuthorId,
                    CategoryId = newPost.CategoryId,
                    Title = newPost.Title,
                    Content = newPost.Content,
                    PublicationDate = DateTime.Now,
                    ImageURL = newPost.ImageURL,
                };
                db.Posts.Add(addPost);
                db.SaveChanges();
                return Results.Created($"posts/{addPost.Id}", addPost);
            });

            // update post
            app.MapPut("/posts/{postId}", (RareDbContext db, int postId, Post post) =>
            {
                Post postToUpdate = db.Posts.SingleOrDefault(post => post.Id == postId);

                if (postToUpdate == null)
                {
                    return Results.NotFound("No post found.");
                }
                else if (!db.Categories.Any(category => category.Id == post.CategoryId))
                {
                    return Results.NotFound("No category found.");
                }
                else if (!db.Users.Any(user => user.Id == post.AuthorId))
                {
                    return Results.NotFound("No user found.");
                }

                postToUpdate.Title = post.Title;
                postToUpdate.Content = post.Content;
                postToUpdate.ImageURL = post.ImageURL;
                postToUpdate.CategoryId = post.CategoryId;
                postToUpdate.AuthorId = post.AuthorId;

                db.SaveChanges();
                return Results.Ok(postToUpdate);
            });

            // delete post
            app.MapDelete("/posts/{postId}", (RareDbContext db, int postId) =>
            {
                Post post = db.Posts.SingleOrDefault(post => post.Id == postId);

                if (post == null)
                {
                    return Results.NotFound();
                }

                db.Posts.Remove(post);
                db.SaveChanges();
                return Results.NoContent();
            });

            // get posts by category id
            app.MapGet("/posts/categories/{categoryId}", (RareDbContext db, int categoryId) =>
            {
                var postByCategory = db.Posts
                .Where(p => p.Category.Id == categoryId)
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
                        post.Author.UserName,
                        post.Author.ImageURL
                    }
                })
                .OrderByDescending(post => post.PublicationDate)
                .ToList();

                if (postByCategory.Any())
                {
                    return Results.Ok(postByCategory);
                }
                else
                {
                    return Results.Ok(new List<object>());
                }
            });

            // search posts
            app.MapGet("/posts/search", (RareDbContext db, string searchValue) =>
            {
                var searchResults = db.Posts
                    .Where(post =>
                        post.Title.ToLower().Contains(searchValue.ToLower()) ||
                        post.Content.ToLower().Contains(searchValue.ToLower()) ||
                        post.Category != null && post.Category.Label.ToLower().Contains(searchValue.ToLower()) ||
                        post.Author.FirstName.ToLower().Contains(searchValue.ToLower()) ||
                        post.Author.LastName.ToLower().Contains(searchValue.ToLower()) ||
                        post.PublicationDate.ToString().Contains(searchValue) ||
                        post.Tags.Any(tag => tag.Label.ToLower().Contains(searchValue.ToLower()))
                    )
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
                             post.Author.UserName,
                             post.Author.ImageURL
                         }
                     })
                    .ToList();

                return searchResults.Any() ? Results.Ok(searchResults) : Results.StatusCode(204);
            });
                   
        }
    }
}