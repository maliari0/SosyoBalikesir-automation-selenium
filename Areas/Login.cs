    using NUnit.Framework;

    using OpenQA.Selenium;

    using OpenQA.Selenium.Chrome;

    using OpenQA.Selenium.Firefox;

    using System;

    using System.Collections.ObjectModel;

    using System.IO;

    using NUnit.Framework;

    using OpenQA.Selenium.Support.UI;
using SelTest1.drivers;

namespace SelTest1.Areas
{
    internal class Login
    {
        public void LoginPhase(string email, string passw)
        {
            IWebDriver driver = WebDriverManager.GetDriver(); 
            driver.Navigate().GoToUrl("https://www.sosyobalikesir.com/login");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            driver.FindElement(By.Name("email")).SendKeys(email);
            driver.FindElement(By.Name("password")).SendKeys(passw);
            driver.FindElement(By.CssSelector(".btn-primary")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

        }
    }
}
