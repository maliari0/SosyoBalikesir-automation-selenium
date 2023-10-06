using NUnit.Framework;

using OpenQA.Selenium;

using OpenQA.Selenium.Chrome;

using OpenQA.Selenium.Firefox;

using System;

using System.Collections.ObjectModel;

using System.IO;

using NUnit.Framework;

using OpenQA.Selenium.Support.UI;

using SelTest1.Areas;

namespace SelTest1
{
    public class Tests
    {

        [Test]
        [Order(0)]
        public void MainLogin() 
        {
            string email = "aliari4558@gmail.com";
            string pass = "26242615";
            var log = new Login();
            log.LoginPhase(email, pass);
        }

        //[Test]
        //[Order(1)]
        //public void MainLogout()
        //{
        //    var logout = new Logout();
        //    logout.LogoutPhase();
        //}

        [Test]
        [Order(2)]
        public void MainLocation()
        {
            var loc = new Location();
            loc.LocationPhase();
        }
        [Test]
        [Order(3)]
        public void MainLocationCreate()
        {
            string locationName = "ATest";
            int coinQuantity = 3;
            var loc = new Location();
            loc.LocationCreate(locationName, coinQuantity);
        }
        //[Test]
        //[Order(4)]
        //public void MainLocationDelete()
        //{
        //    var loc = new Location();
        //    string locationName = "ATest";
        //    loc.LocationDelete(locationName);
        //}
        [Test]
        [Order(5)]
        public void MainCoin()
        {
            var coin = new Coin();
            coin.CoinPhase();
        }
        [Test]
        [Order(6)]
        public void MainCoinCreate()
        {
            int coinValue = 1;
            string type = "coin";
            var coin = new Coin();
            coin.CoinCreate(type, coinValue);
        }
        [Test]
        [Order(7)]
        public void MainPlace()
        {
            var place = new Place();
            place.PlacePhase();
        }
        [Test]
        [Order(8)]
        public void MainPlaceCreate()
        {
            //string title1, string address1, string lat, string lon, string status
            string title = "ATest";
            string address = "ATest address";
            int lat = 39;
            int lon = 28;
            string status = "show";
            var place = new Place();
            place.PlaceCreate(title, address, lat, lon, status);
        }
        [Test]
        [Order(9)]
        public void MainInfo()
        {
            var info = new Info();
            info.InfoPhase();
        }
        [Test]
        [Order(10)]
        public void MainInfoCreate()
        {
            string body = "ATest";
            int coinValue = 2;
            var info = new Info();
            info.InfoCreate(body, coinValue);
        }
        [Test]
        [Order(11)]
        public void MainPrize()
        {
            var prize = new Prize();
            prize.PrizePhase();
        }
        [Test]
        [Order(12)]
        public void MainPrizeCreate()
        {
            //Values= other , internet , balkart
            string value = "other";
            string name = "ATest";
            string desc = "ATest Desc";
            int coinNum = 12;
            int amount = 12;
            var prize = new Prize();
            prize.PrizeCreate(value, name, desc, coinNum, amount);
        }
        [Test]
        [Order(13)]
        public void MainQuestion()
        {
            var question = new Question();
            question.QuestionPhase();
        }
        [Test]
        [Order(14)]
        public void MainQuestionCreate()
        {
            // Birden çok yanýt - 1 , Çoktan seçmeli - 2 , Boþluk doldurma - 3
            string text = "ATest text";
            int coinValue = 2;
            int type = 1;
            int questionAmount = 4;
            var question = new Question();
            question.QuestionCreate(text, coinValue, type, questionAmount);
        }
        [Test]
        [Order(15)]
        public void MainUserPhase()
        {
            var user = new User();
            user.UserPhase();
        }
        [Test]
        [Order(16)]
        public void MainUserCreate()
        {
            var user = new User();
            string type = "admin";    // dealer = Bayii , admin = Admin
            string name = "ATest";
            string userName = "atest";
            string email = "atest@test.com";
            string password = "atest12";
            user.UserCreate(type, name, userName, email, password);
        }
        public void cssDemo()
        {
            //m_driver = new ChromeDriver("C:\\Users\\malia\\source\\repos\\SelTest1\\drivers\\chromedriver.exe");
            //m_driver.Url = "https://sosyobalikesir.com/login";
            //m_driver.Manage().Window.Maximize();

            //IWebDriver driver = new ChromeDriver();
            //driver.Navigate().GoToUrl("https://sosyobalikesir.com/panel");
            //driver.FindElement(By.Name("email")).SendKeys("maliari4558@gmail.com");
            //driver.FindElement(By.Name("password")).SendKeys("26242615");
            //driver.FindElement(By.CssSelector(".btn-primary")).Click();

            //// Store locator values of email text box and sign up button				
            //IWebElement emailTextBox = m_driver.FindElement(By.XPath(".//*[@id='philadelphia-field-email']"));
            //IWebElement signUpButton = m_driver.FindElement(By.XPath(".//*[@id='philadelphia-field-submit']"));

            //emailTextBox.SendKeys("test123@gmail.com");
            //signUpButton.Click();

            // Store locator values of email text box and sign up button				
            //IWebElement emailTextBox = m_driver.FindElement(By.CssSelector("input[id=philadelphia-field-email]"));
            //IWebElement signUpButton = m_driver.FindElement(By.CssSelector("input[id=philadelphia-field-submit]"));

            //emailTextBox.SendKeys("test123@gmail.com");
            //signUpButton.Click();

            //IWebElement course = m_driver.FindElement(By.XPath(".//*[@id='awf_field-91977689']"));
            //IWebElement emailTextBox = m_driver.FindElement(By.XPath(".//*[@id='philadelphia-field-email']"));
            //IWebElement signUpButton = m_driver.FindElement(By.XPath(".//*[@id='philadelphia-field-submit']"));

            //var selectTest = new SelectElement(course);
            //// Select a value from the dropdown				
            //selectTest.SelectByValue("sap-abap");
            //emailTextBox.SendKeys("test123@test.com");
            //signUpButton.Click();
        }
    }
}
