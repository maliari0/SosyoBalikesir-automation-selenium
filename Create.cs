using Microsoft.VisualStudio.TestTools.UnitTesting;
using SosyoBalikesirTesting.Areas;

namespace SosyoBalikesirTesting
{
    public class Create
    {
        [Test]
        [Order(0)]
        public void MainLogin() 
        {
            string email = "IDFORADMIN";
            string pass = "PASSWFORADMIN";
            var log = new Login();
            log.LoginPhase(email, pass);
        }
        [Test]
        [Order(1)]
        public void MainLocation()
        {
            var loc = new Location();
            loc.LocationPhase();
        }
        [Test]
        [Order(2)]
        public void MainLocationCreate()
        {
            string locationName = "ATest";
            int coinQuantity = 3;
            var loc = new Location();
            loc.LocationCreate(locationName, coinQuantity);
        }
        [Test]
        [Order(3)]
        public void MainCoin()
        {
            var coin = new Coin();
            coin.CoinPhase();
        }
        [Test]
        [Order(4)]
        public void MainCoinCreate()
        {
            int coinValue = 1;
            string type = "coin";
            var coin = new Coin();
            coin.CoinCreate(type, coinValue);
        }
        [Test]
        [Order(5)]
        public void MainPlace()
        {
            var place = new Place();
            place.PlacePhase();
        }
        [Test]
        [Order(6)]
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
        [Order(7)]
        public void MainInfo()
        {
            var info = new Info();
            info.InfoPhase();
        }
        [Test]
        [Order(8)]
        public void MainInfoCreate()
        {
            string body = "ATest";
            int coinValue = 2;
            var info = new Info();
            info.InfoCreate(body, coinValue);
        }
        [Test]
        [Order(9)]
        public void MainPrize()
        {
            var prize = new Prize();
            prize.PrizePhase();
        }
        [Test]
        [Order(10)]
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
        [Order(11)]
        public void MainQuestion()
        {
            var question = new Question();
            question.QuestionPhase();
        }
        [Test]
        [Order(12)]
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
        [Order(13)]
        public void MainUser()
        {
            var user = new User();
            user.UserPhase();
        }
        [Test]
        [Order(14)]
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
        [Test]
        [Order(15)]
        public void MainLogout()
        {
            var logout = new Logout();
            logout.LogoutPhase();
        }
    }
}
