using SosyoBalikesirTesting.drivers;

namespace SosyoBalikesirTesting.Areas
{
    internal class Location
    {
        IWebDriver driver = WebDriverManager.GetDriver();
        public void LocationPhase()
        {            
            
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            Thread.Sleep(500);
            //driver.FindElement(By.CssSelector("i[class=\"nav-icon fas fa-location-arrow\"]")).Click();
            driver.Navigate().GoToUrl("https://www.sosyobalikesir.com/panel/location");
            //System.Threading.Thread.Sleep(2000); bu kod parçacığı işlemi de wait processine sokuyor. implicitWait kullan
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            

        }
        public void LocationCreate(string locName, int coinNum)
        {
            Thread.Sleep(300);
            //driver.FindElement(By.CssSelector("i[class=\"fa fa-plus\"]")).Click();
            driver.Navigate().GoToUrl("https://www.sosyobalikesir.com/panel/location/create");
            driver.FindElement(By.Name("name")).SendKeys(locName);
            IWebElement coinBox =  driver.FindElement(By.Name("default_coin_amount"));
            coinBox.Clear();
            coinBox.SendKeys("" + coinNum);
            driver.FindElement(By.CssSelector(".btn-primary")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            Assert.IsTrue(IsLocationCreatedSuccessfully(), $"Lokasyon oluşturma başarısız: {locName} isminde bir lokasyon zaten var.");
        }
        private bool IsLocationCreatedSuccessfully()
        {
            try
            {
                driver.FindElement(By.CssSelector(".alert-success"));
                return false; 
            }
            catch (NoSuchElementException)
            {
                return true; 
            }
        }
        public void LocationDelete(string locName)
        {
            Thread.Sleep(500);

            driver.Navigate().GoToUrl("https://www.sosyobalikesir.com/panel/location");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.FindElement(By.CssSelector("input[type='search']")).SendKeys(locName);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            try
            {
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
            }
            catch (NoSuchElementException e)
            {
                Assert.IsTrue(IsLocationDeleteSuccessfully(), $"Lokasyon silme başarısız: Bu isimde lokasyon bulunamadı: {locName}");
            }
        }
        private bool IsLocationDeleteSuccessfully()
        {
            try
            {
                driver.FindElement(By.CssSelector(".alert-success"));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }

        }
        public void LocationUpdate(string locName, string newLocName, int coinNum)
        {
            Thread.Sleep(500);
            driver.Navigate().GoToUrl("https://www.sosyobalikesir.com/panel/location");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            //IWebElement table = driver.FindElement(By.XPath($"//table/tbody/tr[td[text()='{locName}']]"));
            driver.FindElement(By.CssSelector("input[type='search']")).SendKeys(locName);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            IWebElement table = driver.FindElement(By.XPath($"//table/tbody/tr[td[text()='{locName}']]"));

            IWebElement updateButton = table.FindElement(By.CssSelector("i[class=\"fa fa-edit\"]"));
            updateButton.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            IWebElement nameElement = driver.FindElement(By.Name("name"));
            nameElement.Clear();
            nameElement.SendKeys(newLocName);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            IWebElement coinBox = driver.FindElement(By.Name("default_coin_amount"));
            coinBox.Clear();
            coinBox.SendKeys("" + coinNum);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            driver.FindElement(By.CssSelector(".btn-primary")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            Assert.IsTrue(IsLocationUpdatedSuccessfully(), $"Lokasyon güncelleme başarısız: Bu isimde lokasyon bulunamadı: {locName}");
        }
        private bool IsLocationUpdatedSuccessfully()
        {
            try
            {
                driver.FindElement(By.CssSelector(".alert-success"));
                return false;
            }
            catch (NoSuchElementException)
            {
                return true;
            }
        }
    }
}
