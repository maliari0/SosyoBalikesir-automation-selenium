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
        public void MainLocationUpdate()
        {
            string locationName = "ATest";
            string newLocName = "ATestUpdated";
            int coinQuantity = 4;
            var loc = new Location();
            loc.LocationUpdate(locationName, newLocName, coinQuantity);
        }
        [Test]
        [Order(4)]
        public void MainCoin()
        {
            var coin = new Coin();
            coin.CoinPhase();
        }
        //[Test]
        //[Order(5)]
        //public void MainCoinUpdate()
        //{
        //    int coinValue = 1;
        //    string type = "coin";
        //    var coin = new Coin();
        //    coin.CoinCreate(type, coinValue);
        //}
        [Test]
        [Order(6)]
        public void MainPlace()
        {
            var place = new Place();
            place.PlacePhase();
        }
        [Test]
        [Order(7)]
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
        [Order(8)]
        public void MainInfo()
        {
            var info = new Info();
            info.InfoPhase();
        }
        [Test]
        [Order(9)]
        public void MainInfoUpdate()
        {
            string body = "ATest";
            string newBody = "ATest Updated";
            int coinValue = 3;
            var info = new Info();
            info.InfoUpdate(body, newBody, coinValue);        
        }
        //[Test]
        //[Order(8)]
        //public void MainInfo()
        //{
        //    var info = new Info();
        //    info.InfoPhase();
        //}
        //[Test]
        //[Order(9)]
        //public void MainInfoUpdate()
        //{
        //    string body = "ATest";
        //    string newBody = "ATest Updated";
        //    int coinValue = 3;
            //string status = "0";
        //    var info = new Info();
        //    info.InfoUpdate(body, newBody, coinValue);           // 0 - hayır , 1 - evet
        //}
    }
}
