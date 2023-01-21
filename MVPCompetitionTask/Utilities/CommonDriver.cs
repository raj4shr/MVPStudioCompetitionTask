global using TechTalk.SpecFlow;
global using FluentAssertions;
global using OpenQA.Selenium;
global using OpenQA.Selenium.Chrome;
global using System.Collections.ObjectModel;
global using OpenQA.Selenium.Support.UI;
global using SeleniumExtras.WaitHelpers;
using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using AventStack.ExtentReports.Reporter.Configuration;

namespace MVPCompetitionTask;

public class CommonDriver
{
    //Common webdriver class
    private IWebDriver driver;
    private ExtentReports testReport;
    private ScenarioContext scenarioContext;
    public CommonDriver(ScenarioContext _scenarioContext)
    {
        scenarioContext = _scenarioContext;
        driver = new ChromeDriver();
        testReport = new ExtentReports();
    }

    public IWebDriver Driver
    {
        get
        {
            return driver;
        }

    }

    public ExtentReports TestReport
    {
        get { return testReport; }
    }

    //Extent report initialisation
    public void InitReports()
    {
        string path = @"C:\ExtentReports\" + DateTime.Now.ToString("_MMddyyyy_hhmmss") + @"\index.html";
        var htmlReporter = new ExtentHtmlReporter(path);
        htmlReporter.Config.Theme = Theme.Dark;
        testReport.AttachReporter(htmlReporter);
    }

}
