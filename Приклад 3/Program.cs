using System;
using System.IO;
using System.Xml.Serialization;

public class Program
{
    public static void Main()
    {
        Person[] people = new Person[]
        {
         new Person("Tom", 37),
         new Person("Bob", 41)
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
                    Console.WriteLine($"Name: {person.Name} --- Age: {person.Age}");
                }
            }
        }
    }
}

[Serializable]
public class Person
{
    public string Name { get; set; } = "Undefined";
    public int Age { get; set; } = 1;

    public Person() { }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
}