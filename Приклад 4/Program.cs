using System;
using System.IO;
using System.Xml.Serialization;

public class Program
{
    public static void Main()
    {
        var microsoft = new Company("Microsoft");
        var google = new Company("Google");

        Person[] people = new Person[]
        {
         new Person("Tom", 37, microsoft),
         new Person("Bob", 41, google)
        };

        XmlSerializer formatter = new XmlSerializer(typeof(Person[]));

        // Serialize the array of people
        using (FileStream fs = new FileStream("people.xml", FileMode.Create))
        {
            formatter.Serialize(fs, people);
        }

        // Deserialize the array of people
        using (FileStream fs = new FileStream("people.xml", FileMode.Open))
        {
            Person[]? newPeople = formatter.Deserialize(fs) as Person[];

            if (newPeople != null)
            {
                foreach (Person person in newPeople)
                {
                    Console.WriteLine($"Name: {person.Name}");
                    Console.WriteLine($"Age: {person.Age}");
                    Console.WriteLine($"Company: {person.Company.Name}");
                }
            }
        }
    }
}

[Serializable]
public class Company
{
    public string Name { get; set; } = "Undefined";

    // Default constructor
    public Company() { }

    public Company(string name) => Name = name;
}

[Serializable]
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