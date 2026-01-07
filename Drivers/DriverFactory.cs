using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProjectwithAppium.Drivers
{
    public class DriverFactory
    {
        public static AppiumDriver<AndroidElement> _driver { get; set; }
        private static AppiumLocalService _service;
        public static void Launchtheapp()
        {
            startAppiumServer();

            if (_service == null || !_service.IsRunning)
            {
                throw new Exception("server is not started");
            }
            var options = new AppiumOptions();
            options.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
            options.AddAdditionalCapability(MobileCapabilityType.AutomationName, "UiAutomator2");
            options.AddAdditionalCapability(MobileCapabilityType.DeviceName, "vivo 1820");
            options.AddAdditionalCapability("appPackage", "com.android.settings");
            options.AddAdditionalCapability("appActivity", "com.android.settings.Settings");

            options.AddAdditionalCapability("ignoreHiddenApiPolicyError", "true");
            options.AddAdditionalCapability("appWaitDuration", 6000);

            AppiumDriver<AndroidElement> d1 = new AndroidDriver<AndroidElement>(new Uri("http://127.0.0.1:4723/wd/hub/"), options);
            _driver = d1;
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }
        private static void startAppiumServer()
        {
            if (_service == null || !_service.IsRunning)
            {
                _service = new AppiumServiceBuilder()
                  .WithIPAddress("127.0.0.1")
                  .UsingPort(4723)
                  .UsingDriverExecutable(new FileInfo(@"C:\Program Files\nodejs\node.exe"))
                  .WithAppiumJS(new FileInfo(@"C:\Users\nagas\AppData\Roaming\npm\node_modules\appium\build\lib\main.js"))
                  .WithStartUpTimeOut(TimeSpan.FromSeconds(3))
                  .Build();

                _service.Start();
            }


        }
        public static void ServerDispose()
        {
            if (_service != null && _service.IsRunning)
            {
                _service.Dispose();
            }
        }
    }
}
