using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnUp_Portal.Utilities;

namespace TurnUp_Portal.Pages
{
    public class TMPage
    {
        public void CreateTimeRecord(IWebDriver driver)
        {
            //Click on Create new button
            try
            {
                IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
                createNewButton.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("Create new button has not been found.");
            }
            
            //Select Time from dropdown
            IWebElement typeCodeDropdown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span"));
            typeCodeDropdown.Click();

            IWebElement timeOption = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span"));
            timeOption.Click();

            //Type code into Code textbox
            IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
            codeTextbox.SendKeys("TC_0001");

            //type description into Description textbox
            IWebElement descriptionTextBox = driver.FindElement(By.Id("Description"));
            descriptionTextBox.SendKeys("New Entry");

            //Type price into Price textbox
            IWebElement priceTagOverlap = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            priceTagOverlap.Click();

            IWebElement priceTextbox = driver.FindElement(By.Id("Price"));
            priceTextbox.SendKeys("12");

            //Click on save button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();

            //Explicit Wait
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span")));

            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[4]/a[4]/span", 2);
            // Check if Time record has been created successfully
            try
            {
                IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
                goToLastPageButton.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]", 2);
            IWebElement newCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

            if (newCode.Text == "TC_0001")
            {
                Assert.Pass("Time record has been created");

            }
            else
            {
                Assert.Fail("Time record has not been created");
            }
        }

        // Edit new record
        public void EditTimeRecord(IWebDriver driver)
        {
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[4]/a[4]/span", 2);
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButton.Click();

            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]", 2);
            IWebElement lastRecordEditButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
            lastRecordEditButton.Click();

            Wait.WaitToBeVisible(driver, "Id", "Description", 2);
            IWebElement descriptionTextBoxEdit = driver.FindElement(By.Id("Description"));
            descriptionTextBoxEdit.Clear();
            descriptionTextBoxEdit.SendKeys("New edited entry");

            IWebElement saveButton1 = driver.FindElement(By.Id("SaveButton"));
            saveButton1.Click();

            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[4]/a[4]/span", 2);
            IWebElement goToLastPageButtonCheck = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButtonCheck.Click();

            Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]", 3);
            IWebElement editedDescription = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));

            Assert.That(editedDescription.Text == "New edited entry", "Time record has not been edited");

            //if (editedDescription.Text == "New edited entry")
            //{
            //    Console.WriteLine("Time record has been edited");

            //}
            //else
            //{
            //    Console.WriteLine("Time record has not been edited");
            //}

        }

        // Delete new record added at last
        public void DeleteTimeRecord(IWebDriver driver)
        {
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[4]/a[4]/span", 2);
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButton.Click();

            Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]", 5);
            IWebElement newCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]", 5);
            IWebElement lastRecordDeleteButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
            lastRecordDeleteButton.Click();

            //wait
            Wait.WaitForAlertToBePresent(driver, 3);
            driver.SwitchTo().Alert().Accept();
            
            Thread.Sleep(3000);

            driver.Navigate().Refresh();

            //Check if the record is deleted  //*[@id="tmsGrid"]/div[3]/table/tbody/tr[3]/td[5]/a[2]
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]", 3);
            IWebElement deletedRecord = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

            Assert.That(deletedRecord.Text != "TC_0001", "Time record has not been edited");

            
        }

    }
}
