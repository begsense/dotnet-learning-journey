namespace Assignment8_Inheritance_Overloading_Constructors.Models
{
    internal class Formatter
    {
        public string FormatData(string text)
        {
            return $"\"{text}\"";
        }

        public string FormatData(double number)
        {
            return number.ToString("F2") + " GEL";
        }

        public string FormatData(int[] numbers)
        {
            return String.Join(", ", numbers);
        }
    }
}
