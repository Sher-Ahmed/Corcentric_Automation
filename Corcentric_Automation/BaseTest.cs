using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;

namespace Corcentric_Automation
{    
    public class BaseTest 
    {
        public IWebDriver driver;

        [TestInitialize]
        public void Start()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.AddArguments("start-maximized");
            driver = new FirefoxDriver();
            driver.Url = "https://demoqa.com/";
        }

        [TestCleanup]
        public void End()
        {
            driver.Quit();
        }
    }
}
