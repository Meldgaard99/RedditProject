
using RedditFullStack.Model;
using System.Collections.Generic;
using System.Linq;

namespace RedditFullStack.Model
{

    public class DataService
    {

        private RedditContext db { get; }

        public DataService(RedditContext db)
        {
            this.db = db;
        }

        //Henter alle Posts og returner dem som en liste
        public List<Post> GetAllPosts()
        {
            return db.Posts.ToList();
        }

        //henter alle comments og returner dem som en liste
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


        // Laver en post
        public string CreatePost(string title, User user, string text, int upvote, int downvote, int numberOfVotes)
        {
            //Checker om brugeren findes 
            User tempuser = db.Users.FirstOrDefault(a => a.UserId == user.UserId)!;
            if (tempuser == null)
            {
                db.Posts.Add(new Post(title, user, text, upvote, downvote, numberOfVotes, DateTime.Now));
                //Laver et post med en bruger
            }
            else
            {
                db.Posts.Add(new Post(title, tempuser, text, upvote, downvote, numberOfVotes, DateTime.Now));
                //Laver et post 
            }
            db.SaveChanges();
            return "Post created";

        }

        public string CreateComment(string text, int upvote, int downvote, int numberOfVotes, int postid, User user)
        {

            User tempuser = db.Users.FirstOrDefault(a => a.UserId == user.UserId)!;
            if (tempuser == null)
            {

                db.Comments.Add(new Comment(text, upvote, downvote, numberOfVotes, user));
                //Laver en comment med en bruger
            }
            else
            {
                db.Comments.Add(new Comment(text, upvote, downvote, numberOfVotes, tempuser));
                //Laver en comment 
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
                    //Hvis post ikke findes, returnere null
                    return false;
                }

                // Hvis UpvoteOrDownvote er sat som true upvote

                if (UpvoteOrDownvote == true)
                {
                    post.Upvote++;
                    post.NumberOfVotes++;
                    db.SaveChanges();

                    return true;

                }
                else if (UpvoteOrDownvote == false)
                {
                    post.Downvote--;
                    post.NumberOfVotes++;

                    //post.UserVotes.Remove(tempUser);
                    db.SaveChanges();
                    return false;
                }
                else
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

                    return false;
                }

                // Hvis UpvoteOrDownvote er sat som true upvote

                if (UpvoteOrDownvote == true)
                {
                    comment.Upvote++;
                    comment.NumberOfVotes++;
                    db.SaveChanges();

                    return true;

                    // Hvis UpvoteOrDownvote er sat som false downvote
                }
                else if (UpvoteOrDownvote == false)
                {
                    comment.Downvote--;
                    comment.NumberOfVotes++;

                    db.SaveChanges();
                    return false;
                }
                else
                {
                    return false;
                }
            }
        }



        public void SeedData()
        {

            Comment comment = db.Comments.FirstOrDefault()!;
            if (comment == null && db.Comments.Count() < 1)
            {
                User user1 = new User("Rasmus") { UserId = 1 };
                comment = new Comment { CommentId = 1, Text = "Den har åben Torsdag og fredag fra kl 12", User = user1, Downvote = 3, Upvote = 5, NumberOfVotes = 8 };
                db.Add(comment);


            }
        }


    }
}

/*
        public void SeedData()
        {
            Post post = db.Posts.FirstOrDefault()!;
            if (post == null)
            {
                User user1 = new User("Boes");

                post = new Post { PostId = 1, Title = "Basement åbningstider?", User = user1, Text = "Hvornår har basement åben?", Downvote = 0, Upvote = 10, NumberOfVotes = 10, PostTime = DateTime.Now };
                db.Add(post);
                db.SaveChanges();
                //db.Posts.Add(new Post(1, "Basement åbningstider?",user1, "Hvornår har basement åben?", 0, 10, 10, DateTime.Now));


            }

            Comment comment = db.Comments.FirstOrDefault()!;
            if (comment == null)
            {
                comment1 = new Comment { CommentId = 1, Text = "Den har åben Torsdag og fredag fra kl 12", Downvote = 4, Upvote = 5, NumberOfVotes = 9 };
                db.Add(comment);
                db.SaveChanges();

            }

            User user = db.Users.FirstOrDefault()!;
            if (user == null)
            {



                User user2 = new User("Mads");
                User user3 = new User("ML");
                User user4 = new User("Rasmus");
                db.Add(user2);
                db.Add(user3);
                db.Add(user4);
                db.SaveChanges();

            }


        }
*/


