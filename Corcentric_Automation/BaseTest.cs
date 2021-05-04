using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace Corcentric_Automation
{    
    public class BaseTest 
    {
        public IWebDriver driver;

        [TestInitialize]
        public void Start()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");
            driver = new ChromeDriver();
            driver.Url = "https://demoqa.com/";
        }

        [TestCleanup]
        public void End()
        {
            driver.Quit();
        }
    }
}
