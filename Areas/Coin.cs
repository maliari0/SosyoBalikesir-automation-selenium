﻿using NUnit.Framework;

using OpenQA.Selenium;

using OpenQA.Selenium.Chrome;

using OpenQA.Selenium.Firefox;

using System;

using System.Collections.ObjectModel;

using System.IO;

using NUnit.Framework;

using OpenQA.Selenium.Support.UI;

using SelTest1.drivers;
using OpenQA.Selenium.DevTools.V115.Debugger;
using NUnit.Framework.Interfaces;

namespace SelTest1.Areas
{
    internal class Coin
    {
        //https://sosyobalikesir.com/panel/coin
        IWebDriver driver = WebDriverManager.GetDriver();
        public void CoinPhase()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.FindElement(By.CssSelector("i[class=\"nav-icon fas fa-coins\"]")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            
        }
        public void CoinCreate(string type1, int coinValue)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            driver.FindElement(By.CssSelector("i[class=\"fa fa-plus\"]")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            var locationSelect = driver.FindElement(By.Id("location_id"));
            var locSelectElement = new SelectElement(locationSelect);
            locSelectElement.SelectByIndex(locSelectElement.Options.Count - 1);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            var typeSelect = driver.FindElement(By.Name("type"));
            var typeSelectElement = new SelectElement(typeSelect);
            if(type1 == "coin")
            {
                typeSelectElement.SelectByValue("1");

            }
            else if(type1 == "bilgi")
            {
                typeSelectElement.SelectByValue("2");
            }
            else { }

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            IWebElement coinBox = driver.FindElement(By.Name("value"));
            coinBox.Clear();
            coinBox.SendKeys("" + coinValue);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.FindElement(By.Id("map")).Click();
            //driver.FindElement(By.Id("addedCoinAmountBtn")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            driver.FindElement(By.CssSelector(".btn-primary")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

        }
        public void CoinDelete(string name)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.Navigate().GoToUrl("https://sosyobalikesir.com/panel/coin");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            //IWebElement table = driver.FindElement(By.XPath($"//table/tbody/tr[td[text()='{name}']]"));
            var locationTable = driver.FindElement(By.CssSelector("table"));
            var rows = locationTable.FindElements(By.TagName("tr"));
            foreach (var row in rows)
            {
                var cells = row.FindElements(By.TagName("td"));
                foreach (var cell in cells)
                {
                    if (cell.Text.Contains(name))
                    {
                        var deleteButton = row.FindElement(By.CssSelector("button.btn-danger"));
                        deleteButton.Click();
                        break;
                    }
                }
            }


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