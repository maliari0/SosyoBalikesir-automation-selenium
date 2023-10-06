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
    internal class Place
    {
        IWebDriver driver = WebDriverManager.GetDriver();
        public void PlacePhase()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.Navigate().GoToUrl("https://sosyobalikesir.com/panel/place");
            //System.Threading.Thread.Sleep(2000); bu kod parçacığı işlemi de wait processine sokuyor. implicitWait kullan
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        }
        public void PlaceCreate(string title1, string address1, int lat, int lon, string status)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            driver.FindElement(By.CssSelector("i[class=\"fa fa-plus\"]")).Click();
            driver.FindElement(By.Name("title")).SendKeys(title1);
            driver.FindElement(By.Name("address")).SendKeys(address1);
            //39.800853 28.133769	
            //driver.FindElement(By.Name("mapLat")).SendKeys(lat);
            //driver.FindElement(By.Name("mapLong")).SendKeys(lon);
            IWebElement latBox = driver.FindElement(By.Name("map_lat"));
            latBox.SendKeys("" + lat);
            IWebElement longBox = driver.FindElement(By.Name("map_long"));
            longBox.SendKeys("" + lon);

            var statusSelect = driver.FindElement(By.Name("status"));
            var statusSelectElement = new SelectElement(statusSelect);
            if (status == "show")
            {
                statusSelectElement.SelectByValue("1");

            }
            else if (status == "hide")
            {
                statusSelectElement.SelectByValue("0");
            }
            else { }
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            driver.FindElement(By.CssSelector(".btn-primary")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        }
        public void PlaceDelete(string name)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.Navigate().GoToUrl("https://sosyobalikesir.com/panel/place");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.FindElement(By.CssSelector("input[type='search']")).SendKeys(name);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
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
        public void PlaceUpdate(string title1, string newTitle1, string newAddress1, float lat, float lon, string status)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.FindElement(By.CssSelector("input[type='search']")).SendKeys(title1);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            IWebElement table = driver.FindElement(By.XPath($"//table/tbody/tr[td[text()='{title1}']]"));
            IWebElement updateButton = table.FindElement(By.CssSelector("i[class=\"fa fa-edit\"]"));
            updateButton.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            IWebElement newTitleElement = driver.FindElement(By.Name("title"));
            newTitleElement.Clear();
            newTitleElement.SendKeys(newTitle1);

            IWebElement newAddressElement = driver.FindElement(By.Name("address"));
            newAddressElement.Clear();
            newAddressElement.SendKeys(newAddress1);
            //39.800853 28.133769	
            //driver.FindElement(By.Name("mapLat")).SendKeys(lat);
            //driver.FindElement(By.Name("mapLong")).SendKeys(lon);
            IWebElement latBox = driver.FindElement(By.Name("map_lat"));
            latBox.Clear();
            latBox.SendKeys("" + lat);
            IWebElement longBox = driver.FindElement(By.Name("map_long"));
            longBox.Clear();
            longBox.SendKeys("" + lon);

            var statusSelect = driver.FindElement(By.Name("status"));
            var statusSelectElement = new SelectElement(statusSelect);
            if (status == "show")
            {
                statusSelectElement.SelectByValue("1");

            }
            else if (status == "hide")
            {
                statusSelectElement.SelectByValue("0");
            }
            else { }
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            driver.FindElement(By.CssSelector(".btn-primary")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        }
    }
}
