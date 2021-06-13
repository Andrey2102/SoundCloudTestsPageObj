using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;
using SoundCloudTestsPageObj.PageObjects;

namespace SoundCloudTestsPageObj
{
    [TestFixture()]
    public class Test
    {

        [Test, Timeout(200000)]
        public void TestSearch()
        {
            IWebDriver webDr = new ChromeDriver();
            WebDriverWait wait = new WebDriverWait(webDr, System.TimeSpan.FromSeconds(300));
            HomePage home = new HomePage(webDr, wait);
            
            home.goToPage();

            home.acceptCookies();

            IWebElement element = null;

            home.search(element, "Master of Pupets");

            wait.Until(wdriver => webDr.FindElement(By.XPath("/html/body/div[1]/div[2]/div[2]/div/div/div[3]/div/div/div/ul/li[1]/div/div")));
            element = webDr.FindElement(By.XPath("/html/body/div[1]/div[2]/div[2]/div/div/div[3]/div/div/div/ul/li[1]/div/div"));

            Assert.True(element.Text.ToUpper().Contains("Master of Pupets".ToUpper()));
            webDr.Close();
        }

        [Test, Timeout(100000)]
        public void TestLogoNavigate()
        {

            IWebDriver webDr = new ChromeDriver();
            WebDriverWait wait = new WebDriverWait(webDr, System.TimeSpan.FromSeconds(300));
            HomePage home = new HomePage(webDr, wait);

            home.goToPage();

            home.acceptCookies();

            IWebElement element = null;

            home.click_logo(element);

            Assert.AreEqual("https://soundcloud.com/", webDr.Url);
            webDr.Close();
        }

        [Test, Timeout(200000)]
        public void TestPlay()
        {


            IWebDriver driver = new ChromeDriver();
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(300));
            TrackPage home = new TrackPage(driver, wait);

            home.goToPage("https://soundcloud.com/user7001700/d0filyv88len");

            home.acceptCookies();

            IWebElement element = null;

            home.play(element);

            Assert.False(home.time_stamp(element) == "0");
            driver.Close();
        }

        [Test, Timeout(150000)]
        public void TestPause()
        {
            IWebDriver driver = new ChromeDriver();
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(3000));
            TrackPage home = new TrackPage(driver, wait);

            home.goToPage("https://soundcloud.com/user7001700/d0filyv88len");

            home.acceptCookies();

            Thread.Sleep(1000);

            IWebElement element = null;

            home.play(element);

            Thread.Sleep(6500);

            home.play(element);

            Thread.Sleep(1000);

            
            Assert.AreEqual(home.time_stamp(element), "6");
            driver.Close();
        }

        [Test, Timeout(200000)]
        public void TestNext()
        {


            IWebDriver driver = new ChromeDriver();
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(300));
            TrackPage home = new TrackPage(driver, wait);

            home.goToPage("https://soundcloud.com/user7001700/d0filyv88len");

            home.acceptCookies();

            IWebElement element = null;

            string currTrackName = home.getTrackName(element);

            home.next(element);

            //Waiting to see changes
            Thread.Sleep(1500);

            string newTrackName = home.getTrackName(element);

            Assert.AreNotEqual(currTrackName, newTrackName);
            driver.Close();
        }
    }
}