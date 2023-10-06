using OpenQA.Selenium;
using SelTest1.drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelTest1.Areas
{
    internal class Info
    {
        IWebDriver driver = WebDriverManager.GetDriver();
        public void InfoPhase()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            //driver.Navigate().GoToUrl("https://sosyobalikesir.com/panel/place");
            driver.FindElement(By.CssSelector("i[class=\"nav-icon fas fa-poll\"]")).Click();
            //System.Threading.Thread.Sleep(2000); bu kod parçacığı işlemi de wait processine sokuyor. implicitWait kullan
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        }
        public void InfoCreate(string infoBody, int coinValue)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            driver.FindElement(By.CssSelector("i[class=\"fa fa-plus\"]")).Click();

            driver.FindElement(By.Name("body")).SendKeys(infoBody);
            IWebElement coinBox = driver.FindElement(By.Name("value"));
            coinBox.Clear();
            coinBox.SendKeys("" + coinValue);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            driver.FindElement(By.CssSelector(".btn-primary")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        }
        public void InfoDelete(string name)
        {
            bool x = true;
            do
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
                driver.Navigate().GoToUrl("https://sosyobalikesir.com/panel/information");
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
                driver.FindElement(By.CssSelector("input[type='search']")).SendKeys(name);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
                try
                {
                    IWebElement table = driver.FindElement(By.XPath($"//table/tbody/tr[td[text()='{name}']]"));
                    //tbody/tr[1]/td[1]
                    IWebElement deleteButton = table.FindElement(By.CssSelector("form.deleteForm button.btn-danger"));
                    deleteButton.Click();

                    string mainWindowHandle = driver.CurrentWindowHandle; 
                    foreach (string handle in driver.WindowHandles)
                    {
                        if (handle != mainWindowHandle)
                        {
                            driver.SwitchTo().Window(handle); 
                            break;
                        }
                    }

                    IWebElement yesButton = driver.FindElement(By.XPath("//button[text()='Sil']"));
                    yesButton.Click();

                    IWebElement okButton = driver.FindElement(By.XPath("//button[text()='OK']"));
                    okButton.Click();
                }
                catch (NoSuchElementException)
                {

                    break;
                }
            } while (x == true);
 
        }
        public void InfoUpdate(string infoBody,string newInfoBody, int coinValue)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.Navigate().GoToUrl("https://sosyobalikesir.com/panel/information");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.FindElement(By.CssSelector("input[type='search']")).SendKeys(infoBody);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            IWebElement table = driver.FindElement(By.XPath($"//table/tbody/tr[td[text()='{infoBody}']]"));
            //tbody/tr[1]/td[1]
            IWebElement updateButton = table.FindElement(By.CssSelector("i[class=\"fa fa-edit\"]"));
            updateButton.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            IWebElement newTitleElement = driver.FindElement(By.Name("body"));
            newTitleElement.Clear();
            newTitleElement.SendKeys(newInfoBody);

            IWebElement coinBox = driver.FindElement(By.Name("value"));
            coinBox.Clear();
            coinBox.SendKeys("" + coinValue);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            driver.FindElement(By.CssSelector(".btn-primary")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        }
    }
}
