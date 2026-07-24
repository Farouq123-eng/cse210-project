using System;
using System.Collections.Generic;

class Comment
{
    public string CommenterName { get; set; }
    public string Text { get; set; }

    public Comment(string commenterName, string text)
    {
        CommenterName = commenterName;
        Text = text;
    }

    public override string ToString()
    {
        return $"Commenter: {CommenterName}, comment: {Text}";
    }
}

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; }
    public List<Comment> comments = new List<Comment>();

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
    }

    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return comments.Count;
    }

    public void DisplayVideoInfo()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {Length} seconds");
        Console.WriteLine($"Number of comments: {GetNumberOfComments()}");
        Console.WriteLine("Comments:");
        foreach (var comment in comments)
        {
            Console.WriteLine($"  - {comment}");
        }
        Console.WriteLine(new string('-', 40));
    }
}

class Program
{
    static void Main(string[] args)
    {
        // create videos
        Video video1 = new Video("C# Tutorial", "John Doe", 600);
        Video video2 = new Video("Python Tutorial", "Jane Smith", 480);
        Video video3 = new Video("Java Tutorial", "Mike Johnson", 720);
        Video video4 = new Video("JavaScript Tutorial", "Emily Davies", 540);

        // Add comments
        video1.AddComment(new Comment("Alice", "Great tutorial!"));
        video1.AddComment(new Comment("Bob", "Very helpful, thanks!"));
        video1.AddComment(new Comment("Charlie", "I learned a lot from this video."));
        video1.AddComment(new Comment("David", "Can you make a follow-up video?"));

        video2.AddComment(new Comment("Eve", "This was a bit confusing."));
        video2.AddComment(new Comment("Frank", "I appreciate the effort, but I need more examples."));
        video2.AddComment(new Comment("Grace", "I think the pacing was too fast."));
        video2.AddComment(new Comment("Heidi", "I would have liked more visuals."));

        video3.AddComment(new Comment("Ivan", "This was a great introduction to Java."));
        video3.AddComment(new Comment("Judy", "I wish there were more exercises."));
        video3.AddComment(new Comment("Kevin", "I found the explanations clear and concise."));
        video3.AddComment(new Comment("Laura", "I would have liked more real-world examples."));

        video4.AddComment(new Comment("Mallory", "I think the examples were too basic."));
        video4.AddComment(new Comment("Niaj", "I would have liked more advanced topics."));
        video4.AddComment(new Comment("Olivia", "I think the pacing was too slow."));
        video4.AddComment(new Comment("Peggy", "I would have liked more interactive elements."));

        // store videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3, video4 };

        // display video info
        foreach (var video in videos)
        {
            video.DisplayVideoInfo();
        }
    }
}
