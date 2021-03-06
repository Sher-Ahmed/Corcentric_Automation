using Corcentric_Automation.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Corcentric_Automation.TestCases
{
    [TestClass]
    public class DemoqaTestCases : BaseTest
    {
        [TestMethod]
        public void SubmitFormSuccess()
        {
            FormPage formPage = new FormPage(driver);
            formPage.NavigateToForm();            
            formPage.NavigateToPracticeForm();            
            PracticeFormPage practiceFormPage = new PracticeFormPage(driver);
            practiceFormPage.FillMandatoryPracticeFormFields();            
            practiceFormPage.SubmitPracticeFormFields();            
            Assert.IsTrue(practiceFormPage.IsSuccessfulSubmission());            
        }

        [TestMethod]
        public void SubmitFormFailureRequiredFields()
        {
            FormPage formPage = new FormPage(driver);
            formPage.NavigateToForm();            
            formPage.NavigateToPracticeForm();            
            PracticeFormPage practiceFormPage = new PracticeFormPage(driver);
            practiceFormPage.SubmitPracticeFormFields();            
            Assert.IsTrue(practiceFormPage.IsFailedSubmission());            
        }
    }
}
