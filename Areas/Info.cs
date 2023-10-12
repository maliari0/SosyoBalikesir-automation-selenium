using SosyoBalikesirTesting.drivers;

namespace SosyoBalikesirTesting.Areas
{
    internal class Info
    {
        IWebDriver driver = WebDriverManager.GetDriver();
        public void InfoPhase()
        {
            Thread.Sleep(500);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.Navigate().GoToUrl("https://www.sosyobalikesir.com/panel/information");
            //driver.FindElement(By.CssSelector("i[class=\"nav-icon fas fa-poll\"]")).Click();
            //System.Threading.Thread.Sleep(2000); bu kod parçacığı işlemi de wait processine sokuyor. implicitWait kullan
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        }
        public void InfoCreate(string infoBody, int coinValue)
        {
            Thread.Sleep(1000);

            driver.FindElement(By.CssSelector("i[class=\"fa fa-plus\"]")).Click();

            driver.FindElement(By.Name("body")).SendKeys(infoBody);
            IWebElement coinBox = driver.FindElement(By.Name("value"));
            coinBox.Clear();
            coinBox.SendKeys("" + coinValue);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            driver.FindElement(By.CssSelector(".btn-primary")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        }
        int count = 0;

        public void InfoDelete(string name)
        {
            bool x = true;
            do
            {
                Thread.Sleep(1000);
                driver.Navigate().GoToUrl("https://www.sosyobalikesir.com/panel/information");
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
                driver.FindElement(By.CssSelector("input[type='search']")).SendKeys(name);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
                try
                {
                    IWebElement table = driver.FindElement(By.XPath($"//table/tbody/tr[td[text()='{name}']]"));
                    //tbody/tr[1]/td[1]
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
                    count++;
                    IWebElement yesButton = driver.FindElement(By.XPath("//button[text()='Sil']"));
                    yesButton.Click();

                    IWebElement okButton = driver.FindElement(By.XPath("//button[text()='OK']"));
                    okButton.Click();
                    
                }
                catch (NoSuchElementException)
                {
                    //Assert.IsTrue(IsInfoDeleteSuccessfully(), $"Bilgi silme başarısız: Bu isimde bilgi bulunamadı: {name}. {count} adet veri silindi.");
                    if (count == 0)
                    {
                        Assert.IsTrue(IsInfoDeleteSuccessfully(), $"{name} isimli bilgi bulunamadı. ");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"{count} adet bilgi silindi.");
                        break;
                    }
                }
                
            } while (x == true);
 
        }
        private bool IsInfoDeleteSuccessfully()
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
        public void InfoUpdate(string infoBody,string newInfoBody, int coinValue)
        {
            Thread.Sleep(1000);
            driver.Navigate().GoToUrl("https://www.sosyobalikesir.com/panel/information");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.FindElement(By.CssSelector("input[type='search']")).SendKeys(infoBody);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            try
            {
                IWebElement table = driver.FindElement(By.XPath($"//table/tbody/tr[td[text()='{infoBody}']]"));
                IWebElement updateButton = table.FindElement(By.CssSelector("i[class=\"fa fa-edit\"]"));
                updateButton.Click();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

                IWebElement newTitleElement = driver.FindElement(By.Name("body"));
                newTitleElement.Clear();
                newTitleElement.SendKeys(newInfoBody);

                IWebElement coinBox = driver.FindElement(By.Name("value"));
                coinBox.Clear();
                coinBox.SendKeys("" + coinValue);

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
                driver.FindElement(By.CssSelector(".btn-primary")).Click();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            }
            catch (NoSuchElementException)
            {
                Assert.IsTrue(IsInfoUpdatedSuccessfully(), $"Bilgi güncelleme başarısız: Bu isimde bir bilgi bulunamadı: {infoBody}");

            }

        }
        private bool IsInfoUpdatedSuccessfully()
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
    }
}
