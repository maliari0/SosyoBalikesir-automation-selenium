using SosyoBalikesirTesting.drivers;
using System.Diagnostics;

namespace SosyoBalikesirTesting.Areas
{
    public class Question
    {
        IWebDriver driver = WebDriverManager.GetDriver();
        public void QuestionPhase()
        {
            Thread.Sleep(1000);
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            driver.Navigate().GoToUrl("https://www.sosyobalikesir.com/panel/question");
            //driver.FindElement(By.CssSelector("i[class=\"nav-icon fas fa-question-circle\"]")).Click();
            //System.Threading.Thread.Sleep(2000); bu kod parçacığı işlemi de wait processine sokuyor. implicitWait kullan
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        }
        public void QuestionCreate(string qText, int coinValue, int type, int questionAmount)
        {
            Thread.Sleep(1000);
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
        public int CountPlus(int x)
        {
            x++; return x ;
        }
        int c = 0;

        public void QuestionDelete(string name)
        {
            //IWebElement table = driver.FindElement(By.XPath($"//table/tbody/tr[td[text()='{name}']]"));
            ////tbody/tr[1]/td[1]
            //IWebElement deleteButton = table.FindElement(By.CssSelector("form.deleteForm button.btn-danger"));
            //deleteButton.Click();
            bool x = true;
            do
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
                driver.Navigate().GoToUrl("https://www.sosyobalikesir.com/panel/question");
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
                driver.FindElement(By.CssSelector("input[type='search']")).SendKeys(name);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
                try
                {
                    
                    IWebElement table = driver.FindElement(By.XPath($"//table/tbody/tr[td[text()='{name}']]"));
                    //tbody/tr[1]/td[1]
                    IWebElement deleteButton = table.FindElement(By.CssSelector("form.deleteForm button.btn-danger"));
                    deleteButton.Click();
                    string mainWindowHandle = driver.CurrentWindowHandle; // Ana pencerenin işaretçisini alın
                    foreach (string handle in driver.WindowHandles)
                    {
                        if (handle != mainWindowHandle)
                        {
                            driver.SwitchTo().Window(handle); // Pop-up penceresine geçiş yapın
                            break;
                        }
                    }
                    c++;

                    // Pop-up penceresindeki 'Evet' butonuna tıklayın
                    IWebElement yesButton = driver.FindElement(By.XPath("//button[text()='Sil']"));
                    yesButton.Click();

                    IWebElement okButton = driver.FindElement(By.XPath("//button[text()='OK']"));
                    okButton.Click();
                }
                catch (NoSuchElementException)
                {
                    
                    if(c == 0)
                    {
                        Assert.IsTrue(IsQuestionDeleteSuccessfully(), $"{name} isimli soru bulunamadı. ");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"{c} adet soru silindi.");
                        Debug.WriteLine($"{c} adet soru silindi.");
                        break;
                    }
                }
            } while (x == true);
        }
        private bool IsQuestionDeleteSuccessfully()
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
        public void QuestionUpdate(string qText, string newQText, int type, int questionAmount)
        {
            Thread.Sleep(500);
            driver.Navigate().GoToUrl("https://www.sosyobalikesir.com/panel/question");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            driver.FindElement(By.CssSelector("input[type='search']")).SendKeys(qText);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            try
            {
                IWebElement table = driver.FindElement(By.XPath($"//table/tbody/tr[td[text()='{qText}']]"));
                //tbody/tr[1]/td[1]
                IWebElement updateButton = table.FindElement(By.CssSelector("i[class=\"fa fa-edit\"]"));
                updateButton.Click();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

                IWebElement newTitleElement = driver.FindElement(By.Name("question_text"));
                newTitleElement.Clear();
                newTitleElement.SendKeys(newQText);


                
                // Birden çok yanıt - 1 , Çoktan seçmeli - 2 , Boşluk doldurma - 3
                var typeSelect2 = driver.FindElement(By.Name("question_type"));
                var typeSelectElement2 = new SelectElement(typeSelect2);
                typeSelectElement2.SelectByIndex(type);

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
                if (type == 1)
                {
                    for (int i = 1; i <= questionAmount+1; i++)
                    {
                        IWebElement answerBoxesElement = driver.FindElement(By.CssSelector("div.answerContainer div:nth-child(" + i + ") input[type='text']"));
                        answerBoxesElement.Clear();
                        answerBoxesElement.SendKeys("Updated Answer is " + i);
                        //driver.FindElement(By.CssSelector("i[class=\"fa fa-plus\"]")).Click();
                    }
                    for (int i = questionAmount + 1; i >= questionAmount + 1; i--)
                    {
                        //var key = ("Cevap " + (i));
                        //IWebElement answerBoxesSelectElement = driver.FindElement(By.CssSelector("div.answerContainer div:nth-child(" + i + ") input[type='text']"));
                        //answerBoxesSelectElement.Clear();
                        //answerBoxesSelectElement.SendKeys(key);
                        IWebElement correctAnswerCheckbox = driver.FindElement(By.Name("is_correct"));
                        correctAnswerCheckbox.Click();
                    }
                }
                else { }  //doldurulacak diğer soru tipleri için
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

                IWebElement button = driver.FindElement(By.CssSelector("button[type='submit']"));
                button.Click();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            }
            catch (NoSuchElementException)
            {
                Assert.IsTrue(IsQuestionUpdatedSuccessfully(), $"Soru güncelleme başarısız: Bu isimde bir soru bulunamadı: {qText}");
            }


        }
        private bool IsQuestionUpdatedSuccessfully()
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
