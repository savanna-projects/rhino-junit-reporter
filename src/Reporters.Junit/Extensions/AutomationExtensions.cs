/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESSOURCES
 */
using Reporters.Junit.Models;

using Rhino.Api.Contracts.AutomationProvider;

using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Reporters.Junit.Extensions
{
    public static class AutomationExtensions
    {
        public static string ConvertToJunitXml(this RhinoTestRun testRun)
        {
            // collect test cases
            var testCases = testRun.TestCases.Select(i => new TestCaseModel
            {
                ClassName = ConvertForXml(string.Join(".", i.Categories)),
                Name = ConvertForXml(i.Scenario),
                SystemOut = ConvertForXml(i.ToString()),
                Time = i.RunTime.TotalSeconds
            }).ToArray();

            // collect properties
            var models = testRun.TestCases.SelectMany(i => i.ModelEntries).Select(i => new PropertyModel
            {
                Name = ConvertForXml(i.Name),
                Value = ConvertForXml(i.Value)
            });

            // build
            var junitReport = new JunitReportModel
            {
                Errors = testRun.TestCases.SelectMany(i => i.Steps).Where(i => i.Exceptions != null).SelectMany(i => i.Exceptions).Count(),
                Failures = testRun.TotalFail,
                HostName = ConvertForXml(Environment.MachineName),
                Name = ConvertForXml($"{testRun.Key}: {testRun.ConfigurationName}"),
                NumberOfTests = testRun.TotalTests,
                Properties = models.ToArray(),
                Skipped = testRun.TotalInconclusive,
                TestCases = testCases,
                Time = testRun.RunTime.TotalSeconds,
                Timestamp = testRun.Start.ToString("yyyy-MM-ddThh:mm:ss"),
            };

            // setup
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            // serialize
            var xmlSerialzer = new XmlSerializer(typeof(JunitReportModel));
            using var stream = new MemoryStream();
            xmlSerialzer.Serialize(stream, junitReport, namespaces);

            // get
            return Encoding.ASCII.GetString(stream.ToArray());
        }

        // Utilities
        private static string ConvertForXml(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }
            return input
                .Replace("&", "&amp;")
                .Replace("\"", "&quot;")
                .Replace("<", "&lt;")
                .Replace(">", "&gt;");
        }
    }
}
