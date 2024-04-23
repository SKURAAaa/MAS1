using System;
using ZooManagement;

namespace MAS1
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "zoo.json"; // Ścieżka do pliku z danymi zoo

            // Inicjalizacja zoo z pliku lub utworzenie nowego obiektu zoo
            Zoo zoo = Zoo.InitializeZooFromFile(filePath);

            // Główna pętla programu
            bool exit = false;
            while (!exit)
            {
                // Wyświetlenie menu
                Console.WriteLine("1. Show all animals");
                Console.WriteLine("2. Add an animal");
                Console.WriteLine("3. Remove an animal");
                Console.WriteLine("4. Show average animal rating");
                Console.WriteLine("5. Save and exit");
                Console.Write("Enter your choice: ");

                // Odczyt wyboru użytkownika
                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                // Obsługa wyboru użytkownika
                switch (choice)
                {
                    case 1:
                        zoo.ShowAllAnimals();
                        break;
                    case 2:
                        AddAnimal(zoo);
                        break;
                    case 3:
                        RemoveAnimal(zoo);
                        break;
                    case 4:
                        var averageRating = zoo.CalculateAverageRating();
                        Console.WriteLine($"Average rating of all rated animals: {averageRating}");
                        break;
                    case 5:
                        zoo.SaveZooToFile(filePath); // Zapisanie danych zoo do pliku
                        exit = true; // Zakończenie programu
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                        break;
                }
            }
        }

        // Metoda do dodawania nowego zwierzęcia do zoo
        static void AddAnimal(Zoo zoo)
        {
            Console.WriteLine("Name: ");
            var name = Console.ReadLine();
            Console.WriteLine("Species: ");
            var species = Console.ReadLine();
            Console.WriteLine("Age: ");
            var age = int.Parse(Console.ReadLine());
            Console.WriteLine("Habitat: ");
            var habitat = Console.ReadLine();
            Console.WriteLine("Rating - optional(non-rating - press space): ");
            int? rating = null;
            int parsedRating;
            if (int.TryParse(Console.ReadLine(), out parsedRating))
            {
                rating = parsedRating;
            }
            Console.WriteLine("Characteristics - enter comma-separated list: ");
            var characteristics = Console.ReadLine().Split(',').ToList();
            Console.WriteLine("Skills - enter comma-separated list: ");
            var skills = Console.ReadLine().Split(',').ToList();
            var newAnimal = new Animal(name, species, age, habitat)
            {
                Rating = rating,
                Characteristics = characteristics,
                Skills = skills
            };
            zoo.AddAnimal(newAnimal);
        }

        // Metoda do usuwania zwierzęcia ze zoo
        static void RemoveAnimal(Zoo zoo)
        {
            Console.WriteLine("1. Remove by index");
            Console.WriteLine("2. Remove by name");
            Console.Write("Enter your choice: ");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                return;
            }

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter the index of the animal to remove: ");
                    if (int.TryParse(Console.ReadLine(), out int index))
                    {
                        zoo.RemoveAnimal(index - 1);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                    }
                    break;
                case 2:
                    Console.WriteLine("Enter the name of the animal to remove: ");
                    string name = Console.ReadLine();
                    zoo.RemoveAnimal(name);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 2.");
                    break;
            }
        }
    }
}
