using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;

// Plan is to only have the actual login function. Chrome driver initialization should not be here?

namespace NUnitLessonsSharonSefi{
    public class LoginService
    {
        // Log in method
        public void LoginByUserPass(string userName, string password, ChromeDriver driver) 
        {
            
            // navigate to website
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");

            // insert values
            var userNameField = driver.FindElement(By.XPath("//input[@id='user-name']"));
            userNameField.SendKeys(userName);
            var passwordField = driver.FindElement(By.XPath("//input[@id='password']"));
            passwordField.SendKeys(password);
            var loginButton = driver.FindElement(By.XPath("//input[@id='login-button']"));
            
            
            // click login
            loginButton.Click();
        }





    }
}
