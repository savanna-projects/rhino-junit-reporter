/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESSOURCES
 */
using System.Xml.Serialization;

namespace Reporters.Junit.Models
{
    [XmlType(typeName: "property")]
    public class PropertyModel
    {
        [XmlAttribute(attributeName: "name")]
        public string Name { get; set; }

        [XmlAttribute(attributeName: "value")]
        public string Value { get; set; }
    }
}
