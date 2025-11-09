namespace Assignment8_Inheritance_Overloading_Constructors.Models;

internal class ImageAsset : MediaAsset
{
    private int _resolution;

    public int Resolution
    {
        get { return _resolution; }
        set { _resolution = value; }
    }
}
