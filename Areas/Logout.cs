using NUnit.Framework;

using OpenQA.Selenium;

using OpenQA.Selenium.Chrome;

using OpenQA.Selenium.Firefox;
using SosyoBalikesirTesting.drivers;

namespace SosyoBalikesirTesting.Areas
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
