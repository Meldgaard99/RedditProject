
using RedditFullStack.Model;
using System.Collections.Generic;
using System.Linq;

namespace RedditFullStack.Model{

public class DataService
{
    
    private RedditContext db { get; }

    public DataService(RedditContext db) {
        this.db = db;
    }

 public List<Post> GetAllPosts()
    {
        return db.Posts.ToList();
    }

    //henter post og returner dem som en liste
    public List<Comment> GetAllComments()
    {
        return db.Comments.ToList();
    }

    // Henter post på dets id
    public Post GetPostById(int postid)
    {
        return db.Posts.Where(p => p.PostId == postid).FirstOrDefault()!;

    }

    // Henter kommentaren på dets id
  public Comment GetCommentById(int commentid)
    {
        return db.Comments.Where(p => p.CommentId == commentid).FirstOrDefault()!;
        
    }

 // Henter bruger på dets id
  public User GetUserById(int userid)
    {
        return db.Users.Where(p => p.UserId == userid).FirstOrDefault()!;
    }

// Henter alle brugere
public List<User> GetAllUsers()
    {
        return db.Users.ToList();
    }


// Udkast til post post
public string CreatePost(string title, User user, string text, int upvote, int downvote, int numberOfVotes) {

        User tempuser = db.Users.FirstOrDefault(a => a.UserId == user.UserId)!;
        if(tempuser==null){
            //db.Users.Add()
            db.Posts.Add(new Post(title,user,text, upvote, downvote, numberOfVotes));
        }
        else{
            db.Posts.Add(new Post(title,tempuser,text, upvote, downvote, numberOfVotes));
        }
        db.SaveChanges();
        return "Post created";

        }



        public string CreateComment(string text, int upvote, int downvote, int numberOfVotes, int postid) {
        var post = db.Posts.Where(p => p.PostId == postid).FirstOrDefault()!;
        //db.Add(newcomment);
        post.Comments.Add(new Comment(text, downvote, upvote, numberOfVotes));
        db.SaveChanges();
        return "Comment created";
        
        }

        public void SeedData(){

        Comment comment = db.Comments.FirstOrDefault()!;
        if(comment == null  )
        {comment = new Comment { CommentId = 1, Text = "Den har åben Torsdag og fredag fra kl 12", Downvote = 3, Upvote = 5, NumberOfVotes = 8 };
        db.Add(comment);
        //db.Add(new Comment{ Text = "Hvornår slutter påskeferien?" }); 
        db.SaveChanges();}

        /*

         public Comment PostComments(string text, int upvote, int downvote, int numberOfVotes)
    {
            Comment newcomment = new Comment(text, upvote, downvote, numberOfVotes);
        db.Add(newcomment);
        db.SaveChanges();
            return newcomment;
    }
      */
     
        }
    }  

}
