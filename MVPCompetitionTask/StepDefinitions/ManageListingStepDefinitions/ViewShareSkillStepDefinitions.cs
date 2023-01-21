namespace MVPCompetitionTask;
[Binding]
public class ViewShareSkillStepDefinitions
{
    private readonly ViewShareSkillPage VSSP;

    public ViewShareSkillStepDefinitions(ScenarioContext _scenarioContext)
    {
        VSSP = new ViewShareSkillPage(_scenarioContext);
    }

    [Given(@"A user wnats to view a share skill with '([^']*)'")]
    public void GivenAUserWnatsToViewAShareSkillWith(string shareSkillTitle)
    {
        VSSP.ViewShareSkill(shareSkillTitle);
    }

    [Then(@"The user is navigated to the share skill successfully")]
    public void ThenTheUserIsNavigatedToTheShareSkillSuccessfully()
    {
        VSSP.ViewSkillPageAssertion();
    }

}
