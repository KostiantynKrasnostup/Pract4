using System;
using System.IO;
using System.Text.Json;

public class Program
{
    public static void Main()
    {
        // Створення нового об'єкта
        Person person = new Person("Tom", 37, new Company("Microsoft"));

        // Серіалізація об'єкта в JSON файл
        string filePath = "person.json";
        SerializeToJson(filePath, person);

        // Десеріалізація об'єкта з JSON файлу
        Person? deserializedPerson = DeserializeFromJson(filePath);

        // Виведення результатів на консоль
        if (deserializedPerson != null)
        {
            Console.WriteLine($"Name: {deserializedPerson.Name}");
            Console.WriteLine($"Age: {deserializedPerson.Age}");
            Console.WriteLine($"Company: {deserializedPerson.Company.Name}");
        }
    }

    // Метод для серіалізації об'єкта в JSON
    public static void SerializeToJson(string filePath, Person person)
    {
        string jsonString = JsonSerializer.Serialize(person);
        File.WriteAllText(filePath, jsonString);
        Console.WriteLine("Object has been serialized to JSON.");
    }

    // Метод для десеріалізації об'єкта з JSON
    public static Person? DeserializeFromJson(string filePath)
    {
        string jsonString = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<Person>(jsonString);
    }
}

public class Company
{
    public string Name { get; set; } = "Undefined";

    public Company() { }

    public Company(string name)
    {
        Name = name;
    }
}

public class Person
{
    public string Name { get; set; } = "Undefined";
    public int Age { get; set; } = 1;
    public Company Company { get; set; } = new Company();

    public Person() { }

    public Person(string name, int age, Company company)
    {
        Name = name;
        Age = age;
        Company = company;
    }
}