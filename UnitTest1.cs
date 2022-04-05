using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace NUnitLessonsSharonSefi
{
    [TestFixture]
    public class SauceDemotTest
    {
        ChromeDriver driver;

        [SetUp]
        public void LoadDriver()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        [TearDown]
        public void AnyException()
        {
            try
            {
                driver.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to close driver: " + ex.Message);
                throw new Exception();
            }
        }

        [OneTimeTearDown]
        public void QuitDriver()
        {
            driver.Quit();
        }

        // Login function
        public void LoginProcess()
        {
            var username = driver.FindElement(By.XPath("//input[@id='user-name']"));
            username.SendKeys("standard_user");
            var password = driver.FindElement(By.XPath("//input[@id='password']"));
            password.SendKeys("secret_sauce");
            var loginButton = driver.FindElement(By.XPath("//input[@id='login-button']"));
            loginButton.Click();
        }
    }
}
