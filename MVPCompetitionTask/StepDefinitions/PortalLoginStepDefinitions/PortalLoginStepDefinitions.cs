namespace MVPCompetitionTask;
[Binding]
public class PortalLoginStepDefinitions
{
    private CommonDriver? cd;
    private ScenarioContext? scenarioContext;
    private LoginToPortalPage LTPP;

    public PortalLoginStepDefinitions(ScenarioContext _scenarioContext)
    {
        cd = new();
        //Adding common driver to scenario context to be used in entire scenario
        scenarioContext = _scenarioContext;
        scenarioContext.Add("driver", cd.Driver);
        LTPP = new(scenarioContext);
    }

    [Given(@"User logs in to the website")]
    public void GivenUserLogsInToTheWebsite()
    {
        LTPP.LogintoPortal();
    }

}
