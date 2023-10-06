using NUnit.Framework;

using OpenQA.Selenium;

using OpenQA.Selenium.Chrome;

using OpenQA.Selenium.Firefox;

using System;

using System.Collections.ObjectModel;

using System.IO;

using NUnit.Framework;

using OpenQA.Selenium.Support.UI;
using SelTest1.drivers;

namespace SelTest1.Areas
{
    internal class Question
    {
        IWebDriver driver = WebDriverManager.GetDriver();
        public void QuestionPhase()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.Navigate().GoToUrl("https://sosyobalikesir.com/panel/question");
            //driver.FindElement(By.CssSelector("i[class=\"nav-icon fas fa-question-circle\"]")).Click();
            //System.Threading.Thread.Sleep(2000); bu kod parçacığı işlemi de wait processine sokuyor. implicitWait kullan
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        }
        public void QuestionCreate(string qText, int coinValue, int type, int questionAmount)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.FindElement(By.CssSelector("i[class=\"fa fa-plus\"]")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            driver.FindElement(By.Name("question_text")).SendKeys(qText);

            var typeSelect = driver.FindElement(By.Name("question_type"));
            var typeSelectElement = new SelectElement(typeSelect);
            typeSelectElement.SelectByIndex(type);
            // Birden çok yanıt - 1 , Çoktan seçmeli - 2 , Boşluk doldurma - 3

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            

            if (type == 1) 
            {
                for (int i = 1; i <= questionAmount; i++)
                {
                    //IWebElement ans = driver.FindElement(By.CssSelector("body > div:nth-child(1) > div:nth-child(3) > section:nth-child(2) > div:nth-child(1) > div:nth-child(1) > div:nth-child(1) > div:nth-child(2) > form:nth-child(2) > div:nth-child(1) > div:nth-child(3) > div:nth-child(2) > div:nth-child(1) > input:nth-child(2)"));
                    //ans.SendKeys("Answer");
                    //driver.FindElement(By.CssSelector("i[class=\"fa fa-plus\"]")).Click();
                    //IWebElement ans = driver.FindElement(By.XPath($"//body/div[@class='wrapper']/div[@class='content-wrapper']/section[@class='content']/div[@class='container-fluid']/div[@class='row']/div[@class='col-12']/div[@class='card card-primary']/form[@id='questionForm']/div[@class='card-body']/div[@class='form-group answerBox']/div[@class='answerContainer']/div[1]/input[1]\"])[{i}]"));
                    ////ans.Click();
                    ///
                    driver.FindElement(By.CssSelector("div.answerContainer div:nth-child(" + i + ") input[type='text']")).SendKeys("Cevap " + i);
                    driver.FindElement(By.CssSelector("i[class=\"fa fa-plus\"]")).Click();

                }
                for (int i = questionAmount+1; i >= questionAmount+1; i--)
                {
                    var key = ("Cevap " + (i));
                    driver.FindElement(By.CssSelector("div.answerContainer div:nth-child(" + i + ") input[type='text']")).SendKeys(key);
                    IWebElement correctAnswerCheckbox = driver.FindElement(By.Name("is_correct")); // Örnek bir ID kullanıldı
                    correctAnswerCheckbox.Click();

                    //var radioButton = driver.FindElement(By.CssSelector($"input[name='is_correct'][value='{key}']"));
                    //((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].setAttribute('checked', 'true')", radioButton);


                }

                //driver.FindElement(By.XPath("//button[text()='Sil']"))
                //(//input[@name="question_answer[]"])[3]
                //for(int i=0; i< questionAmount-1; i++)
                //{
                //    driver.FindElement(By.CssSelector("i[class=\"fa fa-plus\"]")).Click();
                //    driver.FindElement(By.Name($"question_answer[]")).SendKeys("Answer "+i);
                //}
            }
            else { }  //doldurulacak diğer soru tipleri için
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            IWebElement button = driver.FindElement(By.CssSelector("button[type='submit']"));

            // Butona tıklayın
            button.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        }
        public void QuestionDelete(string name)
        {
            //IWebElement table = driver.FindElement(By.XPath($"//table/tbody/tr[td[text()='{name}']]"));
            ////tbody/tr[1]/td[1]
            //IWebElement deleteButton = table.FindElement(By.CssSelector("form.deleteForm button.btn-danger"));
            //deleteButton.Click();
            bool x = true;
            do
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
                driver.Navigate().GoToUrl("https://sosyobalikesir.com/panel/question");
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
                driver.FindElement(By.CssSelector("input[type='search']")).SendKeys(name);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
                try
                {
                    var rows = driver.FindElements(By.XPath($"//table[@id='{name}']/tbody/tr"));
                    foreach (var row in rows)
                    {
                        var cells = row.FindElements(By.TagName("td"));
                        if (cells[1].Text.Contains(name))
                        {
                            var deleteButton = row.FindElement(By.CssSelector("button.btn-danger"));
                            deleteButton.Click();
                        }
                    }
                    string mainWindowHandle = driver.CurrentWindowHandle; // Ana pencerenin işaretçisini alın
                    foreach (string handle in driver.WindowHandles)
                    {
                        if (handle != mainWindowHandle)
                        {
                            driver.SwitchTo().Window(handle); // Pop-up penceresine geçiş yapın
                            break;
                        }
                    }
                    // Pop-up penceresindeki 'Evet' butonuna tıklayın
                    IWebElement yesButton = driver.FindElement(By.XPath("//button[text()='Sil']"));
                    yesButton.Click();

                    IWebElement okButton = driver.FindElement(By.XPath("//button[text()='OK']"));
                    okButton.Click();
                }
                catch (NoSuchElementException)
                {
                    break;
                }
            } while (x == true);

            
        }
    }
}
