using System;
using System.IO;
using System.Xml.Serialization;

public class Program
{
    public static void Main()
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));

        using (FileStream fs = new FileStream("person.xml", FileMode.Open))
        {
            Person? person = xmlSerializer.Deserialize(fs) as Person;
            Console.WriteLine($"Name: {person?.Name} Age: {person?.Age}");
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