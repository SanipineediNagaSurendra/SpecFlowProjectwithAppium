using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Config;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.IO;
using TechTalk.SpecFlow;

namespace Appium_praticeBDD.Extent_Reports
{
    public class ExtentReport1
    {
        public static ExtentReports _extent;
        public static ExtentTest _feature;
        public static ExtentTest _scenario;

        // Get the Project Directory dynamically
        private static string projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

        // Define the ExtentReport folder path inside the project
        private static string reportDirectory = Path.Combine(projectPath, "AutomationReport");
        private static string timestamp;
        private static string uniqueTestResultPath;

        public static void InitializeReport()
        {
            if (_extent == null) // Ensure report is initialized only once
            {
                timestamp = DateTime.Now.ToString("yyyy_MM_dd_HH-mm-ss");
                uniqueTestResultPath = Path.Combine(reportDirectory, timestamp);

                // Ensure the folder exists
                if (!Directory.Exists(uniqueTestResultPath))
                {
                    Directory.CreateDirectory(uniqueTestResultPath);
                }

                var htmlReporter = new ExtentSparkReporter(Path.Combine(uniqueTestResultPath, $"{timestamp}_TestReport.html"));
                htmlReporter.Config.DocumentTitle = "Automation Test Report";
                htmlReporter.Config.Theme = Theme.Dark;

                _extent = new ExtentReports();
                _extent.AttachReporter(htmlReporter);
            }
        }

        public static void TearDownReport()
        {
            if (_extent != null)
            {
                _extent.Flush();

            }
        }

        public static string AddScreenShot(AppiumDriver<AndroidElement> driver, ScenarioContext scenarioContext)
        {
            ITakesScreenshot screenshotDriver = (ITakesScreenshot)driver;
            Screenshot screenshot = screenshotDriver.GetScreenshot();

            // Ensure screenshot directory exists
            if (!Directory.Exists(uniqueTestResultPath))
            {
                Directory.CreateDirectory(uniqueTestResultPath);
            }

            string screenshotPath = Path.Combine(uniqueTestResultPath, $"{scenarioContext.ScenarioInfo.Title}.png");
            screenshot.SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);
            return screenshotPath;
        }
    }
}
