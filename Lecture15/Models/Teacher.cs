namespace Lecture15.Models;

internal class Teacher : Person
{
    private string _subject;
    private int _yearsOfExperience;
    public string Subject
    {
        get { return _subject; }
        set { _subject = value; }
    }
    public int YearsOfExperience
    {
        get { return _yearsOfExperience; }
        set { _yearsOfExperience = value; }
    }
    public void DisplayInfo()
    {
        Console.WriteLine($"Subject: {_subject}, Years of Experience: {_yearsOfExperience}");
    }
}
