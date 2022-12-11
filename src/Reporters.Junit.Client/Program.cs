using Gravity.Services.DataContracts;
using Reporters.Junit.Models;

using Rhino.Api.Contracts.Configuration;
using Rhino.Api.Extensions;

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

var configuration = new RhinoConfiguration
{
    Name = "Test Configuration",
    TestsRepository = new[]
    {
        File.ReadAllText("001_google_positive_test.txt"),
        File.ReadAllText("002_google_negative_test.txt")
    },
    DriverParameters = new[]
    {
        new Dictionary<string, object>
        {
            ["driver"] = "MicrosoftWebDriver",
            ["driverBinaries"] = "E:\\AutomationEnvironment\\WebDrivers"
        }
    },
    Authentication = new Authentication
    {
        Username = "",
        Password = ""
    },
    ConnectorConfiguration = new RhinoConnectorConfiguration
    {
        Connector = RhinoConnectors.Text
    },
    EngineConfiguration = new RhinoEngineConfiguration
    {
        MaxParallel = 5,
        RetrunExceptions = true,
        ReturnPerformancePoints = true,
        ReturnEnvironment = true
    },
    ScreenshotsConfiguration = new RhinoScreenshotsConfiguration
    {
        ReturnScreenshots = true,
        ScreenshotsOut = Path.Combine(Environment.CurrentDirectory, "Reports", "Images"),
        KeepOriginal = true
    },
    ReportConfiguration = new RhinoReportConfiguration
    {
        ReportOut = Path.Combine(Environment.CurrentDirectory, "Reports", "rhino"),
        Reporters = new[] { "JunitRepoter" },
        LogsOut = Path.Combine(Environment.CurrentDirectory, "Reports", "Logs"),
        AddGravityData = true
    }
};
configuration.Invoke(Utilities.Types);
