/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESSOURCES
 */
using System.Xml.Serialization;

namespace Reporters.Junit.Models
{
    [XmlType(typeName: "testcase")]
    public class TestCaseModel
    {
        #region *** Attributes ***
        [XmlAttribute(attributeName: "classname")]
        public string ClassName { get; set; }

        [XmlAttribute(attributeName: "name")]
        public string Name { get; set; }

        [XmlAttribute(attributeName: "time")]
        public double Time { get; set; }
        #endregion

        #region *** Elements   ***
        [XmlElement(elementName: "system-out")]
        public Cdata SystemOut { get; set; }

        [XmlElement(elementName: "failure")]
        public Cdata Failure { get; set; }

        [XmlElement(elementName: "error")]
        public Cdata Error { get; set; }
        #endregion
    }
}
