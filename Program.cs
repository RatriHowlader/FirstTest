
// See https://aka.ms/new-console-template for more information
using AventStack.ExtentReports;
using CsvHelper;
using FirstTest;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Formats.Asn1;
using System.Globalization;

public class FirstSelenium
{
    public static string DataCSVFile = System.IO.Directory.GetCurrentDirectory();
    private static TextReader reader;

    static void Main(string[] args)
    {
        var testDataList = ReadCsvData(DataCSVFile + "\\Data\\Data.csv");
        IWebDriver driver = new ChromeDriver();
        ExtentReports extentReports = new ExtentReports();


        driver.Navigate().GoToUrl("https://practicetestautomation.com/practice-test-login/");
        Console.WriteLine("Open Browser");

        driver.Manage().Window.Maximize();
        Console.WriteLine("Browser Maximize");
        foreach (var test in testDataList)
        {
            driver.FindElement(By.Id("username")).SendKeys(test.username);
            Console.WriteLine("Provide username: " + test.username);

            driver.FindElement(By.Id("password")).SendKeys(test.password);
            Console.WriteLine("Provide Password: " + test.password);

            driver.FindElement(By.Id("submit")).Click();
            Console.WriteLine("Hit Submit button");

            try
            {
                driver.FindElement(By.CssSelector(".wp-block-button__link")).Click();
                break;
            }
            catch
            {
                Console.WriteLine("Failed Login");
            }
        }








        }
        static List<Testdata> ReadCsvData(String filePath)
        {
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                return new List<Testdata>(csv.GetRecords<Testdata>());
            }
        }
    }

