using Appium_praticeBDD.Extent_Reports;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin;
using AventStack.ExtentReports.Gherkin.Model;
using BoDi;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using SpecFlowProjectwithAppium.Drivers;
using TechTalk.SpecFlow;

namespace Appium_praticeBDD.Hooks
{
    [Binding]
    public sealed class HooksFeature : ExtentReport1
    {
        private readonly IObjectContainer _container;
        private readonly ScenarioContext _scenarioContext;
        private AppiumDriver<AndroidElement> driver;


        public HooksFeature(IObjectContainer container, ScenarioContext scenarioContext)
        {
            _container = container;
            _scenarioContext = scenarioContext;
           
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            ExtentReport1.InitializeReport(); // Ensures only one instance
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            ExtentReport1.TearDownReport();
            DriverFactory.ServerDispose();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            _feature = _extent.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }


        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario()
        {
            DriverFactory.Launchtheapp();
           

            _scenario = _feature.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (DriverFactory._driver != null)
            {
                DriverFactory._driver.Quit();
            }
        }

        [AfterStep]
        public void AfterStep()
        {
            string stepType = _scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            var stepName = _scenarioContext.StepContext.StepInfo.Text;

         

            if (_scenarioContext.TestError == null)
            {
                _scenario.CreateNode(new GherkinKeyword(stepType), stepName);
            }
            else
            {
                string screenshotPath = AddScreenShot(DriverFactory._driver, _scenarioContext);

                _scenario.CreateNode(new GherkinKeyword(stepType), stepName)
                        .Fail(_scenarioContext.TestError.Message,
                              MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
            }
        }
    }
}
