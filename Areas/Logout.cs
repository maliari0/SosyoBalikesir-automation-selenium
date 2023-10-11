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
    internal class Logout
    {
        IWebDriver driver = WebDriverManager.GetDriver();

        public void LogoutPhase() 
        {
            System.Threading.Thread.Sleep(1000);
            //IWebElement logoutButton = driver.FindElement(By.CssSelector("i[class=\"fas fa-sign-out-alt\"]"));
            //logoutButton.Click();
            driver.Navigate().GoToUrl("https://www.sosyobalikesir.com/log-out");
        }
    }
}
