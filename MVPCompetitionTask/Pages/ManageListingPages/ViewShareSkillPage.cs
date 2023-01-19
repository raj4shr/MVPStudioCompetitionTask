namespace MVPCompetitionTask;

public class ViewShareSkillPage
{
    private ScenarioContext scenarioContext;
    private readonly CommonSendKeysAndClickElements findElements;
    private ReadOnlyCollection<IWebElement>? rowElements, colElements, elements;
    private string shareSkillTitle;
    public ViewShareSkillPage(ScenarioContext _scenarioContext)
    {
        scenarioContext = _scenarioContext;
        findElements = new CommonSendKeysAndClickElements(scenarioContext);
        shareSkillTitle = "";
    }

    public void ViewShareSkill(string shareSkillTitle)
    {
        this.shareSkillTitle = shareSkillTitle;
        findElements.clickOnElement(nameof(By.XPath), "//a[text()='Manage Listings']");
        //Getting all the row elements for manage listings
        rowElements = findElements.findElementsByLocator(nameof(By.XPath), "//tr");
        for (int i = 0; i < rowElements.Count; i++)
        {
            //Getting all the column elements in each row in manage listings
            colElements = rowElements[i].FindElements(By.TagName("td"));
            if (colElements.Count > 0)
            {
                if (colElements[2].Text == shareSkillTitle)
                {
                    //clicking the view button from the 8th column of the row
                    colElements[7].FindElements(By.TagName("button"))[0].Click();
                    break;
                }
            }
        }
    }

    public void ViewSkillPageAssertion()
    {
        findElements.ViewPageNavigated(shareSkillTitle).Should().BeTrue();
    }
}