using System.Text.Json;
using System.Xml;

namespace BinariesAndStrings;

public class XMLandJSON
{
    public record Person(string Name, int Age);
    public record PeopleCollection(Person[] People);

    public static void RunXmlAndJson()
    {
        string rawXml = """
            <people>
                <person>
                    <name>John Doe</name>
                    <age>42</age>
                </person>
                <person>
                    <name>Jane Doe</name>
                    <age>39</age>
                </person>
            </people>
            """;

        File.WriteAllText("people.xml", rawXml);

        // XmlDocument class to read and write XML files
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.Load("people.xml");


        XmlNodeList? people = xmlDocument.SelectNodes("/people/person");

        if (people == null)
        {
            Console.WriteLine("No people found");
        }
        else
        {
            foreach (XmlNode person in people)
            {
                Console.WriteLine(person["name"].InnerText);
                Console.WriteLine(person["age"].InnerText);

                //person.InnerText = person.InnerText.ToUpper();    Doesn't display properly - combines name and age
                person["name"].InnerText = person["name"].InnerText.ToUpper();
                person["age"].InnerText = person["age"].InnerText.ToUpper();
            }
        }


        xmlDocument.Save("people2.xml");

        Console.WriteLine("Contents of People2:");
        Console.WriteLine(File.ReadAllText("people2.xml"));


        // JSON
        PeopleCollection peopleCollection = new PeopleCollection(new[]
        {
            new Person("John Doe", 42),
            new Person("Jane Doe", 39)
        });

        Console.WriteLine("Serializing people to JSON");
        var rawJson = JsonSerializer.Serialize(peopleCollection);
        Console.WriteLine(rawJson);

        File.WriteAllText("people.json", rawJson);

        Console.WriteLine("Deserializing people from JSON using Stream");

        using var peopleJsonStream = File.OpenRead("people.json");
        var deserializedPeopleFromStream = JsonSerializer.Deserialize<PeopleCollection>(peopleJsonStream)!;

        foreach (var person in deserializedPeopleFromStream.People)
        {
            Console.WriteLine($"{ person.Name }: { person.Age }");
        }

        Console.WriteLine("Deserializing people from JSON using String");

        var deserializedPeopleFromString = JsonSerializer.Deserialize<PeopleCollection>(File.ReadAllText("people.json"))!;

        foreach (var person in deserializedPeopleFromString.People)
        {
            Console.WriteLine($"{ person.Name }: { person.Age }");
        }
    }
}
