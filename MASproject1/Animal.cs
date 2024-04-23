using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace ZooManagement
{
    public class Animal
    {
        // Ekstensja
        public static List<Animal> ZooPopulation { get; set; } = new List<Animal>(); // populacja zwierząt w zoo

        public static int NumberOfAnimals { get; set; } = 0; // liczba zwierząt w zoo

        // Atr. złożony
        public List<string> Characteristics { get; set; } = new List<string>(); // cechy zwierzęcia

        // Atr. opcjonalny
        public int? Rating { get; set; } // ocena zwierzęcia

        // Atr. powtarzalny
        public List<string> Skills { get; set; } = new List<string>(); // lista umiejętności zwierzęcia

        public string Name { get; set; } // nazwa zwierzęcia
        public string Species { get; set; } // gatunek zwierzęcia
        public int Age { get; set; } // wiek zwierzęcia
        public string Habitat { get; set; } // środowisko naturalne

        public Animal(string name, string species, int age, string habitat)
        {
            Name = name;
            Species = species;
            Age = age;
            Habitat = habitat;

            AddAnimal(this);
        }

        public static void AddAnimal(Animal animal)
        {
            ZooPopulation.Add(animal);
            NumberOfAnimals++;
        }


        // Przesłonięcie metody ToString() dla wygodnego wyświetlania obiektów
        public string ToString(bool verbose)
        {
            if (verbose)
            {
                return
                    $"Name: {Name}\nSpecies: {Species}\nAge: {Age}\nHabitat: {Habitat}\nRating: {(Rating.HasValue ? Rating.ToString() : "Not rated")}\nCharacteristics: {string.Join(", ", Characteristics)}\nSkills: {string.Join(", ", Skills)}";
            }
            else
            {
                return $"Name: {Name}\nSpecies: {Species}\n";
            }
        }

        // Przeciążenie metody ToString() dla wygodnego wyświetlania obiektów
        public override string ToString()
        {
            return ToString(false);
        }
    }
}