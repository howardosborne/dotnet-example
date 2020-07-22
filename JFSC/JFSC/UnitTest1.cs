using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace JFSC
{
    [TestClass]
    public class UnitTest1
    {
        static IWebDriver driver;
        [ClassInitialize]
        static public void startup(TestContext context)
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://portal.jerseyfsc.org/");
        }
        [TestMethod]
        public void home_page_has_valid_contact_link()
        {
            IWebElement contact_link = driver.FindElement(By.XPath("//a[text()='Contact Us']"));
            String contact_href = contact_link.GetAttribute("href");
            Assert.IsTrue(contact_href.Contains("/Pages/ContactUs.aspx"));

        }

        [TestMethod]
        public void new_user_registers_through_happy_path()
        {
            driver.FindElement(By.XPath("//a[@href='/Pages/UserProfile.aspx?mode=new']")).Click();
            driver.FindElement(By.Name("ctl00$PlaceHolderMain$registrationControl$emailBox")).SendKeys("justignore@example.com");
            driver.FindElement(By.Name("ctl00$PlaceHolderMain$registrationControl$emailBoxConfirm")).SendKeys("justignore@example.com");
            driver.FindElement(By.Name("ctl00$PlaceHolderMain$registrationControl$passwordBox")).SendKeys("JustIgnore");
            driver.FindElement(By.Name("ctl00$PlaceHolderMain$registrationControl$confirmPasswordBox")).SendKeys("JustIgnore");
            new SelectElement(driver.FindElement(By.Name("ctl00$PlaceHolderMain$registrationControl$Title"))).SelectByValue("Mr");
            driver.FindElement(By.Name("ctl00$PlaceHolderMain$registrationControl$FirstName")).SendKeys("Bob");
            driver.FindElement(By.Name("ctl00$PlaceHolderMain$registrationControl$Surname")).SendKeys("Jones");
            new SelectElement(driver.FindElement(By.Name("ctl00$PlaceHolderMain$registrationControl$Birthday$Day"))).SelectByValue("6");
            new SelectElement(driver.FindElement(By.Name("ctl00$PlaceHolderMain$registrationControl$Birthday$Month"))).SelectByValue("1");
            new SelectElement(driver.FindElement(By.Name("ctl00$PlaceHolderMain$registrationControl$Birthday$Year"))).SelectByValue("1980");
            driver.FindElement(By.Name("ctl00$PlaceHolderMain$registrationControl$HomeAddress1")).SendKeys("1 High Street");
            new SelectElement(driver.FindElement(By.Name("ctl00$PlaceHolderMain$registrationControl$HomeAddressCountry"))).SelectByValue("United Kingdom");
            driver.FindElement(By.Name("ctl00$PlaceHolderMain$registrationControl$HomeAddress1")).SendKeys("AB1 2AS");
            //check now on correct page
            Assert.IsTrue(driver.Title.Equals("Registered"));
        }

        [ClassCleanup]
        static public void teardown()
        {
            driver.Close();
        }
    }
}
