/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESSOURCES
 */
using System.Xml.Serialization;

namespace Reporters.Junit.Models
{
    [XmlRoot(elementName: "testsuite")]
    public class JunitReportModel
    {
        #region *** Attributes ***
        [XmlAttribute(attributeName: "errors")]
        public int Errors { get; set; }

        [XmlAttribute(attributeName: "failures")]
        public int Failures { get; set; }

        [XmlAttribute(attributeName: "hostname")]
        public string HostName { get; set; }

        [XmlAttribute(attributeName: "name")]
        public string Name { get; set; }

        [XmlAttribute(attributeName: "tests")]
        public int NumberOfTests { get; set; }

        [XmlAttribute(attributeName: "skipped")]
        public int Skipped { get; set; }

        [XmlAttribute(attributeName: "time")]
        public double Time { get; set; }

        [XmlAttribute(attributeName: "timestamp")]
        public string Timestamp { get; set; }
        #endregion

        #region *** Elements   ***
        [XmlArray(elementName: "properties")]
        public PropertyModel[] Properties { get; set; }

        [XmlElement(elementName: "testcase")]
        public TestCaseModel[] TestCases { get; set; }
        #endregion
    }
}
