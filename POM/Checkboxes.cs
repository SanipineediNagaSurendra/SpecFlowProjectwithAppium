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
    public class Checkboxes
    {
        private AppiumDriver<AndroidElement> driver;
        private readonly ControlHelpers controlHelpers;
        public Checkboxes(AppiumDriver<AndroidElement>driver) 
        {
            this.driver = driver;
            controlHelpers = new ControlHelpers(driver);
        }

        private By checkbox => By.XPath("(//android.view.View[@resource-id='android:id/checkbox'])[1]");
        public void checkboxes()
        {
           controlHelpers.clickElement(checkbox);
        }

    }
}
