using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;
using SpecFlowProjectwithAppium.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProjectwithAppium.Utility_class
{
    public class ControlHelpers
    {
        private AppiumDriver<AndroidElement> driver;
        public ControlHelpers(AppiumDriver<AndroidElement>driver)
        {
            this.driver = driver;   
        }

        public void scrollandclick(string text)
        {
           var s1 = DriverFactory._driver.FindElement(MobileBy.AndroidUIAutomator($"new UiScrollable(new UiSelector().scrollable(true).instance(0)).scrollIntoView(new UiSelector().text(\"{text}\"))"));
            s1.Click();
        }

        public IWebElement GetElement(By locator)
        {
            return DriverFactory._driver.FindElement(locator);
        }
        public void clickElement(By locator)
        {
            GetElement(locator).Click();
        }
        
        public void verifyElement(IWebElement element)
        {
           bool value = element.Displayed;
        }
    }
}
