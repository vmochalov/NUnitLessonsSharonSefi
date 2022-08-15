using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;

namespace NUnitLessonsSharonSefi
{
    [TestFixture]
    public class SharonTest : BaseTest
    {
        
        // driver : set up
        //close driver : tear down 
        
        
        // Test case with valid username and password
        [TestCase ("standard_user", "secret_sauce")]
        public void LogInByUnPassword(string username, string password)
        {
            // Call method
            var loginService = new LoginService();
            loginService.LoginByUserPass(username, password, driver);

            // Assert log in is successful
            string expectedUrl = "https://www.saucedemo.com/inventory.html";
            string actualUrl = driver.Url;
            Assert.That(actualUrl, Is.EqualTo(expectedUrl));
            // What message will appear if pass/fail
        }
    }
}
