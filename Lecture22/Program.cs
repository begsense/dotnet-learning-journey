using Lecture22.Enums;
using Lecture22.Models;

User user = new User();

user.FullName = "John Doe";
user.Age = 30;
user.Role = USER_ROLES.Guest;

Console.WriteLine(user.Role);