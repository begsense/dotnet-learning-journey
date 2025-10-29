namespace Lecture15.Models
{
    internal class Student: Person
    {
        private int _roomNumber;

        public int RoomNumber
        {
            get { return _roomNumber; }
            set { _roomNumber = value; }
        }

        public Student(int roomNumber, string fullName, int age)
        {
            RoomNumber = roomNumber;
            Name = fullName;
            Age = age;
            Console.WriteLine($"Student object created. and RoomNumber is {RoomNumber}");
        }
    }
}
