using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnUp_Portal.Pages;
using TurnUp_Portal.Utilities;

namespace TurnUp_Portal.Tests
{
    [TestFixture]
    public class TM_Tests : CommonDriver

    {
        [SetUp]
        public void SetUpSteps()
        {
            //Open Chrome Browser
            driver = new ChromeDriver();

            //Login page object initialization and definition
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginActions(driver);

            //Home page object initialization and definition
            HomePage homePageObj = new HomePage();
            homePageObj.NavigateToTMPage(driver);
        }

        [Test]
        public void CreateTime_Test()
        {
            //TM page object initialization and definition
            TMPage tMPageObj = new TMPage();
            tMPageObj.CreateTimeRecord(driver);
        }

        [Test]
        public void EditTime_Test()
        {
            TMPage tMPageObj = new TMPage();
            tMPageObj.EditTimeRecord(driver);
        }

        [Test]
        public void DeleteTime_Test()
        {
            TMPage tMPageObj = new TMPage();
            tMPageObj.DeleteTimeRecord(driver);
            driver.Quit();
        }

        [TearDown]
        public void CloseTestRun()
        {
            driver.Quit();
        }
    }
}
