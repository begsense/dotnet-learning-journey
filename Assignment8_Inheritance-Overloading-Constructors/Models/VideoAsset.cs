namespace Assignment8_Inheritance_Overloading_Constructors.Models;

internal class VideoAsset : MediaAsset
{
    private int _durationInSeconds;
    public int DurationInSeconds
    {
        get { return _durationInSeconds; }
        set { _durationInSeconds = value; }
    }
}
