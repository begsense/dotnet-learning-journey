namespace Assignment8_Inheritance_Overloading_Constructors.Models;

internal class ArrayProcessor
{
    public int Process(int[] array)
    {
        int sum = 0;

        foreach (var item in array)
        {
            sum += item;
        }

        return sum;
    }

    public string Process(string[] array)
    {
        string longest = string.Empty;

        foreach (var item in array)
        {
            if (item.Length > longest.Length)
            {
                longest = item;
            }
        }

        return longest;
    }
}
