using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corcentric_Automation.PageObjects
{
    public class PartialFormPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.Id, Using = "firstName")]
        public IWebElement FirstNameTextBox { get; set; }

        [FindsBy(How = How.Id, Using = "lastName")]
        public IWebElement LastNameTextBox { get; set; }

        [FindsBy(How = How.Id, Using = "gender-radio-1")]
        public IWebElement GenderRadioButton { get; set; }

        [FindsBy(How = How.Id, Using = "userNumber")]
        public IWebElement MobileNumberTextBox { get; set; }

        [FindsBy(How = How.Id, Using = "submit")]
        public IWebElement SubmitPartialFormBtn { get; set; }

        public PartialFormPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


        public void FillMandatoryPartialFormFields()
        {
            FirstNameTextBox.SendKeys("Sher");
            LastNameTextBox.SendKeys("Ahmed");
            IJavaScriptExecutor ex = (IJavaScriptExecutor)driver;
            ex.ExecuteScript("arguments[0].checked = true;", GenderRadioButton);
            MobileNumberTextBox.SendKeys("03432323231");
        }

        public void SubmitPartialFormFields()
        {
            IJavaScriptExecutor ex = (IJavaScriptExecutor)driver;
            ex.ExecuteScript("arguments[0].scrollIntoView();", SubmitPartialFormBtn);
            SubmitPartialFormBtn.Click();
        }

        public bool IsSuccessfulSubmission()
        {
            Boolean is_valid = false;
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            is_valid = (Boolean)js.ExecuteScript("return arguments[0].checkValidity();", FirstNameTextBox);
            is_valid = is_valid == true ? (Boolean)js.ExecuteScript("return arguments[0].checkValidity();", LastNameTextBox) : false;
            is_valid = is_valid == true ? GenderRadioButton.Selected : false;
            is_valid = is_valid == true ? (Boolean)js.ExecuteScript("return arguments[0].checkValidity();", MobileNumberTextBox) : false;


            if (is_valid)
            {
                try
                {
                    is_valid = driver.FindElement(By.Id("example-modal-sizes-title-lg")).Size.IsEmpty ? false : true;
                }
                catch
                {
                    is_valid = false;
                }

            }

            return is_valid;
        }

        public bool IsFailedSubmission()
        {
            Boolean is_valid = false;
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            is_valid = (Boolean)js.ExecuteScript("return arguments[0].checkValidity();", FirstNameTextBox);
            is_valid = is_valid == false ? (Boolean)js.ExecuteScript("return arguments[0].checkValidity();", LastNameTextBox) : true;
            is_valid = is_valid == false ? GenderRadioButton.Selected : true;
            is_valid = is_valid == false ? (Boolean)js.ExecuteScript("return arguments[0].checkValidity();", MobileNumberTextBox) : true;

            return is_valid == true ? false : true;
        }

    }
}
