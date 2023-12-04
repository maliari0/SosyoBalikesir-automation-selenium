using SosyoBalikesirTesting.drivers;
namespace SosyoBalikesirTesting.Areas
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
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(6);

        }
    }
}
