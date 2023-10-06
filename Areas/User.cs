﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SelTest1.drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelTest1.Areas
{
    internal class User
    {
        IWebDriver driver = WebDriverManager.GetDriver();
        public void UserPhase()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            //driver.Navigate().GoToUrl("https://sosyobalikesir.com/panel/place");
            driver.FindElement(By.CssSelector("i[class=\"nav-icon fas fa-user\"]")).Click();
            //System.Threading.Thread.Sleep(2000); bu kod parçacığı işlemi de wait processine sokuyor. implicitWait kullan
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        }
        public void UserCreate(string groupType, string name, string userName, string email, string passw)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            driver.FindElement(By.CssSelector("i[class=\"fa fa-plus\"]")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            var groupSelect = driver.FindElement(By.Name("user_group"));  //Grup seçimi
            var groupSelectElement = new SelectElement(groupSelect);
            groupSelectElement.SelectByValue(groupType);


            driver.FindElement(By.Name("fullName")).SendKeys(name);
            driver.FindElement(By.Name("username")).SendKeys(userName);
            driver.FindElement(By.Name("email")).SendKeys(email);
            driver.FindElement(By.Name("password")).SendKeys(passw);
            driver.FindElement(By.Name("password_confirmation")).SendKeys(passw);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            driver.FindElement(By.CssSelector(".btn-primary")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        }
        public void UserDelete(string name)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.Navigate().GoToUrl("https://sosyobalikesir.com/panel/user");
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