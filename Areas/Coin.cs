using SosyoBalikesirTesting.drivers;

namespace SosyoBalikesirTesting.Areas
{
    internal class Coin
    {
        IWebDriver driver = WebDriverManager.GetDriver();
        public void CoinPhase()
        {
            Thread.Sleep(500);
            driver.Navigate().GoToUrl("https://www.sosyobalikesir.com/panel/coin");
            //driver.FindElement(By.CssSelector("i[class=\"nav-icon fas fa-coins\"]")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

        }
        public void CoinCreate(string type1, int coinValue)
        {
            Thread.Sleep(500);
            //driver.FindElement(By.CssSelector("i[class=\"fa fa-plus\"]")).Click();
            driver.Navigate().GoToUrl("https://www.sosyobalikesir.com/panel/coin/create");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            var locationSelect = driver.FindElement(By.Id("location_id"));
            var locSelectElement = new SelectElement(locationSelect);
            locSelectElement.SelectByIndex(locSelectElement.Options.Count - 1);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            var typeSelect = driver.FindElement(By.Name("type"));
            var typeSelectElement = new SelectElement(typeSelect);
            if (type1 == "coin")
            {
                typeSelectElement.SelectByValue("1");
            }
            else if (type1 == "bilgi")
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
            Assert.IsTrue(IsCoinCreatedSuccessfully(), "Coin oluşturma başarısız: Maksimum coin miktarı aşıldı.");
        }
        private bool IsCoinCreatedSuccessfully()
        {
            try
            {
                driver.FindElement(By.CssSelector(".swal2-x-mark"));
                //driver.FindElement(By.CssSelector(".alert-success"));
                return false;
            }
            catch (NoSuchElementException)
            {
                return true;
            }
        }

        public void CoinDelete(string name)
        {
            bool x = true;
            do
            {
                Thread.Sleep(500);
                driver.Navigate().GoToUrl("https://www.sosyobalikesir.com/panel/coin");
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
                driver.FindElement(By.CssSelector("input[type='search']")).SendKeys(name);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
                try
                {
                    IWebElement table = driver.FindElement(By.XPath($"//table/tbody/tr[td[text()='{name}']]"));
                    IWebElement deleteButton = table.FindElement(By.CssSelector("form.deleteForm button.btn-danger"));
                    deleteButton.Click();
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

                    string mainWindowHandle = driver.CurrentWindowHandle; // Ana pencerenin işaretçisini al
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
                    x = true;
                }
                catch (NoSuchElementException)
                {
                    break;
                }
            } while (x == true);
        }
        public void CoinUpdate(string name, string type1, int coinValue)
        {
            Thread.Sleep(500);
            driver.FindElement(By.CssSelector("input[type='search']")).SendKeys(name);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            IWebElement table = driver.FindElement(By.XPath($"//table/tbody/tr[td[text()='{name}']]"));
            IWebElement updateButton = table.FindElement(By.CssSelector("i[class=\"fa fa-edit\"]"));
            updateButton.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            var locationSelect = driver.FindElement(By.Id("location_id"));
            var locSelectElement = new SelectElement(locationSelect);
            locSelectElement.SelectByIndex(locSelectElement.Options.Count - 2);

            IWebElement latElement = driver.FindElement(By.Name("map_lat"));
            latElement.Clear();
            latElement.SendKeys("39.273");
            IWebElement longElement = driver.FindElement(By.Name("map_long"));
            longElement.Clear();
            longElement.SendKeys("27.999");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            var typeSelect = driver.FindElement(By.Name("type"));
            var typeSelectElement = new SelectElement(typeSelect);
            if (type1 == "coin")
            {
                typeSelectElement.SelectByValue("1");

            }
            else if (type1 == "bilgi")
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
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

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
    }
}
