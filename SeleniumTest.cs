using NUnit.Framework;

using OpenQA.Selenium;

using OpenQA.Selenium.Chrome;

using OpenQA.Selenium.Firefox;

using System;

using System.Collections.ObjectModel;

using System.IO;

using NUnit.Framework;

using OpenQA.Selenium.Support.UI;

using SelTest1.Areas;

namespace SelTest1
{
    public class Tests
    {

        [Test]
        [Order(0)]
        public void MainLogin() 
        {
            string email = "maliari4558@gmail.com";
            string pass = "26242615";
            var log = new Login();
            log.LoginPhase(email, pass);
        }

        //[Test]
        //[Order(1)]
        //public void MainLogout()
        //{
        //    var logout = new Logout();
        //    logout.LogoutPhase();
        //}

        [Test]
        [Order(2)]
        public void MainLocation()
        {
            var loc = new Location();
            loc.LocationPhase();
        }
        [Test]
        [Order(3)]
        public void MainLocationCreate()
        {
            string locationName = "ATest";
            int coinQuantity = 3;
            var loc = new Location();
            loc.LocationCreate(locationName, coinQuantity);
        }
        [Test]
        [Order(4)]
        public void MainLocationDelete()
        {
            var loc = new Location();
            string locationName = "ATest";
            loc.LocationDelete(locationName);
        }
        public void cssDemo()
        {
            //m_driver = new ChromeDriver("C:\\Users\\malia\\source\\repos\\SelTest1\\drivers\\chromedriver.exe");
            //m_driver.Url = "https://sosyobalikesir.com/login";
            //m_driver.Manage().Window.Maximize();

            //IWebDriver driver = new ChromeDriver();
            //driver.Navigate().GoToUrl("https://sosyobalikesir.com/panel");
            //driver.FindElement(By.Name("email")).SendKeys("maliari4558@gmail.com");
            //driver.FindElement(By.Name("password")).SendKeys("26242615");
            //driver.FindElement(By.CssSelector(".btn-primary")).Click();

            //// Store locator values of email text box and sign up button				
            //IWebElement emailTextBox = m_driver.FindElement(By.XPath(".//*[@id='philadelphia-field-email']"));
            //IWebElement signUpButton = m_driver.FindElement(By.XPath(".//*[@id='philadelphia-field-submit']"));

            //emailTextBox.SendKeys("test123@gmail.com");
            //signUpButton.Click();

            // Store locator values of email text box and sign up button				
            //IWebElement emailTextBox = m_driver.FindElement(By.CssSelector("input[id=philadelphia-field-email]"));
            //IWebElement signUpButton = m_driver.FindElement(By.CssSelector("input[id=philadelphia-field-submit]"));

            //emailTextBox.SendKeys("test123@gmail.com");
            //signUpButton.Click();

            //IWebElement course = m_driver.FindElement(By.XPath(".//*[@id='awf_field-91977689']"));
            //IWebElement emailTextBox = m_driver.FindElement(By.XPath(".//*[@id='philadelphia-field-email']"));
            //IWebElement signUpButton = m_driver.FindElement(By.XPath(".//*[@id='philadelphia-field-submit']"));

            //var selectTest = new SelectElement(course);
            //// Select a value from the dropdown				
            //selectTest.SelectByValue("sap-abap");
            //emailTextBox.SendKeys("test123@test.com");
            //signUpButton.Click();
        }
    }
}
