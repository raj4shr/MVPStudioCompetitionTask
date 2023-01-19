

namespace MVPCompetitionTask;

public class AddShareSkillPage
{
    private readonly CommonSendKeysAndClickElements findElements;
    private ScenarioContext? scenarioContext;
    private ReadOnlyCollection<IWebElement>? elements;
    private string shareSkilltitle;
    public AddShareSkillPage(ScenarioContext _scenarioContext)
    {
        shareSkilltitle = "";
        scenarioContext = _scenarioContext;
        findElements = new CommonSendKeysAndClickElements(scenarioContext);
    }

    public void AddNewShareSkill(string shareSkillTitle,string shareSkillDesc,string shareSkillCategory,string shareSkillSubcategory)
    {
        SelectElement option;
        this.shareSkilltitle = shareSkillTitle;
        //Adding a share skill for user profile using my custom class to interact with web elements
        findElements.clickOnElement(nameof(By.XPath), "//a[text()='Share Skill']");
        findElements.sendKeysToElement(nameof(By.Name), "title", shareSkillTitle);
        findElements.sendKeysToElement(nameof(By.Name), "description", shareSkillDesc);
        //Selecting the value from drop down listboxes
        option = new SelectElement(findElements.ReturnElement(nameof(By.Name), "categoryId"));
        option.SelectByText(shareSkillCategory);
        option = new SelectElement(findElements.ReturnElement(nameof(By.Name), "subcategoryId"));
        option.SelectByText(shareSkillSubcategory);
        //Adding other values in the share skill page
        elements = findElements.findElementsByLocator(nameof(By.XPath), "//input[@placeholder='Add new tag']");
        elements[0].SendKeys(shareSkillTitle);
        elements[0].SendKeys(Keys.Enter);
        elements[1].SendKeys(shareSkillSubcategory);
        elements[1].SendKeys(Keys.Enter);
        elements=findElements.findElementsByLocatorElementExits(nameof(By.Name),"Available");
        elements[3].Click();
        elements = findElements.findElementsByLocatorElementExits(nameof(By.Name), "StartTime");
        elements[3].SendKeys("07:00 am");
        elements[3].SendKeys(Keys.Enter);
        elements = findElements.findElementsByLocatorElementExits(nameof(By.Name), "EndTime");
        elements[3].SendKeys("16:00");
        elements[3].SendKeys(Keys.Enter);
        findElements.clickOnElement(nameof(By.XPath), "//input[@value='Save']");
    }

    public void ShareSkillAddedAssertion()
    {
        findElements.CheckShareSkillExists(shareSkilltitle).Should().BeTrue();
    }
}




