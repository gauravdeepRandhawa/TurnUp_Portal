using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnUp_Portal.Pages
{
    public class LoginPage
    {
        // Functions that allow users to login to TurnUp portal
        public void LoginActions(IWebDriver driver)
        {
            // Launch TurnUp Portal
            driver.Navigate().GoToUrl("http://horse.industryconnect.io/");
            driver.Manage().Window.Maximize();

            // WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            //wait.Until(SeleniumExtras.WaitHelpers.Expected)

            // Identify username textbox and enter valid username
            IWebElement usernameTextbox = driver.FindElement(By.Id("UserName"));
            usernameTextbox.SendKeys("hari");
            

            // Identify password textbox and enter valid password
            IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
            passwordTextbox.SendKeys("123123");

            // Identify login button and click on it
            IWebElement logInButton = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
            logInButton.Click();

        }
    }
}
