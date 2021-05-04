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
            Thread.Sleep(5000);
            formPage.NavigateToPracticeForm();
            Thread.Sleep(5000);
            PartialFormPage partialFormPage = new PartialFormPage(driver);
            partialFormPage.FillMandatoryPartialFormFields();
            Thread.Sleep(5000);
            partialFormPage.SubmitPartialFormFields();            
            Assert.IsTrue(partialFormPage.IsSuccessfulSubmission());
            Thread.Sleep(5000);
        }

        [TestMethod]
        public void SubmitFormFailureRequiredFields()
        {
            FormPage formPage = new FormPage(driver);
            formPage.NavigateToForm();
            Thread.Sleep(5000);
            formPage.NavigateToPracticeForm();
            Thread.Sleep(5000);
            PartialFormPage partialFormPage = new PartialFormPage(driver);
            partialFormPage.SubmitPartialFormFields();
            Thread.Sleep(5000);
            Assert.IsTrue(partialFormPage.IsFailedSubmission());
            Thread.Sleep(5000);
        }
    }
}
