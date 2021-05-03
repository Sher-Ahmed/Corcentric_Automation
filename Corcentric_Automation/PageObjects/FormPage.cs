using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corcentric_Automation.PageObjects
{
    public class FormPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "/html/body/div/div/div/div[2]/div/div[2]/div/div[3]/h5")]
        public IWebElement SearchForm { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div/div/div/div[2]/div[1]/div/div/div[2]/div/ul/li/span")]
        public IWebElement SearchPartialForm { get; set; }

        public FormPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


        public void NavigateToForm()
        {
            IJavaScriptExecutor ex = (IJavaScriptExecutor)driver;
            ex.ExecuteScript("arguments[0].scrollIntoView();", SearchForm);
            SearchForm.Click();
        }

        public void NavigateToPracticeForm()
        {
            IJavaScriptExecutor ex = (IJavaScriptExecutor)driver;
            ex.ExecuteScript("arguments[0].scrollIntoView();", SearchPartialForm);
            SearchPartialForm.Click();
        }
    }
}
