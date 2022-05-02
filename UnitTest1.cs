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

        /////////////////////////////////////////////////////////////////////////
        /////
        ///// Rough draft of TestCaseSource
        ///// ....Not working :(
        ///// 
        /////////////////////////////////////////////////////////////////////////


        //public static IEnumerable<TestCaseData> ItemTestCases
        //{
        //    get
        //    {
        //        // B
        //        //yield return new TestCaseData(new Item
        //        //{
        //        //    itemName = "group",
        //        //    itemDesc = "description",
        //        //    itemPrice = 11.11,
        //        //    itemImage = "dsdwadqdw",
        //        //    hasAddToCart = true
        //        //}).SetName("ThisIsNameOfTest1");

                
        //        //TODO   Fix ) 
        //        TestCaseData testCaseData = new TestCaseData(new Item("Sauce Labs Backpack",
        //            "carry.allTheThings() with the sleek, streamlined Sly Pack that melds uncompromising style with unequaled laptop and tablet protection.",
        //            29.99, "https://www.saucedemo.com/static/media/sauce-backpack-1200x1500.34e7aa42.jpg")).SetName("Test Backpack");
        //        yield return testCaseData;
               
        //    }
        //}


        //[TestCaseSource("ItemTestCases")]

        //[Description("Dynamic group crate tests cases with image compare ")]

        ////////////////////////////////////////////////////////////////////////////


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

        /// <summary>
        /// This is login function
        /// </summary>
        /// <param name="userName">User name</param>
        /// <param name="password">User password</param>
        public void LoginProcess(string userName , string password)
        {
            var userNameField = driver.FindElement(By.XPath("//input[@id='user-name']"));
            userNameField.SendKeys(userName);
            var passwordField = driver.FindElement(By.XPath("//input[@id='password']"));
            passwordField.SendKeys(password);
            var loginButton = driver.FindElement(By.XPath("//input[@id='login-button']"));
            loginButton.Click();
        }

        [TestCase("Sauce Labs Backpack")]
        [TestCase("Sauce Labs Bolt T-Shirt")]
        [TestCase("BullShit that not exist")]
        public void AddItemToCartByName(string item)
        {
            LoginProcess("standard_user", "secret_sauce");
            var itemName = driver.FindElement(By.XPath("//div[normalize-space()='" + item + "']"));
            var itemNameText = itemName.Text.ToLower();
            var itemNameTextWithCart = "add to cart " + itemNameText;
            var itemNameTextWithCartAndDash = itemNameTextWithCart.Replace(" ", "-");
            var addToCartButton = driver.FindElement(By.Id(itemNameTextWithCartAndDash));
            addToCartButton.Click();
            WebDriverWait w = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            var isShoppingCartBadgeExist = driver.FindElement(By.XPath("//span[@class='shopping_cart_badge']")).Displayed;
            Assert.IsTrue(isShoppingCartBadgeExist, "Failed add to cart item: " + item);
        }
    }
}
