using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;
using System.Collections.Generic;
using OpenQA.Selenium.Support.PageObjects;

namespace SoundCloudTestsPageObj.PageObjects
{
    class TrackPage
    {
        private IWebDriver driver;
        WebDriverWait wait;

        public TrackPage(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        public void goToPage(string page_address)
        {
            driver.Navigate().GoToUrl(page_address);
        }

        public void acceptCookies()
        {
            wait.Until(wdriver => driver.FindElement(By.XPath("/html/body/div[3]/div[3]/div/div[1]/div/div[2]/div/button[2]")));
            IWebElement element = driver.FindElement(By.XPath("/html/body/div[3]/div[3]/div/div[1]/div/div[2]/div/button[2]"));
            element.Click();
        }

        public void play(IWebElement element)
        {
            wait.Until(wdriver => driver.FindElement(By.ClassName("snippetUXPlayButton")));
            element = driver.FindElement(By.ClassName("snippetUXPlayButton"));

            element.Click();
        }

        public string time_stamp(IWebElement element)
        {
            wait.Until(wdriver => driver.FindElement(By.ClassName("playbackTimeline__progressWrapper")));
            element = driver.FindElement(By.ClassName("playbackTimeline__progressWrapper"));

            Thread.Sleep(6500);
            return element.GetAttribute("aria-valuenow");
        }

        public string getTrackName(IWebElement element)
        {
            wait.Until(wdriver => driver.FindElement(By.ClassName("playbackSoundBadge__titleLink")));
            element = driver.FindElement(By.ClassName("playbackSoundBadge__titleLink"));
            return element.Text;
        }

        public void next(IWebElement element)
        {
            //Button next
            wait.Until(wdriver => driver.FindElement(By.XPath("/html/body/div[1]/div[4]/section/div/div[3]/button[3]")));
            element = driver.FindElement(By.XPath("/html/body/div[1]/div[4]/section/div/div[3]/button[3]"));

            //To load next track
            element.Click();
        }
    }
}
