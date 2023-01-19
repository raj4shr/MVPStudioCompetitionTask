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
        private ScenarioContext scenarioContext;
        private IWebDriver driver;
        
        //constructor to get the driver from scenario context
        public Hooks(ScenarioContext _scenarioContext)
        {
            scenarioContext = _scenarioContext;
            driver = (IWebDriver)scenarioContext["driver"];
        }

        //Teardown method to close the web driver after scenario
        [AfterScenario]
        public void ShutDownDriver()
        {
            scenarioContext.Clear();
            driver.Quit();
        }
    }
