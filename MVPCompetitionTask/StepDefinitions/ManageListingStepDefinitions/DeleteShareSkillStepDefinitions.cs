namespace MVPCompetitionTask;
[Binding]
public class DeleteShareSkillStepDefinitions
{
    private ScenarioContext scenarioContext;
    private readonly DeleteShareSkillPage DSSP;
    public DeleteShareSkillStepDefinitions(ScenarioContext _scenarioContext)
    {
        scenarioContext = _scenarioContext;
        DSSP=new DeleteShareSkillPage(scenarioContext);
    }
    [Given(@"A user deletes a share skill with '([^']*)'")]
    public void GivenAUserDeletesAShareSkill(string shareSkillTitle)
    {
        DSSP.DeleteShareSkill(shareSkillTitle);
    }

    [Then(@"The share skill should be deleted successfully")]
    public void ThenTheShareSkillShouldBeDeletedSuccessfully()
    {
        DSSP.DeleteShareSkillAssertion();
    }
   


}
