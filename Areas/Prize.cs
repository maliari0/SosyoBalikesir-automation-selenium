using SosyoBalikesirTesting.drivers;
using System.Diagnostics;

namespace SosyoBalikesirTesting.Areas
{
    internal class Prize
    {

        IWebDriver driver = WebDriverManager.GetDriver();
        public void PrizePhase()
        {
            Thread.Sleep(100);
            driver.Navigate().GoToUrl("https://www.sosyobalikesir.com/panel/award");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        }
        public void PrizeCreate(string value, string prizeName, string prizeDesc, int coinNum, int prizeAmount)
        {
            Thread.Sleep(500);
            //driver.FindElement(By.CssSelector("i[class=\"fa fa-plus\"]")).Click();
            driver.Navigate().GoToUrl("https://www.sosyobalikesir.com/panel/award/create");

            var prizeSelect = driver.FindElement(By.Id("dealers"));
            var prizeSelectElement = new SelectElement(prizeSelect);
            //prizeSelectElement.SelectByValue("414"); //ATest value = 414 you can change
            prizeSelectElement.SelectByIndex(prizeSelectElement.Options.Count - 1);

            var typeSelect = driver.FindElement(By.Id("type"));
            var typeSelectElement = new SelectElement(typeSelect);
            typeSelectElement.SelectByValue(value);

            driver.FindElement(By.Name("name")).SendKeys(prizeName);
            driver.FindElement(By.Name("description")).SendKeys(prizeDesc);
            IWebElement coinBox = driver.FindElement(By.Name("coin_amount"));
            coinBox.Clear();
            coinBox.SendKeys("" + coinNum);
            IWebElement amountBox = driver.FindElement(By.Name("amount"));
            amountBox.Clear();
            amountBox.SendKeys("" + prizeAmount);

            driver.FindElement(By.CssSelector(".btn-primary")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        }
        int count = 0;

        public void PrizeDelete(string name)
        {
            bool x = true;
            do
            {
                Thread.Sleep(1000);
                driver.Navigate().GoToUrl("https://www.sosyobalikesir.com/panel/award");
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
                        Assert.IsTrue(IsPrizeDeleteSuccessfully(), $"{name} isimli ödül bulunamadı. ");
                        break;
                    }
                    else
                    {
                        Debug.WriteLine($"{count} adet ödül silindi.");
                        Console.WriteLine($"{count} adet ödül silindi.");
                        break;
                    }
                }
            } while (x == true);
        }
        private bool IsPrizeDeleteSuccessfully()
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
        public void PrizeUpdate(string value, string prizeName, string newPrizeName, string prizeDesc, int coinAmount, int prizeAmount, int claimAmount, string prizeStatus)
        {
            Thread.Sleep(1000);
            driver.Navigate().GoToUrl("https://www.sosyobalikesir.com/panel/award");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.FindElement(By.CssSelector("input[type='search']")).SendKeys(prizeName);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            try
            {
                IWebElement table = driver.FindElement(By.XPath($"//table/tbody/tr[td[text()='{prizeName}']]"));

                IWebElement updateButton = table.FindElement(By.CssSelector("i[class=\"fa fa-edit\"]"));
                updateButton.Click();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

                var prizeSelect = driver.FindElement(By.Id("dealers"));
                var prizeSelectElement = new SelectElement(prizeSelect);
                prizeSelectElement.SelectByIndex(prizeSelectElement.Options.Count - 1);


                var headlineSelect = driver.FindElement(By.Id("headline"));
                var headlineSelectElement = new SelectElement(headlineSelect);
                headlineSelectElement.SelectByValue(value);                         // 0 - hayır , 1 - evet

                IWebElement nameElement = driver.FindElement(By.Name("name"));
                nameElement.Clear();
                nameElement.SendKeys(newPrizeName);

                IWebElement prizeDescElement = driver.FindElement(By.Name("description"));
                prizeDescElement.Clear();
                prizeDescElement.SendKeys(prizeDesc);

                IWebElement coinBox = driver.FindElement(By.Name("coin_amount"));
                coinBox.Clear();
                coinBox.SendKeys("" + coinAmount);

                IWebElement amountBox = driver.FindElement(By.Name("amount"));
                amountBox.Clear();
                amountBox.SendKeys("" + prizeAmount);

                IWebElement claimAmountBox = driver.FindElement(By.Name("claim_amount"));
                claimAmountBox.Clear();
                claimAmountBox.SendKeys("" + claimAmount);

                var statusSelect = driver.FindElement(By.Name("status"));
                var statusSelectElement = new SelectElement(statusSelect);
                statusSelectElement.SelectByValue(prizeStatus);

                driver.FindElement(By.CssSelector(".btn-primary")).Click();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            }
            catch (NoSuchElementException)
            {
                Assert.IsTrue(IsPrizeUpdatedSuccessfully(), $"Ödül güncelleme başarısız: Bu isimde bir ödül bulunamadı: {prizeName}");
            }

        }
        private bool IsPrizeUpdatedSuccessfully()
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
