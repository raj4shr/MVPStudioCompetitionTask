

namespace MVPCompetitionTask;

public class LoginToPortalPage
{
    private IWebDriver driver;
    private IWebElement? webElement;
    private ScenarioContext scenarioContext;
    private CommonSendKeysAndClickElements findElements;

    public LoginToPortalPage(ScenarioContext _scenarioContext)
    {
        scenarioContext = _scenarioContext;
        driver = (IWebDriver)scenarioContext["driver"];
        findElements = new CommonSendKeysAndClickElements(scenarioContext);
    }

    public void LogintoPortal()
    {
        //Opening up MVP portal running on docker image
        driver.Navigate().GoToUrl("http://localhost:5000/");
        driver.Manage().Window.Maximize();
        //Clicking on sign in button
        findElements.clickOnElement(nameof(By.ClassName), "item");
        //Signing in method with valid credentials
        EnterLoginDetails();
    }

    public void EnterLoginDetails()
    {
        //Finding and interacting with elements using my custom common methods
        findElements.sendKeysToElement(nameof(By.Name), "email", "raj4shr@gmail.com");
        findElements.sendKeysToElement(nameof(By.Name), "password", "IndustryConnect2023");
        findElements.clickOnElement(nameof(By.XPath), "//button[text()='Login']");
    }
}
