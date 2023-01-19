global using TechTalk.SpecFlow;
global using FluentAssertions;
global using OpenQA.Selenium;
global using OpenQA.Selenium.Chrome;
global using System.Collections.ObjectModel;
global using OpenQA.Selenium.Support.UI;
global using SeleniumExtras.WaitHelpers;

namespace MVPCompetitionTask;

public class CommonDriver
{
    //Common webdriver class
    private IWebDriver? driver;

    public CommonDriver()
    {
        driver = new ChromeDriver();
    }

    public IWebDriver Driver
    {
        get
        {
            return driver;
        }

    }
}
