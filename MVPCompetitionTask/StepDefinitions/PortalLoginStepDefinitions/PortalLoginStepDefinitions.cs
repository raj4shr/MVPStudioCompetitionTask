namespace MVPCompetitionTask;
[Binding]
public class PortalLoginStepDefinitions
{
    private CommonDriver? cd;
    private LoginToPortalPage LTPP;

    public PortalLoginStepDefinitions(ScenarioContext _scenarioContext)
    {
        cd = new(_scenarioContext);
        cd.InitReports();
        //Adding variables to scenario context to be used in the entire scenario
        _scenarioContext.Add("driver", cd.Driver);
        _scenarioContext.Add("extentReport",cd.TestReport);
        LTPP = new LoginToPortalPage(_scenarioContext);
    }

    [Given(@"User logs in to the website")]
    public void GivenUserLogsInToTheWebsite()
    {
        LTPP.LogintoPortal();
    }

}
