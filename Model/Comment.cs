using System; 
namespace RedditFullStack.Model
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Text { get; set; }
        //public EF kræver en id til at identificere primary keys! :)
        public int Downvote { get; set; }
        public int Upvote { get; set; }
        public int NumberOfVotes { get; set; }

        public User User { get; set;}
    

    public Comment( string text, int downvote, int upvote, int numberOfVotes, User user){

        this.Text = text; 
        this.Downvote = downvote; 
        this.Upvote = upvote;
        this.NumberOfVotes = numberOfVotes;
        this.User = user;

    }
    public Comment()
    {
        CommentId = 0;
        Text = "";
        Downvote = 0;
        Upvote = 0;
        NumberOfVotes = 0;
        User = null;
    }
    }
}