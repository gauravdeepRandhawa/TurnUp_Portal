using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TurnUp_Portal.Pages;

public class Program
{
    private static void Main(string[] args)
    {
        //Open Chrome Browser
        IWebDriver driver = new ChromeDriver();

        //Implicit wait
        //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        //Login page object initialization and definition
        LoginPage loginPageObj = new LoginPage();
        loginPageObj.LoginActions(driver);

        //Home page object initialization and definition
        HomePage homePageObj = new HomePage();
        homePageObj.NavigateToTMPage(driver);

        //TM page object initialization and definition
        TMPage tMPageObj = new TMPage();
        tMPageObj.CreateTimeRecord(driver);
        tMPageObj.EditTimeRecord(driver);
        tMPageObj.DeleteTimeRecord(driver);

        driver.Quit();
    }
}