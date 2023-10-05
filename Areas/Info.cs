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
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.Navigate().GoToUrl("https://sosyobalikesir.com/panel/information");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.FindElement(By.CssSelector("input[type='search']")).SendKeys(name);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);


            //var locationTable = driver.FindElement(By.CssSelector("table"));
            //var rows = locationTable.FindElements(By.TagName("tr"));
            //while (true)
            //{
            //    bool found = false;
            //    foreach (var row in rows)
            //    {
            //        var cells = row.FindElements(By.TagName("td"));
            //        foreach (var cell in cells)
            //        {
            //            if (cell.Text.Contains(name))
            //            {
            //                var deleteButton1 = row.FindElement(By.CssSelector("button.btn-danger"));
            //                deleteButton1.Click();
            //                found = true;
            //                break;
            //            }
            //        }
            //        if (found) break;
            //    }
            //    if (!found) break;
            //}



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
    }
}
