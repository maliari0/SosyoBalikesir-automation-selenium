using SelTest1.Areas;

namespace SelTest1
{
    public class UpdateScene
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
        [Test]
        [Order(1)]
        public void MainLocation()
        {
            var loc = new Location();
            loc.LocationPhase();
        }
        [Test]
        [Order(2)]
        public void MainLocationUpdate()
        {
            string locationName = "ATest";
            string newLocName = "ATestUpdated";
            int coinQuantity = 4;
            var loc = new Location();
            loc.LocationUpdate(locationName, newLocName, coinQuantity);
        }
        [Test]
        [Order(3)]
        public void MainCoin()
        {
            var coin = new Coin();
            coin.CoinPhase();
        }
        //[Test]
        //[Order(4)]
        //public void MainCoinUpdate()
        //{
        //    int coinValue = 1;
        //    string type = "coin";
        //    var coin = new Coin();
        //    coin.CoinCreate(type, coinValue);
        //}
        [Test]
        [Order(5)]
        public void MainPlace()
        {
            var place = new Place();
            place.PlacePhase();
        }
        [Test]
        [Order(6)]
        public void MainPlaceUpdate()
        {
            //string title1, string address1, string lat, string lon, string status
            string title = "ATest";
            string titleUpdated = "ATestUpdated";
            string address = "ATest address";
            string addressUpdated = "ATest address Updated";
            float lat = 39.1f;
            float lon = 28.1f;
            string status = "show";
            string statusUpdated = "hide";
            var place = new Place();
            place.PlaceUpdate(title, titleUpdated, addressUpdated, lat, lon, statusUpdated);
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
        public void MainInfoUpdate()
        {
            string body = "ATest";
            string newBody = "ATest Updated";
            int coinValue = 3;
            var info = new Info();
            info.InfoUpdate(body, newBody, coinValue);        
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
        public void MainPrizeUpdate()
        {
            string value = "0";    // 0 - hayır , 1 - evet
            string name = "ATest";
            string newName = "ATestUpdated";
            string desc = "ATest Desc Updated";
            int coinAmount = 12;
            int prizeAmount = 12;
            int claimAmount = 12;
            string status = "1";          // 0 - Alınamaz  ,  1 - Alınabilir
            var prize = new Prize();
            prize.PrizeUpdate(value, name, newName, desc, coinAmount, prizeAmount, claimAmount, status);          
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
        public void MainQuestionUpdate()
        {
            // Birden çok yanıt - 1 , Çoktan seçmeli - 2 , Boşluk doldurma - 3
            string text = "ATest text";
            string newText = "ATest text Updated";
            int type = 1;
            int questionAmount = 4;
            var question = new Question();
            question.QuestionUpdate(text, newText, type, questionAmount);
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
        public void MainUserUpdate()
        {
            var user = new User();
            string type = "dealer";    // dealer = Bayii , admin = Admin
            string name = "ATest";
            string newName = "ATest Updated";
            string userName = "atest";
            string email = "atest@test.com";
            string password = "atest12";
            user.UserUpdate(type, name, newName, userName, email, password);
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
