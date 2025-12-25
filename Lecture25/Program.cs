using Lecture25.Data;
using Lecture25.Models;
using BCrypt;

Baza baza = new Baza();

while (true)
{
    Console.WriteLine("1. Login");
    Console.WriteLine("2. Register");

    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Console.WriteLine("Enter UserName");
            string userLoginName = Console.ReadLine();

            Console.WriteLine("Enter Password");
            string passwordLogin = Console.ReadLine();

            var userExistsLogin = baza.Users.FirstOrDefault(x => x.UserName == userLoginName);

            if (userExistsLogin == null)
            {
                Console.WriteLine("UserName an Password Arasworia");
            }
            else
            {
                var isPasswordCorrect = BCrypt.Net.BCrypt.Verify(passwordLogin, userExistsLogin.Password);

                if (isPasswordCorrect)
                {
                    Console.Clear();
                    Console.WriteLine("Welcome");
                    while (true)
                    {
                        Console.WriteLine("1. Productis Damateba");
                        Console.WriteLine("2. Productebis Naxva");
                        Console.WriteLine("3. Aktiuri Productebis Naxva");
                        Console.WriteLine("4. Maragit Dalageba");

                        string archevani = Console.ReadLine();

                        if (archevani == "1")
                        {
                            Console.WriteLine("Productis Saxeli: ");
                            string name = Console.ReadLine();

                            Console.WriteLine("Raodenoba: ");
                            int quantity = int.Parse(Console.ReadLine());

                            Product prod = new Product()
                            {
                                Title = name,
                                Quantity = quantity,
                                IsActive = true
                            };

                            baza.Products.Add(prod);
                            baza.SaveChanges();

                            Console.WriteLine("Daemata");
                            Console.Clear();
                        }
                        else if (archevani == "2")
                        {
                            Console.Clear();
                            Console.WriteLine("Productebi");

                            var allProducts = baza.Products.ToList();

                            foreach(var p  in allProducts)
                            {
                                Console.WriteLine(p.Title);
                            }

                            Console.ReadKey();
                            Console.Clear();
                        }
                        else if (archevani == "3")
                        {
                            Console.Clear();
                            Console.WriteLine("Productebi");

                            var allProducts = baza.Products.Where(p => p.IsActive).ToList();

                            foreach (var p in allProducts)
                            {
                                Console.WriteLine(p.Title);
                            }

                            Console.ReadKey();
                            Console.Clear();
                        }
                        else if (archevani == "4")
                        {
                            Console.Clear();
                            Console.WriteLine("Productebi");

                            var allProducts = baza.Products.OrderBy(p => p.Quantity).ToList();

                            foreach (var p in allProducts)
                            {
                                Console.WriteLine(p.Title);
                            }

                            Console.ReadKey();
                            Console.Clear();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("UserName an Paroli Arasworia");
                }
            }
            break;

        case "2":
            Console.WriteLine("Enter UserName");
            string userName = Console.ReadLine();

            Console.WriteLine("Enter Password");
            string password = Console.ReadLine();

            var userExists = baza.Users.FirstOrDefault(x => x.UserName == userName);

            if (userExists == null)
            {
                User user = new User()
                {
                    UserName = userName,
                    Password = BCrypt.Net.BCrypt.HashPassword(password)
                };

                baza.Users.Add(user);
                baza.SaveChanges();

                Console.WriteLine("User Daemata");
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Invalid UserName");
            }
                break;
        default:
            Console.WriteLine("invalid option");
            break;
    }
}