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
using System.Xml.Linq;

namespace SelTest1.Areas
{
    internal class Prize
    {

        IWebDriver driver = WebDriverManager.GetDriver();
        public void PrizePhase()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.Navigate().GoToUrl("https://sosyobalikesir.com/panel/award");
            //System.Threading.Thread.Sleep(2000); bu kod parçacığı işlemi de wait processine sokuyor. implicitWait kullan
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        }
        public void PrizeCreate(string value, string prizeName, string prizeDesc, int coinNum, int prizeAmount)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            driver.FindElement(By.CssSelector("i[class=\"fa fa-plus\"]")).Click();

            var prizeSelect = driver.FindElement(By.Id("dealers"));
            var prizeSelectElement = new SelectElement(prizeSelect);
            //prizeSelectElement.SelectByValue("414"); //ATest value = 414 you can change
            prizeSelectElement.SelectByIndex(prizeSelectElement.Options.Count - 1);


            var typeSelect = driver.FindElement(By.Id("type"));
            var typeSelectElement = new SelectElement(typeSelect);
            typeSelectElement.SelectByValue(value);

            driver.FindElement(By.Name("name")).SendKeys(prizeName);

            driver.FindElement(By.Name("description")).SendKeys(prizeDesc);

            IWebElement coinBox = driver.FindElement(By.Name("coin_amount"));
            coinBox.Clear();
            coinBox.SendKeys("" + coinNum);

            IWebElement amountBox = driver.FindElement(By.Name("amount"));
            amountBox.Clear();
            amountBox.SendKeys("" + prizeAmount);

            driver.FindElement(By.CssSelector(".btn-primary")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        }
        public void PrizeDelete(string name)
        {
            bool x = true;
            do
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
                driver.Navigate().GoToUrl("https://sosyobalikesir.com/panel/award");
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
                driver.FindElement(By.CssSelector("input[type='search']")).SendKeys(name);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

                try
                {
                    IWebElement table = driver.FindElement(By.XPath($"//table/tbody/tr[td[text()='{name}']]"));
                    //tbody/tr[1]/td[1]
                    IWebElement deleteButton = table.FindElement(By.CssSelector("form.deleteForm button.btn-danger"));
                    deleteButton.Click();

                    string mainWindowHandle = driver.CurrentWindowHandle; // Ana pencerenin işaretçisini alın
                    foreach (string handle in driver.WindowHandles)
                    {
                        if (handle != mainWindowHandle)
                        {
                            driver.SwitchTo().Window(handle); // Pop-up penceresine geçiş yapın
                            break;
                        }
                    }

                    // Pop-up penceresindeki 'Evet' butonuna tıklayın
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
        public void PrizeUpdate(string value, string prizeName, string prizeDesc, int coinAmount, int prizeAmount, int claimAmount, string prizeStatus)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.Navigate().GoToUrl("https://sosyobalikesir.com/panel/award");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            IWebElement table = driver.FindElement(By.XPath($"//table/tbody/tr[td[text()='{prizeName}']]"));

            IWebElement updateButton = table.FindElement(By.CssSelector("i[class=\"fa fa-edit\"]"));
            updateButton.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            var prizeSelect = driver.FindElement(By.Id("dealers"));
            var prizeSelectElement = new SelectElement(prizeSelect);
            //prizeSelectElement.SelectByValue("414"); //ATest value = 414 you can change
            prizeSelectElement.SelectByIndex(prizeSelectElement.Options.Count - 1);


            var headlineSelect = driver.FindElement(By.Id("headline"));
            var headlineSelectElement = new SelectElement(headlineSelect);
            headlineSelectElement.SelectByValue(value);                         // 0 - hayır , 1 - evet

            IWebElement nameElement = driver.FindElement(By.Name("name"));
            nameElement.Clear();
            nameElement.SendKeys(prizeName);

            IWebElement prizeDescElement = driver.FindElement(By.Name("description"));
            prizeDescElement.Clear();
            prizeDescElement.SendKeys(prizeDesc);

            IWebElement coinBox = driver.FindElement(By.Name("coin_amount"));
            coinBox.Clear();
            coinBox.SendKeys("" + coinAmount);

            IWebElement amountBox = driver.FindElement(By.Name("amount"));
            amountBox.Clear();
            amountBox.SendKeys("" + prizeAmount);

            IWebElement claimAmountBox = driver.FindElement(By.Name("claim_amount"));
            claimAmountBox.Clear();
            claimAmountBox.SendKeys("" + claimAmount);

            var statusSelect = driver.FindElement(By.Name("status"));
            var statusSelectElement = new SelectElement(statusSelect);
            statusSelectElement.SelectByValue(prizeStatus);



            driver.FindElement(By.CssSelector(".btn-primary")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            //IWebElement newTitleElement = driver.FindElement(By.Name("body"));
            //newTitleElement.Clear();
            //newTitleElement.SendKeys(newInfoBody);

            //IWebElement coinBox = driver.FindElement(By.Name("value"));
            //coinBox.Clear();
            //coinBox.SendKeys("" + coinValue);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            driver.FindElement(By.CssSelector(".btn-primary")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        }
    }
}
