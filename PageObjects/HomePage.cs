using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;
using System.Collections.Generic;

namespace SoundCloudTestsPageObj.PageObjects
{
    class HomePage
    {
        private IWebDriver driver;
        WebDriverWait wait;
        
        public HomePage(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        public void goToPage()
        {
            driver.Navigate().GoToUrl("https://soundcloud.com/discover");
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
        public void search(IWebElement element, string search_string)
        {
            wait.Until(wdriver => driver.FindElement(By.XPath("/html/body/div[3]/div[3]/div/div[1]/div/div[2]/div/button[2]")));
            element = driver.FindElement(By.XPath("/html/body/div[3]/div[3]/div/div[1]/div/div[2]/div/button[2]"));
            element.Click();

            wait.Until(wdriver => driver.FindElement(By.ClassName("headerSearch__input")));
            element = driver.FindElement(By.ClassName("headerSearch__input"));

            element.SendKeys(search_string);
            element.Submit();
        }

        public void click_logo(IWebElement element)
        {
            wait.Until(wdriver => driver.FindElement(By.ClassName("header__logoLink")));
            element = driver.FindElement(By.ClassName("header__logoLink"));
            element.Click();
        }
    }
}
