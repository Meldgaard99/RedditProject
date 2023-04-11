
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

        // Gamle version
        /*public string CreateComment(string text, int upvote, int downvote, int numberOfVotes, int postid) {
        var post = db.Posts.Where(p => p.PostId == postid).FirstOrDefault()!;
        //db.Add(newcomment);
        post.Comments.Add(new Comment(text, downvote, upvote, numberOfVotes));
        db.SaveChanges();
        return "Comment created";
        
        }*/

        // Version 2.0
        public string CreateComment(string text, int upvote, int downvote, int numberOfVotes, int postid, User user) {

        User tempuser = db.Users.FirstOrDefault(a => a.UserId == user.UserId)!;
        if(tempuser==null){
            //db.Users.Add()
            db.Comments.Add(new Comment(text, upvote, downvote, numberOfVotes, user));
        }
        else{
            db.Comments.Add(new Comment(text, upvote, downvote, numberOfVotes, tempuser));
        }
        db.SaveChanges();
        return "Comment created";

        }


       public bool PostVoting(int postId, User user, bool UpvoteOrDownvote)
{
    {
        // Find indlægget med det givne postId
        var post = db.Posts.FirstOrDefault(p => p.PostId == postId);
        if (post == null)
        {
        
            return false ;
        }

        // Hvis UpvoteOrDownvote er sat som true upvote
        // mulig implementering af at add en user til en liste, så personen ikke kan vote flere gange 
        
        if (UpvoteOrDownvote == true)
        {
            post.Upvote++;
            post.NumberOfVotes++;
           // post.UserVotes.Add(tempUser);
            db.SaveChanges();

            return true;

        // Hvis UpvoteOrDownvote er sat som false downvote
        // mulig implementering af at fjerne en user fra en liste, 
        } else if (UpvoteOrDownvote == false)
        {
            post.Downvote--;
            post.NumberOfVotes++;
          
          //post.UserVotes.Remove(tempUser);
              db.SaveChanges();
            return false;
        } else
        {
            return false;
        } 
    }
}



 public bool CommentVoting(int commentId, User user, bool UpvoteOrDownvote)
{
    {
        // Find indlægget med det givne postId
        var comment = db.Comments.FirstOrDefault(p => p.CommentId == commentId);
        if (comment == null)
        {
        
            return false ;
        }

        // Hvis UpvoteOrDownvote er sat som true upvote
        // mulig implementering af at add en user til en liste, så personen ikke kan vote flere gange 
        
        if (UpvoteOrDownvote == true)
        {
            comment.Upvote++;
            comment.NumberOfVotes++;
           // post.UserVotes.Add(tempUser);
            db.SaveChanges();

            return true;

        // Hvis UpvoteOrDownvote er sat som false downvote
        // mulig implementering af at fjerne en user fra en liste, 
        } else if (UpvoteOrDownvote == false)
        {
            comment.Downvote--;
            comment.NumberOfVotes++;
          
          //post.UserVotes.Remove(tempUser);
              db.SaveChanges();
            return false;
        } else
        {
            return false;
        } 
    }
}

        public void SeedData(){

        Comment comment = db.Comments.FirstOrDefault()!;
        if(comment == null  )
        {comment = new Comment { CommentId = 1, Text = "Den har åben Torsdag og fredag fra kl 12", Downvote = 3, Upvote = 5, NumberOfVotes = 8 };
        db.Add(comment);


    //Tilføjer user hvis det 0
        User user = db.Users.FirstOrDefault()!; 
        if (user == null && db.Users.Count() < 4  ) 
        { user = new User ("Rasmus") {UserId = 1};
        { user = new User ("ML") {UserId = 2};
        { user = new User ("Mads") {UserId = 3};
        db.Add(user);
        
        
        db.SaveChanges();}
     
        }
    }  

        }
        }

        internal object CreateComment(string text, int downvote, int upvote, int numberOfVotes, int postid)
        {
            throw new NotImplementedException();
        }

        internal object CreateComment(string text, int downvote, int upvote, int numberOfVotes, int postid, object user)
        {
            throw new NotImplementedException();
        }
    }



}