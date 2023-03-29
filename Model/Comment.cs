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
    

    public Comment( string text, int downvote, int upvote, int numberOfVotes, int commentid){

        this.Text = text; 
        this.Downvote = downvote; 
        this.Upvote = upvote;
        this.NumberOfVotes = numberOfVotes;
        this.CommentId = commentid;



    }
    public Comment()
    {

    }
    }
}