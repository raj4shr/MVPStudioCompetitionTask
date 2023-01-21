namespace MVPCompetitionTask;
[Binding]
public class AddNewShareSkillStepDefinitions
{
    private readonly AddShareSkillPage ASSP;

    public AddNewShareSkillStepDefinitions(ScenarioContext _scenarioContext)
    {
        ASSP = new AddShareSkillPage(_scenarioContext);
    }

    [Given(@"A new user share skill is added with '([^']*)','([^']*)', '([^']*)' and '([^']*)'")]
    public void GivenANewUserShareSkillIsAdded(string title, string description, string category, string subcategory)
    {
        ASSP.AddNewShareSkill(title, description, category, subcategory);
    }


    [Then(@"The share skill is added to the user profile successfully")]
    public void ThenTheShareSkillIsAddedToTheUserProfileSuccessfully()
    {
        ASSP.ShareSkillAddedAssertion();
    }

}
