using System;
using System.Xml;

namespace Engine.Shared
{

    //building extension method has 3 rules
    //class must be static
    //function must be static
    //first parameter of extension method you prefix with 'this'
    public static class ExtensionMethods
    {
        public static int AttributeAsInt(this XmlNode node, string attributeName)
        {
            return Convert.ToInt32(node.AttributeAsString(attributeName));
        }

        public static string AttributeAsString(this XmlNode node, string attributeName)
        {
            XmlAttribute attribute = node.Attributes?[attributeName];

            if (attribute == null)
            {
                throw new ArgumentException($"The attribute '{attributeName} does not exist");
            }

            return attribute.Value;
        }

    }
}