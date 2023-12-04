using SosyoBalikesirTesting.drivers;
using System.Diagnostics;

namespace SosyoBalikesirTesting.Areas
{
    internal class Place
    {
        IWebDriver driver = WebDriverManager.GetDriver();
        public void PlacePhase()
        {
            Thread.Sleep(100);
            driver.Navigate().GoToUrl("https://www.sosyobalikesir.com/panel/place");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        }
        public void PlaceCreate(string title1, string address1, int lat, int lon, string status)
        {
            Thread.Sleep(500);
            driver.Navigate().GoToUrl("https://www.sosyobalikesir.com/panel/place/create");
            driver.FindElement(By.Name("title")).SendKeys(title1);
            driver.FindElement(By.Name("address")).SendKeys(address1);
            //39.800853 28.133769	
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
        int count = 0;

        public void PlaceDelete(string name)
        {
            bool x = true;
            do
            {
                Thread.Sleep(100);
                driver.Navigate().GoToUrl("https://www.sosyobalikesir.com/panel/place");
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
                driver.FindElement(By.CssSelector("input[type='search']")).SendKeys(name);   //sonradan eklendi hata varssa budur.
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
                try
                {
                    IWebElement table = driver.FindElement(By.XPath($"//table/tbody/tr[td[text()='{name}']]"));
                    IWebElement deleteButton = table.FindElement(By.CssSelector("form.deleteForm button.btn-danger"));
                    deleteButton.Click();
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
                    count++;
                    IWebElement yesButton = driver.FindElement(By.XPath("//button[text()='Sil']"));
                    yesButton.Click();

                    IWebElement okButton = driver.FindElement(By.XPath("//button[text()='OK']"));
                    okButton.Click();
                }
                catch (NoSuchElementException) 
                {
                    if (count == 0)
                    {
                        Assert.IsTrue(IsPlaceDeleteSuccessfully(), $"{name} isimli bir yer bulunamadı. ");
                        break;
                    }
                    else
                    {
                        Debug.WriteLine($"{count} adet yer silindi.");
                        Console.WriteLine($"{count} adet yer silindi.");
                        break;
                    }
                }
            }
            while (x == true);       
        }
        private bool IsPlaceDeleteSuccessfully()
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
        public void PlaceUpdate(string title1, string newTitle1, string newAddress1, float lat, float lon, string status)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.FindElement(By.CssSelector("input[type='search']")).SendKeys(title1);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            try
            {
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
            catch (NoSuchElementException)
            {
                Assert.IsTrue(IsPlaceUpdatedSuccessfully(), $"Yer güncelleme başarısız: Bu isimde bir yer bulunamadı: {title1}");
            }
        }
        private bool IsPlaceUpdatedSuccessfully()
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
