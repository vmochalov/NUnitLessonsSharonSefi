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

        ///////////////////////////////////////////////////////////////////////
        ///
        /// Rough draft of TestCaseSource
        /// ....Not working :(
        /// 
        ///////////////////////////////////////////////////////////////////////


        public static IEnumerable<TestCaseData> ItemTestCases
        {
            get
            {
                // B
                //yield return new TestCaseData(new Item
                //{
                //    itemName = "group",
                //    itemDesc = "description",
                //    itemPrice = 11.11,
                //    itemImage = "dsdwadqdw",
                //    hasAddToCart = true
                //}).SetName("ThisIsNameOfTest1");

                TestCaseData testCaseData = new TestCaseData(new Item("Sauce Labs Backpack", "carry.allTheThings() with the sleek, streamlined Sly Pack that melds uncompromising style with unequaled laptop and tablet protection.", 29.99, "https://www.saucedemo.com/static/media/sauce-backpack-1200x1500.34e7aa42.jpg").SetName("Test Backpack");
                yield return testCaseData;
               
            }
        }


        [TestCaseSource("ItemTestCases")]

        [Description("Dynamic group crate tests cases with image compare ")]

        //////////////////////////////////////////////////////////////////////////


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
