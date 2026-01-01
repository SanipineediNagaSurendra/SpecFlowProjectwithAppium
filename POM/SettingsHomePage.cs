using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using SpecFlowProjectwithAppium.Utility_class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProjectwithAppium.POM
{
    public class SettingsHomePage
    {
        private readonly ControlHelpers controlHelpers;
        private AppiumDriver<AndroidElement> _driver;
        public SettingsHomePage(AppiumDriver<AndroidElement> driver)
        {
            this._driver = driver;
            controlHelpers = new ControlHelpers(_driver);
        }

        private By HomeElement => By.XPath("//android.widget.TextView[text(), '" + HomeElement + "']");
        public void Element(string value)
        {
            controlHelpers.scrollandclick(value);
        }

       public void verifybothText(string element)
       {
            IWebElement ele1 = controlHelpers.GetElement(HomeElement);

            controlHelpers.verifyElement(ele1);

            if()
            {
                Assert.IsTrue(ele1.Displayed, $"{element} could not be found");
            }
            else
            {
                Assert.IsFalse(ele1.Displayed, $"{element} could be found");
            }
       }

    }
}
