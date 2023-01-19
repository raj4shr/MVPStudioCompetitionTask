

namespace MVPCompetitionTask;

public class DeleteShareSkillPage
{
    private ScenarioContext scenarioContext;
    private readonly CommonSendKeysAndClickElements findElements;
    private ReadOnlyCollection<IWebElement>? rowElements,colElements,elements;
    private string shareSkillTitle;
    public DeleteShareSkillPage(ScenarioContext _scenarioContext)
    {
        scenarioContext = _scenarioContext;
        findElements=new CommonSendKeysAndClickElements(scenarioContext);
    }

    public void DeleteShareSkill(string shareSkillTitle)
    {
        this.shareSkillTitle=shareSkillTitle;
        findElements.clickOnElement(nameof(By.XPath), "//a[text()='Manage Listings']");
        //Getting all the row elements for manage listings
        rowElements = findElements.findElementsByLocator(nameof(By.XPath), "//tr");
        for(int i=0;i< rowElements.Count;i++)
        {
            //Getting all the column elements in each row in manage listings
            colElements = rowElements[i].FindElements(By.TagName("td"));
            if (colElements.Count > 0)
            {
                if (colElements[2].Text == shareSkillTitle)
                {
                    //clicking the delete button from the 8th column of the row
                    colElements[7].FindElements(By.TagName("button"))[2].Click();
                    //Confirming delete
                    elements = findElements.findElementsByLocator(nameof(By.XPath), "//button");
                    elements[elements.Count - 1].Click();
                    break;
                }
            }
        }
    }

    public void DeleteShareSkillAssertion()
    {
        //Returns false if the record is not found(means record is deleted)
        findElements.CheckShareSkillExists(shareSkillTitle).Should().BeFalse();
    }
}
