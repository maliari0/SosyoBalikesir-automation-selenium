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
    internal class Location
    {
        IWebDriver driver = WebDriverManager.GetDriver();
        public void LocationPhase()
        {
            System.Threading.Thread.Sleep(2000);
            
            
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.FindElement(By.CssSelector("i[class=\"nav-icon fas fa-location-arrow\"]")).Click();
            //driver.Navigate().GoToUrl("https://sosyobalikesir.com/panel/location");
            //System.Threading.Thread.Sleep(2000); bu kod parçacığı işlemi de wait processine sokuyor. implicitWait kullan
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            

        }
        public void LocationCreate(string locName, int coinNum)
        {
            //driver.Navigate().GoToUrl("https://sosyobalikesir.com/panel/location/create");
            driver.FindElement(By.CssSelector("i[class=\"fa fa-plus\"]")).Click();
            driver.FindElement(By.Name("name")).SendKeys(locName);
            IWebElement coinBox =  driver.FindElement(By.Name("default_coin_amount"));
            coinBox.SendKeys("" + coinNum);
            driver.FindElement(By.CssSelector(".btn-primary")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

        }
        public void LocationDelete(string locName)
        {
            driver.Navigate().GoToUrl("https://sosyobalikesir.com/panel/location");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            IWebElement table = driver.FindElement(By.XPath($"//table/tbody/tr[td[text()='{locName}']]"));
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

            //IWebElement webElement = driver.FindElement(By.XPath("//table/tbody/tr[td[text('locName')"));
            //IWebElement webElement1 = webElement.FindElement(By.XPath(".//td[3]/div/a"));
            //webElement1.Click();
            //By.XPath("//table/tbody/tr[td[text()="+ locName
            //String name = updateBilgi;
            //WebElement row = driver.findElement(By.xpath("//table/tbody/tr[td[text()='" + name + "']]"));
            //WebElement updatebutton = row.findElement(By.xpath(".//td[3]/div/a"));
        }



    }
}
