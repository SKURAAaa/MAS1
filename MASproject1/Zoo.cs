using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace ZooManagement
{
    public class Zoo
    {
        // Ekstensja
        public List<Animal> ZooPopulation { get; set; } = new List<Animal>(); // populacja zwierząt w zoo

        public Zoo()
        {
        }

        public void AddAnimal(Animal animal)
        {
            ZooPopulation.Add(animal);
        }

        public void RemoveAnimal(int index)
        {
            if (index >= 0 && index < ZooPopulation.Count)
            {
                ZooPopulation.RemoveAt(index);
            }
            else
            {
                Console.WriteLine("Invalid index.");
            }
        }

        public void RemoveAnimal(string name)
        {
            var animalToRemove = ZooPopulation.Find(animal => animal.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (animalToRemove != null)
            {
                ZooPopulation.Remove(animalToRemove);
            }
            else
            {
                Console.WriteLine($"Animal with name {name} not found.");
            }
        }

        public void ShowAllAnimals()
        {
            int i = 1;
            foreach (var animal in ZooPopulation)
            {
                Console.WriteLine($"{i}. {animal}");
                Console.WriteLine("");
                i++;
            }
        }

        public double CalculateAverageRating()
        {
            var ratedAnimals = ZooPopulation.FindAll(animal => animal.Rating.HasValue);
            if (ratedAnimals.Count > 0)
            {
                double totalRating = 0;
                foreach (var animal in ratedAnimals)
                {
                    totalRating += animal.Rating.Value;
                }
                return totalRating / ratedAnimals.Count;
            }
            else
            {
                Console.WriteLine("No rated animals found.");
                return 0;
            }
        }

        public void SaveZooToFile(string filePath)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            var json = JsonSerializer.Serialize(ZooPopulation, options);
            File.WriteAllText(filePath, json);
            Console.WriteLine($"Zoo saved to file: {filePath}");
        }

        public static Zoo InitializeZooFromFile(string filePath)
        {
            List<Animal> zooPopulation;
            try
            {
                var json = File.ReadAllText(filePath);
                zooPopulation = JsonSerializer.Deserialize<List<Animal>>(json);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"File '{filePath}' not found. Initializing empty zoo.");
                zooPopulation = new List<Animal>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file '{filePath}': {ex.Message}");
                zooPopulation = new List<Animal>();
            }
            return new Zoo { ZooPopulation = zooPopulation };
        }
    }
}
