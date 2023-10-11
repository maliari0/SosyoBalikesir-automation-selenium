namespace SosyoBalikesirTesting.drivers
{
    public class WebDriverManager
    {
        private static IWebDriver driver;

        public static IWebDriver GetDriver()
        {
            if (driver == null)
            {
                driver = new ChromeDriver();
            }
            return driver;
        }
    }
}
