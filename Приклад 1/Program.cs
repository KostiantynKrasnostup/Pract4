using System;
using System.IO;
using System.Xml.Serialization;

public class Program
{
    public static void Main()
    {
        Person person = new Person("Tom", 37);
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));

        using (FileStream fs = new FileStream("person.xml", FileMode.OpenOrCreate))
        {
            xmlSerializer.Serialize(fs, person);
            Console.WriteLine("Object has been serialized");
        }
    }
}

[Serializable]
public class Person
{
    public string Name { get; set; } = "Undefined";

    // Change the type of Age to int for correct serialization
    public int Age { get; set; } = 1;

    // Default constructor is needed for XML serialization
    public Person() { }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
}