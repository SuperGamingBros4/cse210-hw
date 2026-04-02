using System;

class Program
{
    static void Main(string[] args)
    {
        // Create video 1
        Video video1 = new Video("Trash Or Treasure? New $450 Value Laptop", "Bob's PC Shop", 1098.7);
        video1._comments.Add(new Comment("PCEnjoyer", "This looks like great value!"));
        video1._comments.Add(new Comment("Greg's Hamshack", "I have been looking for a replacement for my 15-some year-old laptop. This looks like a great option!"));
        video1._comments.Add(new Comment("John Doe", "I can't wait to pick this up in few days."));

        // Create video 2
        Video video2 = new Video("Old Personal Computing Legends", "Travis Tips", 1488.54);
        video2._comments.Add(new Comment("George Thompson", "I have many memories in my childhood of getting home from school and getting lost playing the amazing games on the Forsben AP24. I get so nostalgic just thinking about it, I am grateful for the spotlight you have given it."));
        video2._comments.Add(new Comment("Bob", "5:16 looks like the computer my family had for 5 years growing up. Wish I could get one now..."));
        video2._comments.Add(new Comment("Tresher43", "it would have been awesome growing up with one of these."));
        video2._comments.Add(new Comment("YaManTom", "If I could go back and replay any time in my life, I would hands down go back to the AP24!"));

        // Create video 3
        Video video3 = new Video("The Best Laptop (Series)", "Travis Tips", 1815.6);
        video3._comments.Add(new Comment("Thomas", "I have been using these laptops for 15 years now and they have never disappointed me."));
        video3._comments.Add(new Comment("Jeff", "These laptops have always been my go to. They are amazing."));
        video3._comments.Add(new Comment("Greg", "These sound amazing! I am going to pick one up when I find one."));

        // Create a list of the videos
        List<Video> videos = new List<Video>();
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        foreach (Video video in videos)
        {
            // Display the video's title, author, length and number of comments
            Console.WriteLine($"Title: {video._title}, author: {video._author}, length: {video._seconds} seconds, {video.GetCommentsCount()} comments");

            // Display the comments on the video
            foreach (Comment comment in video._comments)
            {
                Console.WriteLine($"  {comment._author}: {comment._text}");
            }
        }
    }
}