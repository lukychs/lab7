using System;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using ClassLibrary1;

class Program
{
    static void Main()
    {
        Assembly assembly = Assembly.Load("ClassLibrary1");
        XElement root = new XElement("Classes");

        foreach (Type type in assembly.GetTypes())
        {
            if (!type.IsClass || type.IsSubclassOf(typeof(Attribute)))
                continue;

            XElement classElement = new XElement("Class");
            classElement.Add(new XAttribute("Name", type.Name));

            var commentAttribute = type.GetCustomAttributes(typeof(CommentAttribute), false)
                                       .FirstOrDefault() as CommentAttribute;
            if (commentAttribute != null)
            {
                classElement.Add(new XElement("Comment", commentAttribute.Comment));
            }

            XElement propertiesElement = new XElement("Properties");
            foreach (var prop in type.GetProperties())
            {
                propertiesElement.Add(new XElement("Property", prop.Name));
            }
            classElement.Add(propertiesElement);

            XElement methodsElement = new XElement("Methods");
            foreach (var method in type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly))
            {
                methodsElement.Add(new XElement("Method", method.Name));
            }
            classElement.Add(methodsElement);

            root.Add(classElement);
        }


        XDocument document = new XDocument(root);
        document.Save("ClassDiagram.xml");

        Console.WriteLine("XML-документ сгенерирован: ClassDiagram.xml");
    }
}