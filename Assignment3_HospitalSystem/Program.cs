
string[] patients = { "David Mezvrishvili", "Nino Amonashvili", "Mariam Dolidze", "Nikoloz Mjavanadze", "Levan Kevlishvili", "Ana Minashvili", "Giorgi Kalandadze", "Lela Yipshidze", "Aleksandre Zirakashvili", "Elene Durglishvili" };
int[] ages = { 25, 34, 28, 45, 52, 30, 40, 29, 33, 38 };
string[] diagnosis = { "Flu", "Cold", "Allergy", "Diabetes", "Hypertension", "Asthma", "Migraine", "Arthritis", "Flu", "Anxiety" };
bool[] patientRooms = { true, false, true, true, true, false, true, false, true, false, false, true, true, true, true };
string[] doctors = { "Dr. Silagadze", "Dr. Diasamidze", "Dr. Chipashvili", "Dr. Zirakashvili", "Dr. Chubinidze" };
string[] medicaments = { "Paracetamol", "Ibuprofen", "Amoxicillin", "Lisinopril", "Metformin", "Amlodipine", "Omeprazole", "Simvastatin", "Albuterol", "Gabapentin" };
int[] medicamentQuantity = { 50, 30, 20, 40, 60, 25, 35, 45, 55, 15 };
bool[] vipPatients = { true, false, true, false, true, false, false, false, false, false };
double[] bills = { 150.75, 200.50, 300.00, 450.25, 500.00, 600.75, 700.50, 800.00, 900.25, 1000.00 };


Console.ForegroundColor = ConsoleColor.DarkBlue;
Console.WriteLine("Welcome to the Hospital Management System");
Console.ResetColor();
Console.WriteLine("=========================================");

bool exit = false;

while (!exit)
{
    Console.ForegroundColor = ConsoleColor.DarkBlue;
    Console.WriteLine("Select an option:");
    Console.WriteLine();
    Console.ResetColor();

    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("1. Add new patient");
    Console.WriteLine("2. View all patients");
    Console.WriteLine("3. View free patientRooms");
    Console.WriteLine("4. Search patient by name");
    Console.WriteLine("5. View doctors");
    Console.WriteLine("6. Statistics");
    Console.WriteLine("7. Delete patient");
    Console.WriteLine("8. Sum of bills (net income)");
    Console.WriteLine("9. Exit");
    Console.ResetColor();

    Console.WriteLine();
    Console.Write("Enter your choice (1-9): ");

    string choice = Console.ReadLine();
    Console.WriteLine();

    if (string.IsNullOrWhiteSpace(choice))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Invalid input. Please enter a number between 1 and 9.");
        Console.ResetColor();
        continue;
    }
    else
    {
        if (choice == "1")
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("Enter patient full name: ");
            Console.ResetColor();
            string patientsName = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("Enter patient age: ");
            Console.ResetColor();

            if (!int.TryParse(Console.ReadLine(), out int patientAge))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid age format.");
                Console.ResetColor();
                break;
            }

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("Enter patient diagnosis: ");
            Console.ResetColor();
            string patientDiagnosis = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("Is the patient in a room? (yes/no): ");
            Console.ResetColor();
            string inRoomInput = Console.ReadLine();
            bool inRoom = inRoomInput.ToLower() == "yes";

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("Is the patient a VIP? (yes/no): ");
            Console.ResetColor();
            string isVipInput = Console.ReadLine();
            bool isVip = isVipInput.ToLower() == "yes";

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("Enter patient bill amount: ");
            Console.ResetColor();
            if (!double.TryParse(Console.ReadLine(), out double patientBill))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid bill amount format.");
                Console.ResetColor();
                break;
            }

            int newLength = patients.Length + 1;

            Array.Resize(ref patients, newLength);
            Array.Resize(ref ages, newLength);
            Array.Resize(ref diagnosis, newLength);
            Array.Resize(ref vipPatients, newLength);
            Array.Resize(ref bills, newLength);

            patients[newLength - 1] = patientsName;
            ages[newLength - 1] = patientAge;
            diagnosis[newLength - 1] = patientDiagnosis;
            vipPatients[newLength - 1] = isVip;
            bills[newLength - 1] = patientBill;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Patient added successfully!");
            Console.ResetColor();
            Console.WriteLine("=========================================");
            Console.WriteLine();
        }
        else if (choice == "2")
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("All Patients:");
            Console.ResetColor();
            Console.WriteLine("=========================================");

            Console.ForegroundColor = ConsoleColor.Blue;
            for (int i = 0; i < patients.Length; i++)
            {
                Console.WriteLine($"{i + 1}. Name: {patients[i]}, Age: {ages[i]}, Diagnosis: {diagnosis[i]}, VIP: {vipPatients[i]}, Bill: ${bills[i]}");
            }
            Console.ResetColor();
            Console.WriteLine("=========================================");
            Console.WriteLine();
        }
        else if (choice == "3")
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Free Patient Rooms:");
            Console.ResetColor();
            Console.WriteLine("=========================================");

            Console.ForegroundColor = ConsoleColor.Blue;
            for (int i = 0; i < patientRooms.Length; i++)
            {
                if (!patientRooms[i])
                {
                    Console.WriteLine($"Room {i + 1} is free.");
                }
            }
            Console.ResetColor();
            Console.WriteLine("=========================================");
            Console.WriteLine();
        }
        else if (choice == "4")
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("Enter patient name to search: ");
            Console.ResetColor();

            string searchName = Console.ReadLine();
            bool found = false;

            Console.ForegroundColor = ConsoleColor.Blue;

            for (int i = 0; i < patients.Length; i++)
            {
                if (patients[i].IndexOf(searchName, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    Console.WriteLine($"Found: Name: {patients[i]}, Age: {ages[i]}, Diagnosis: {diagnosis[i]}, VIP: {vipPatients[i]}, Bill: ${bills[i]}");
                    found = true;
                }
            }

            if (!found)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Patient not found.");
            }

            Console.ResetColor();
            Console.WriteLine("=========================================");
            Console.WriteLine();
        }
        else if (choice == "5")
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Doctors:");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Blue;
            for (int i = 0; i < doctors.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {doctors[i]}");
            }

            Console.ResetColor();
            Console.WriteLine("=========================================");
            Console.WriteLine();

        }
        else if (choice == "6")
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Statistics:");
            Console.ResetColor();
            Console.WriteLine("=========================================");

            int totalPatients = patients.Length;
            double averageAge = 0;
            double sumAge = 0;
            string mostCommonDiagnosis = "";

            if (totalPatients > 0)
            {
                for (int i = 0; i < ages.Length; i++)
                {
                    sumAge += ages[i];
                }
                averageAge = sumAge / totalPatients;

                for (int i = 0; i < diagnosis.Length; i++)
                {
                    int count = 0;
                    for (int j = 0; j < diagnosis.Length; j++)
                    {
                        if (diagnosis[i] == diagnosis[j])
                        {
                            count++;
                        }
                    }
                    if (count > 1)
                    {
                        mostCommonDiagnosis = diagnosis[i];
                        break;
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Total Patients: {totalPatients}");
            Console.WriteLine($"Average Age: {averageAge:F2}");
            Console.WriteLine($"Most Common Diagnosis: {mostCommonDiagnosis}");
            Console.ResetColor();
            Console.WriteLine("=========================================");
            Console.WriteLine();
        }
        else if (choice == "7")
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("Enter patient full name to delete: ");
            Console.ResetColor();

            string deleteName = Console.ReadLine();

            int indexToDelete = Array.FindIndex(patients, p => p.Equals(deleteName, StringComparison.OrdinalIgnoreCase));

            if (indexToDelete >= 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Found patient: {patients[indexToDelete]}");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Are you sure you want to delete this patient? (yes/no): ");
                Console.ResetColor();

                string confirm = Console.ReadLine();

                if (confirm?.ToLower() == "yes")
                {
                    for (int i = indexToDelete; i < patients.Length - 1; i++)
                    {
                        patients[i] = patients[i + 1];
                        ages[i] = ages[i + 1];
                        diagnosis[i] = diagnosis[i + 1];
                        vipPatients[i] = vipPatients[i + 1];
                        bills[i] = bills[i + 1];
                    }

                    Array.Resize(ref patients, patients.Length - 1);
                    Array.Resize(ref ages, ages.Length - 1);
                    Array.Resize(ref diagnosis, diagnosis.Length - 1);
                    Array.Resize(ref vipPatients, vipPatients.Length - 1);
                    Array.Resize(ref bills, bills.Length - 1);

                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Patient '{deleteName}' deleted successfully!");
                    Console.WriteLine($"Remaining patients: {patients.Length}");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Delete operation cancelled.");
                    Console.ResetColor();
                }

                Console.WriteLine("=========================================");
                Console.WriteLine();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Patient not found.");
                Console.ResetColor();
                Console.WriteLine("=========================================");
                Console.WriteLine();
            }
        }
        else if (choice == "8")
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Net Income (Sum of Bills):");
            Console.ResetColor();
            Console.WriteLine("=========================================");

            double totalBills = 0;
            for (int i = 0; i < bills.Length; i++)
            {
                totalBills += bills[i];
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Total Net Income: ${totalBills:F2}");
            Console.ResetColor();
            Console.WriteLine("=========================================");
            Console.WriteLine();
        }
        else if (choice == "9")
        {
            exit = true;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Exiting the system. Goodbye!");
            Console.ResetColor();
            Console.WriteLine("=========================================");
            Console.WriteLine();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid choice. Please enter a number between 1 and 9.");
            Console.ResetColor();
        }
    }
}