﻿using SosyoBalikesirTesting.drivers;

namespace SosyoBalikesirTesting.Areas
{
    internal class User
    {
        IWebDriver driver = WebDriverManager.GetDriver();
        public void UserPhase()
        {
            Thread.Sleep(500);
            driver.Navigate().GoToUrl("https://www.sosyobalikesir.com/panel/user");
            //driver.FindElement(By.CssSelector("i[class=\"nav-icon fas fa-user\"]")).Click();
            //System.Threading.Thread.Sleep(2000); bu kod parçacığı işlemi de wait processine sokuyor. implicitWait kullan
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        }
        public void UserCreate(string groupType, string name, string userName, string email, string passw)
        {
            Thread.Sleep(100);

            driver.Navigate().GoToUrl("https://www.sosyobalikesir.com/panel/user/create");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            var groupSelect = driver.FindElement(By.Name("user_group"));
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

            Assert.IsTrue(IsUserCreatedSuccessfully(), $"Kullanıcı oluşturma başarısız: {name} isminde başka bir kullanıcı zaten var.");

        }
        private bool IsUserCreatedSuccessfully()
        {
            try
            {
                //driver.FindElement(By.CssSelector(".alert-success"));
                driver.FindElement(By.CssSelector(".swal2-x-mark"));
                return false;
            }
            catch (NoSuchElementException)
            {
                return true;
            }
        }
        public void UserDelete(string name)
        {
            Thread.Sleep(500);

            driver.Navigate().GoToUrl("https://www.sosyobalikesir.com/panel/user");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.FindElement(By.CssSelector("input[type='search']")).SendKeys(name);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            try
            {
                IWebElement table = driver.FindElement(By.XPath($"//table/tbody/tr[td[text()='{name}']]"));
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
                Assert.IsTrue(IsUserDeleteSuccessfully(), $"Kullanıcı silme başarısız: Bu isimde bir kullanıcı bulunamadı: {name}");
            }
        }
        private bool IsUserDeleteSuccessfully()
        {
            try
            {
                driver.FindElement(By.CssSelector(".swal2-x-mark"));
                //driver.FindElement(By.CssSelector(".alert-success"));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }

        }
        public void UserUpdate(string groupType, string name, string newName, string userName, string email, string passw)
        {
            Thread.Sleep(1000);
            driver.Navigate().GoToUrl("https://www.sosyobalikesir.com/panel/user");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.FindElement(By.CssSelector("input[type='search']")).SendKeys(name);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            try
            {
                IWebElement table = driver.FindElement(By.XPath($"//table/tbody/tr[td[text()='{name}']]"));

                IWebElement updateButton = table.FindElement(By.CssSelector("i[class=\"fa fa-edit\"]"));
                updateButton.Click();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

                var groupSelect = driver.FindElement(By.Name("user_group"));  
                var groupSelectElement = new SelectElement(groupSelect);
                groupSelectElement.SelectByValue(groupType);


                IWebElement nameElement = driver.FindElement(By.Name("fullName"));
                nameElement.Clear();
                nameElement.SendKeys(newName);

                IWebElement userNameElement = driver.FindElement(By.Name("username"));
                userNameElement.Clear();
                userNameElement.SendKeys(userName);

                IWebElement emailElement = driver.FindElement(By.Name("email"));
                emailElement.Clear();
                emailElement.SendKeys(email);

                IWebElement passwordElement = driver.FindElement(By.Name("password"));
                passwordElement.Clear();
                passwordElement.SendKeys(passw);

                IWebElement passwordConfirmElement = driver.FindElement(By.Name("password_confirmation"));
                passwordConfirmElement.Clear();
                passwordConfirmElement.SendKeys(passw);

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
                driver.FindElement(By.CssSelector(".btn-primary")).Click();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            }
            catch (NoSuchElementException)
            {
                Assert.IsTrue(IsUserUpdatedSuccessfully(), $"Kullanıcı Güncelleme başarısız! Bu isimde bir kullanıcı bulunamadı: {name}!");
            }
        }
        private bool IsUserUpdatedSuccessfully()
        {
            try
            {
                //driver.FindElement(By.CssSelector(".alert-success"));
                driver.FindElement(By.CssSelector(".swal2-x-mark"));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
