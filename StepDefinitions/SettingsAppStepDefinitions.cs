using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using SpecFlowProjectwithAppium.Drivers;
using SpecFlowProjectwithAppium.POM;
using System;
using System.Xml.Linq;
using TechTalk.SpecFlow;

namespace SpecFlowProjectwithAppium.StepDefinitions
{
    [Binding]
    public class SettingsAppStepDefinitions
    {
        SettingsHomePage home = new SettingsHomePage(DriverFactory._driver);
        MoresettingsPage mspage = new MoresettingsPage(DriverFactory._driver);
        Checkboxes checkbox = new Checkboxes(DriverFactory._driver);
        

        [Given(@"user scroll and click on ""([^""]*)"" element")]
        public void GivenUserScrollAndClickOnElement(string settings)
        {

            
            home.Element(settings);
           
        }

        [When(@"user scroll and click on ""([^""]*)""")]
        public void WhenUserScrollAndClickOn(string accessibility)
        {
            
            mspage.Moresetting(accessibility);
        }

        [When(@"user click on ""([^""]*)"" element")]
        public void WhenUserClickOnElement(string p0)
        {
            mspage.Moresetting(p0);

        }

        [When(@"user disable the Accessibility shortcut checkbox button")]
        public void WhenUserDisableTheAccessibilityShortcutCheckboxButton()
        {
            
            checkbox.checkboxes();
            
            
        }
        [Given(@"user click on ""([^""]*)"" element")]
        public void GivenUserClickOnElement(string p0)
        {
            home.Element(p0);
        }

        [When(@"user click on ""([^""]*)""")]
        public void WhenUserClickOn(string p0)
        {
           
            home.Element(p0);
        }

        [Then(@"user verify the ""([^""]*)""")]
        public void ThenUserVerifyThe(string value)
        {

            home.verifybothText(value);

            
        }

        [When(@"user click on ""([^""]*)"" button")]
        public void WhenUserClickOnButton(string refresh)
        {
            home.Element(refresh);
        }



    }
}
