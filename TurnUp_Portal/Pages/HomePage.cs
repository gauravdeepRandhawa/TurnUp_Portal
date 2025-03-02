using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnUp_Portal.Pages
{
    public class HomePage
    {
        public void NavigateToTMPage(IWebDriver driver)
        {
            //Navigate to Time and Material
            IWebElement administrationTab = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul[1]/li[5]/a"));
            administrationTab.Click();

            IWebElement timeAndMaterialOption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul[1]/li[5]/ul/li[3]/a"));
            timeAndMaterialOption.Click();
        }
    }
}
