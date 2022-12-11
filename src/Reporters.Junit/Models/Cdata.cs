/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESSOURCES
 */
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Reporters.Junit.Models
{
    public class Cdata : IXmlSerializable
    {
        private string _value;

        public Cdata()
            : this(string.Empty)
        { }

        public Cdata(string value)
        {
            _value = value;
        }

        /// <summary>
        /// Allow direct assignment from string: CData data = "Foo Bar";
        /// </summary>
        /// <param name="value">The string being cast to CData.</param>
        /// <returns>A CData object</returns>
        public static implicit operator Cdata(string value) => new(value);

        /// <summary>
        /// Allow direct assignment to string: string data = cdata;
        /// </summary>
        /// <param name="cdata">The CData being cast to a string</param>
        /// <returns>A string representation of the CData object</returns>
        public static implicit operator string(Cdata cdata) => cdata._value;

        public override string ToString() => _value;

        public XmlSchema GetSchema() => null;

        public void ReadXml(XmlReader reader) => _value = reader.ReadElementString();

        public void WriteXml(XmlWriter writer) => writer.WriteCData(_value);
    }
}
