using SosyoBalikesirTesting.Areas;

namespace SosyoBalikesirTesting
{
    public class TestMailsCollapse
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
        public void MainUser()
        {
            var user = new User();
            user.UserPhase();
        }
        [Test]
        [Order(2)]
        public void GmailDelete()
        {
            var user = new User();
            string userName = "atestgmail";
            user.UserDelete(userName);
            Thread.Sleep(100);
        }
        [Test]
        [Order(3)]
        public void HotmailDelete()
        {
            var user = new User();
            string userName = "atesthotmail";
            user.UserDelete(userName);
            Thread.Sleep(100);
        }
        [Test]
        [Order(4)]
        public void OutlookDelete()
        {
            var user = new User();
            string userName = "atestoutlook";
            user.UserDelete(userName);
            Thread.Sleep(100);
        }
        [Test]
        [Order(5)]
        public void YahooDelete()
        {
            var user = new User();
            string userName = "atestyahoo";
            user.UserDelete(userName);
            Thread.Sleep(100);
        }
        [Test]
        [Order(6)]
        public void YandexDelete()
        {
            var user = new User();
            string userName = "atestyandex";
            user.UserDelete(userName);
            Thread.Sleep(100);
        }
        [Test]
        [Order(7)]
        public void ProtonDelete()
        {
            var user = new User();
            string userName = "atestproton";
            user.UserDelete(userName);
            Thread.Sleep(100);
        }
        [Test]
        [Order(8)]
        public void IcloudDelete()
        {
            var user = new User();
            string userName = "atesticloud";
            user.UserDelete(userName);
            Thread.Sleep(100);
        }
        [Test]
        [Order(9)]
        public void TempDelete()
        {
            var user = new User();
            string userName = "atesttemp";
            user.UserDelete(userName);
            Thread.Sleep(100);
        }
        [Test]
        [Order(10)]
        public void MainLogout()
        {
            var logout = new Logout();
            logout.LogoutPhase();
        }
    }
}
