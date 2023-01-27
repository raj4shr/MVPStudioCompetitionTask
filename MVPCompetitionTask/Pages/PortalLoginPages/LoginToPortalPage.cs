

using AventStack.ExtentReports;
using ExcelDataReader;
using System.Data;

namespace MVPCompetitionTask;

public class LoginToPortalPage
{
    private IWebDriver driver;
    private CommonSendKeysAndClickElements findElements;
    private ExtentTest test;
    private ExtentReports testReport;
    private IExcelDataReader? reader;
    private FileStream? stream;
    private DataSet? dataset;
    private DataTable? table;
    private string path,username,password;
    public LoginToPortalPage(ScenarioContext _scenarioContext)
    {
        //Encoding excel file stream
        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        path = username = password = "";
        driver = (IWebDriver)_scenarioContext["driver"];
        findElements = new CommonSendKeysAndClickElements(_scenarioContext);
        testReport = (ExtentReports)_scenarioContext["extentReport"];
        test = testReport.CreateTest("Test_LoginToPortal"+DateTime.Now.ToString("_hhmmss")).Info("Login Test");
        
    }

    public void LogintoPortal()
    {
       
        //Opening up MVP portal running on docker image
        driver.Navigate().GoToUrl("http://localhost:5000/");
        test.Log(Status.Info, "Navigate to Url");
        driver.Manage().Window.Maximize();
        //Clicking on sign in button
        findElements.clickOnElement(nameof(By.ClassName), "item");
        test.Log(Status.Info, "Click on Sign In");
        //Signing in method with valid credentials
        EnterLoginDetails();
    }

    public void EnterLoginDetails()
    {
        try
        {
            //Path of the excel file with log in credentials
            path = @"C:\MVPCompetitionTask\MVPStudioCompetitionTask\MVPCompetitionTask\LoginCred.xlsx";
            //Setting the stream for excel data reader
            stream = File.Open(path, FileMode.Open, FileAccess.Read);
            reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            //storing data from the excel file as dataset
            dataset = reader.AsDataSet();
            //Excel sheet from the file is stored as table. Since only 1 sheet present, index is 0
            table = dataset.Tables[0];
            username = table.Rows[1][0].ToString();
            password = table.Rows[1][1].ToString();
            //Finding and interacting with elements using my custom common methods
            findElements.sendKeysToElement(nameof(By.Name), "email", username);
            findElements.sendKeysToElement(nameof(By.Name), "password", password);
            test.Log(Status.Info, "Send username and password credentials");
            findElements.clickOnElement(nameof(By.XPath), "//button[text()='Login']");
            test.Log(Status.Info, "Login Button Clicked");
            test.Log(Status.Pass, "Test Passed");
            //Closing the streams
            reader.Close();
            stream.Close();
        }
        catch
        {
            test.Log(Status.Fail, "Test Failed");
            throw;
        }
    }
}
