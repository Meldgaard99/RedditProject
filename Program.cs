using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using RedditFullStack.Model;

var builder = WebApplication.CreateBuilder(args);

// Sætter CORS så API'en kan bruges fra andre domæner
var AllowSomeStuff = "_AllowSomeStuff";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowSomeStuff, builder => {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});



// Tilføj DbContext factory som service.
builder.Services.AddDbContext<RedditContext>(options =>
  options.UseSqlite(builder.Configuration.GetConnectionString("ContextSQLite")));


// Tilføj DataService så den kan bruges i endpoints
builder.Services.AddScoped<DataService>();



var app = builder.Build();


app.UseHttpsRedirection();
app.UseCors(AllowSomeStuff);

using (var db = new RedditContext())
{
    Console.WriteLine($"Database path: {db.DbPath}.");

    var newuser = new User( "Rasmus");

    // Create
    Console.WriteLine("Submitting data to DB");
    db.Add(new Post("Titel",newuser, "test text", 2, 4, 5)); //Test om der er hul til post tablen!
    db.Add(new User( "Mads"));
    db.SaveChanges();

    /*// Delete
    Console.WriteLine("Slet post");
    //var Post= db.Posts.OrderBy(b => b.PostId).Last();
    //Console.WriteLine("Slet task");
    //db.Posts.Remove(Post);
    db.SaveChanges();
*/
    }

// Henter alle post


app.Use(async (context, next) =>
{
    context.Response.ContentType = "application/json; charset=utf-8";
    await next(context);
});

app.MapGet("/get/all/posts", (DataService service) =>
{
    return service.GetAllPosts();
});

// Henter post på dets id
app.MapGet("/get/post/{postid}", (DataService service, int postid) =>
{
    return service.GetPostById(postid);  
});

// Henter alle kommentarer
app.MapGet("/get/all/comments", (DataService service) =>
{
    return service.GetAllComments();
});

// Henter en kommmentar på dets id
app.MapGet("/get/comment/{commentid}", (DataService service, int commentid) =>
{
    return service.GetCommentById(commentid);  
});

// Henter user på bruger id
app.MapGet("/get/user/{userid}", (DataService service, int userid) =>
{
    return service.GetUserById(userid);  
});

// Henter alle brugere
app.MapGet("/get/all/users", (DataService service) =>
{
    return service.GetAllUsers();
});


// Read
    Console.WriteLine("Find det sidste task");
    

//app.MapGet("/", () => "Hello World!");

/* Udkast til post post
app.MapPost("/createpost", (DataService service, Post data) =>
 {
     return service.CreatePost(data.Title, data.User, data.Text, data.NumberOfVotes);
 });
*/



app.MapPost("/createpost", (DataService service, PostDTO data) =>
 {
     return service.CreatePost(data.title, data.user, data.text, data.upvote, data.downvote, data.numberOfVotes);
 });


 app.MapPost("/createcomment", (DataService service, CommentDTO data) =>
 {
     return service.CreateComment(data.text, data.downvote, data.upvote, data.numberOfVotes, data.commentid);

 });



app.Run();
 record PostDTO(string title, User user, string text, int upvote, int downvote, int numberOfVotes);
 record CommentDTO(string text, int downvote, int upvote, int numberOfVotes, int commentid);


