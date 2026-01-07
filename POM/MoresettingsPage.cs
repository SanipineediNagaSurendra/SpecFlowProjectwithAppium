using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using SpecFlowProjectwithAppium.Utility_class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProjectwithAppium.POM
{
    public class MoresettingsPage
    {
        private AppiumDriver<AndroidElement> driver;
        private ControlHelpers controlHelpers;
        public MoresettingsPage(AppiumDriver<AndroidElement>driver) 
        {
            this.driver = driver;
            controlHelpers = new ControlHelpers(driver);
        }

        private By Moresettings => By.XPath("//android.widget.TextView[text(), '" + Moresettings + "']");

        public void Moresetting(string value)
        {
            controlHelpers.scrollandclick(value);
        }
    }
}
