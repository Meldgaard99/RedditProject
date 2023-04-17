using System; 
namespace RedditFullStack.Model
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Text { get; set; }
        public int Downvote { get; set; }
        public int Upvote { get; set; }
        public int NumberOfVotes { get; set; }
        public User User { get; set;}
         public DateTime CommentTime { get; set;}
    

    public Comment( string text, int downvote, int upvote, int numberOfVotes, User user, DateTime commenTime){

        this.Text = text; 
        this.Downvote = downvote; 
        this.Upvote = upvote;
        this.NumberOfVotes = numberOfVotes;
        this.User = user;
        this.CommentTime = commenTime;


    }
    public Comment()
    {
        CommentId = 0;
        Text = "";
        Downvote = 0;
        Upvote = 0;
        NumberOfVotes = 0;
    }
    }
}