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
    public class SharonTest
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

    }
}
