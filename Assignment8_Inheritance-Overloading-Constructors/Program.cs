using Assignment8_Inheritance_Overloading_Constructors.Models;

Transaction transaction1 = new Transaction(150.75);

Console.WriteLine($"Transaction ID: {transaction1.TransactionId}, Amount: {transaction1.Amount}");

Console.WriteLine("-------------------------------------------------");

List<Post> posts = new List<Post>();

posts.Add(new BlogPost("Understanding Inheritance in C#", "Someone Good"));

posts.Add(new NewsArticle("Local Elections Results", "City News"));

foreach (var post in posts)
{
    post.Display();
}

Console.WriteLine("-------------------------------------------------");

Dog dog = new Dog();

dog.Bark();
dog.Move();
dog.Breathe();

Console.WriteLine("-------------------------------------------------");

object[] assets = new object[3];
assets[0] = new VideoAsset { DurationInSeconds = 300 };
assets[1] = new ImageAsset { Resolution = 720 };
assets[2] = "Not a media file";

foreach (var asset in assets)
{
    if (asset is VideoAsset video)
    {
        Console.WriteLine($"Video Duration: {video.DurationInSeconds} seconds");
    }
    else if (asset is ImageAsset image)
    {
        Console.WriteLine($"Image Resolution: {image.Resolution}");
    }
    else
    {
        Console.WriteLine("Unknown asset type");
    }
}