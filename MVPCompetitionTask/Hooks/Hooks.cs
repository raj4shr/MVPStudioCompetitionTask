using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace MVPCompetitionTask;
[Binding]
public class Hooks
{
    private readonly ScenarioContext scenarioContext;
    private IWebDriver driver;
    private ExtentReports testReport;

    //constructor to get the driver from scenario context
    public Hooks(ScenarioContext _scenarioContext)
    {
        testReport = (ExtentReports)_scenarioContext["extentReport"];
        scenarioContext = _scenarioContext;
        driver = (IWebDriver)_scenarioContext["driver"];
    }

    
    

    //Teardown method to close the web driver after scenario
    [AfterScenario]
    public void ShutDownDriver()
    {
        scenarioContext.Clear();
        testReport.Flush();
        driver.Quit();
    }
    
}
