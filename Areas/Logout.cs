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
        public void LogoutPhase() 
        {
            System.Threading.Thread.Sleep(2000);
            IWebDriver driver = WebDriverManager.GetDriver();
            IWebElement logoutButton = driver.FindElement(By.CssSelector("i[class=\"fas fa-sign-out-alt\"]"));
            logoutButton.Click();

            // İsteğe bağlı olarak çıkış sonrası beklemek için bir süre bekleme ekleyebilirsiniz.
            System.Threading.Thread.Sleep(2000);
        }
        
    }
}
