using System.ComponentModel.DataAnnotations.Schema;
using RedditFullStack.Model;

namespace RedditFullStack.Model

{
    public class Post
    {
        public int PostId { get; set; }        
        public string Title { get; set; }
        //[ForeignKey("User")]
        public User User { get; set; }
        public string Text { get; set; }
        public int Downvote { get; set; }
        public int Upvote { get; set; }
        public int NumberOfVotes { get; set; }
        public List<Comment> Comments {get; set;} = new List<Comment>();


    public Post(string title, User user, string text, int upvote, int downvote, int numberOfVotes){

        this.Title = title;
        this.User = user;
        this.Text = text;
        this.Upvote = upvote;
        this.Downvote = downvote;
        this.NumberOfVotes = numberOfVotes;

    }

    public Post() {
        PostId = 0;
        Title = "";
        User = null;
        Text= "";
        Upvote= 0;
        Downvote = 0;

    }
    }


/*public override string ToString()
    {
        return $"Id: {PostId}, Title: {Title}, User: {User}, Text: {Text}, Upvotes: {Upvotes}, Downvotes: {Downvotes}, NumberOfVotes: {NumberOfVotes}";
    }*/

    }