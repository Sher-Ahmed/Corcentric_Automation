using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corcentric_Automation.PageObjects
{
    public class PracticeFormPage
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
        public IWebElement SubmitPracticeFormBtn { get; set; }

        public PracticeFormPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        // Summary:
        //     Filling data mandatory fields of practice form.
        public void FillMandatoryPracticeFormFields()
        {
            FirstNameTextBox.SendKeys("Sher");
            LastNameTextBox.SendKeys("Ahmed");
            IJavaScriptExecutor ex = (IJavaScriptExecutor)driver;
            ex.ExecuteScript("arguments[0].checked = true;", GenderRadioButton);
            MobileNumberTextBox.SendKeys("03432323231");
        }

        // Summary:
        //     Submitting practice form fields.
        public void SubmitPracticeFormFields()
        {
            IJavaScriptExecutor ex = (IJavaScriptExecutor)driver;
            ex.ExecuteScript("arguments[0].scrollIntoView();", SubmitPracticeFormBtn);
            SubmitPracticeFormBtn.Click();
        }

        // Summary:
        //     Checking if successful submission model has appeared. 
        public bool IsSuccessfulSubmission()
        {
            bool is_valid;

            try
            {
                is_valid = driver.FindElement(By.Id("example-modal-sizes-title-lg")).Size.IsEmpty ? false : true;
            }
            catch
            {
                is_valid = false;
            }

            return is_valid;
        }

        
        // Summary:
        //     Checking if mandatory fields are empty or not.
        public bool IsFailedSubmission()
        {
            FirstNameTextBox.SendKeys("Sher");
            bool is_valid;

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            is_valid = (Boolean)js.ExecuteScript("return arguments[0].checkValidity();", FirstNameTextBox);
            is_valid = is_valid == true ? (Boolean)js.ExecuteScript("return arguments[0].checkValidity();", LastNameTextBox) : false;
            is_valid = is_valid == true ? GenderRadioButton.Selected : false;
            is_valid = is_valid == true ? (Boolean)js.ExecuteScript("return arguments[0].checkValidity();", MobileNumberTextBox) : false;

            return is_valid == true ? false : true;
        }

    }
}
