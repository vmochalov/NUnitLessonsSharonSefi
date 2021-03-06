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
    
    public class SauceDemotTest : BaseTest
    {

        /// <summary>
        /// This is login function
        /// </summary>
        /// <param name="userName">User name</param>
        /// <param name="password">User password</param>
        
        // TODO: separate areas
        // TODO: rename UnitTest1
        // TODO: new branch with my own structure
        // TODO: new class with objects
        // TODO: open file and read from it


        public static IEnumerable<TestCaseData> ItemsWithDescriptionsAndPrices
        {
            get
            {
                yield return new TestCaseData("Sauce Labs Backpack", "carry.allTheThings() with the sleek, " +
                    "streamlined Sly Pack that melds uncompromising style with unequaled laptop and tablet protection.", 29.99);
                yield return new TestCaseData("Sauce Labs Bolt T-Shirt", "Get your testing superhero on with the Sauce " +
                    "Labs bolt T-shirt. From American Apparel, 100% ringspun combed cotton, heather gray with red bolt.", 15.99);
                yield return new TestCaseData("Sauce Labs Onesie", "Rib snap infant onesie for the junior automation " +
                    "engineer in development. Reinforced 3-snap bottom closure, two-needle hemmed sleeved and bottom won't unravel.", 7.99);
                yield return new TestCaseData("Sauce Labs Bike Light", "A red light isn't the desired state in testing but it sure " +
                    "helps when riding your bike at night. Water-resistant with 3 lighting modes, 1 AAA battery included.", 9.99);
                yield return new TestCaseData("Sauce Labs Fleece Jacket", "It's not every day that you come across a " +
                    "midweight quarter-zip fleece jacket capable of handling everything from a relaxing day outdoors to a busy day at the office.", 49.99);
                yield return new TestCaseData("Some bullshit", "Bullshit description", 52.11);
            }
        }
        [TestCaseSource(nameof(ItemsWithDescriptionsAndPrices))]
        public void AddItemToCartByName(string item, string itemDescription, double itemPrice)
        {
            LoginService LoginService = new LoginService();
            LoginService.LoginProcess("standard_user", "secret_sauce");

            IWebElement itemName;
            try
            {
                itemName = driver.FindElement(By.XPath("//div[normalize-space()='" + item + "']"));
            } // TODO: swallow exception (read about it)
            catch (Exception noItem)
            { // TODO: message to string - exception message clear with all information
                Console.WriteLine("Unable to find item: " + noItem.Message);
                throw new Exception();
            }
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
