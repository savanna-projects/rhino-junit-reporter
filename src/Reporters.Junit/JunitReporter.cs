/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESSOURCES
 */
using Gravity.Abstraction.Logging;

using Reporters.Junit.Extensions;

using Rhino.Api.Contracts.Attributes;
using Rhino.Api.Contracts.AutomationProvider;
using Rhino.Api.Contracts.Configuration;
using Rhino.Api.Reporter;

using System;
using System.IO;

namespace Reporters.Junit
{
    [Reporter("JunitRepoter", Description = "Rhino plugin for creating a flat, single file XML report using the JUnit Jupiter standard.")]
    public class JunitReporter : RhinoReporter
    {
        public JunitReporter(RhinoConfiguration configuration)
            : base(configuration)
        { }

        public JunitReporter(RhinoConfiguration configuration, ILogger logger)
            : base(configuration, logger)
        { }

        protected override void OnCreate(RhinoTestRun testRun)
        {
            // setup
            var outputFolder = string.IsNullOrEmpty(Configuration?.ReportConfiguration?.ReportOut)
                ? Environment.CurrentDirectory
                : Configuration.ReportConfiguration.ReportOut;
            var path = Path.Combine(outputFolder, $"{testRun.Key}.xml");
            var xml = testRun.ConvertToJunitXml();

            // create
            Directory.CreateDirectory(path);
            File.WriteAllText(path, xml);
        }
    }
}
