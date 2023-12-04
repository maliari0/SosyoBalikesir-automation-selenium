using SosyoBalikesirTesting.Areas;

namespace SosyoBalikesirTesting
{
    public class Collapse
    {
        [Test]
        [Order(0)]
        public void MainLogin()
        {
            string email = "aliari4558@gmail.com";
            string pass = "28117121";
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
        public void MainLocationDelete()
        {
            var loc = new Location();
            string locationName = "ATest";
            loc.LocationDelete(locationName);
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
        public void MainCoinDelete()
        {
            var coin = new Coin(); //Lokasyon silmek, o lokasyona tabii coinleri de siliyor. muhtemelen gereksiz kalacak
            string coinName = "ATest";
            coin.CoinDelete(coinName);
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
        public void MainPlaceDelete()
        {
            var place = new Place();
            string placeName = "ATest";
            place.PlaceDelete(placeName);
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
        public void MainInfoDelete()
        {
            var info = new Info();
            string infoName = "ATest";
            info.InfoDelete(infoName);
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
        public void MainPrizeDelete()
        {
            var prize = new Prize();
            string prizeName = "ATest";
            prize.PrizeDelete(prizeName);
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
        public void MainQuestionDelete()
        {
            // Birden çok yanıt - 1 , Çoktan seçmeli - 2 , Boşluk doldurma - 3
            string text = "ATest text";
            var question = new Question();
            question.QuestionDelete(text);
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
        public void MainUserDelete()
        {
            var user = new User();
            string userName = "atest";
            user.UserDelete(userName);
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
