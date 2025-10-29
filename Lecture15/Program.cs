using Lecture15.Models;

Student student = new Student(35, "Alica", 22);

Teacher teacher = new Teacher();

teacher.Name = "Mr. Smith";
teacher.Age = 40;
teacher.Subject = "Mathematics";
teacher.YearsOfExperience = 15;


student.DisplayInfo();
teacher.DisplayInfo();