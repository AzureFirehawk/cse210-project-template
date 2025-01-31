using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the YouTubeVideos Project.");

        // Initialize videos
        Video video1 = new Video("Acadence - Prosthesis", "Acadence", "03:39");
        Video video2 = new Video("Bloodywood - Tadka (Official Music Video) ", "Bloodywood", "04:19");
        Video video3 = new Video("We Became Fast Food Workers [SMii7Y VOD]", "SMii7Yminus", "02:49:20");
        Video video4 = new Video("Music for Work", "Chill Music Lab", "01:08:32");

        // Create comments for each video
        video1.AddComment("User1", "Can't wait to put this one onto my playlists, beautiful work");
        video1.AddComment("User2", "Always on top, I love it ❤");
        video1.AddComment("User3", "just keeps getting better and better");
        video1.AddComment("User4", "Love the drop. Another purchase for me my man.");

        video2.AddComment("User1", "My neighbours are getting ready to LOVE this");
        video2.AddComment("User2", "This is the best food song in the history of food songs.");
        video2.AddComment("User3", "Every middle aged Indian Aunty is the final boss in the cooking games.");

        video3.AddComment("User1", "0:05 My nightmares at Midnight");
        video3.AddComment("User2", "I did not expect the McDonalds Ambience to be the very first thing in this VOD.");
        video3.AddComment("User3", "Put the fries in the bag smii7y");

        video4.AddComment("User1", "Never heard this music before, it randomly popped up in a search, but NOICE! My new favorite chill music.");
        video4.AddComment("User2", "Loving this future garage music; it's like I'm finally honing in on the genres I most like :)");
        video4.AddComment("User3", "This is hands down the best cyber mix i've ever listened to");
        video4.AddComment("User4", "Amazing compositions!!! I wish you creative success!!!");

        // Add videos to list
        List<Video> videos = new List<Video>{ video1, video2, video3, video4 };

        // Display videos
        foreach (Video video in videos)
        {
            video.DisplayVideoInfo();
        }
    }
}