namespace Assignment8_Inheritance_Overloading_Constructors.Models;

internal class GameSettings
{
    private string _difficulty;
    private int _soundVolume;

    public string Difficulty
    {
        get { return _difficulty; }
        set { _difficulty = value; }
    }

    private int SoundVolume
    {
        get { return _soundVolume; }
        set { _soundVolume = value; }
    }

    public GameSettings()
    {
        Difficulty = "Normal";
        SoundVolume = 80;
    }

    public GameSettings(string difficulty) : this()
    {
        Difficulty = difficulty;
    }

    public GameSettings(int soundVolume) : this()
    {
        SoundVolume = soundVolume;
    }
}
