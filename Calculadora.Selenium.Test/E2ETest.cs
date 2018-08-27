using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Configuration;
using OpenQA.Selenium.Support.UI;

namespace Calculadora.Selenium.Test
{
    /// <summary>
    /// Descripción resumida de E2ETest
    /// </summary>
    [TestClass]
    public class E2ETest
    {
        public static IWebDriver Driver;
        private static readonly String base_url = ConfigurationManager.AppSettings["baseUrl"];
        public static WebDriverWait wait;


        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context) {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(base_url);
            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(2));
        }
      

        /// <summary>
        ///Obtiene o establece el contexto de las pruebas que proporciona
        ///información y funcionalidad para la serie de pruebas actual.
        ///</summary>
        [AssemblyCleanup]
        public static void AssemblyTearDown() {
            Driver.Close();
            Driver.Quit();
        }

        [TestMethod]
        public void SeleniumTestUsingCSharp()
        {
            var title = Driver.FindElement(By.Id("title"));

            Func<IWebDriver, bool> waitForTitle = new Func<IWebDriver, bool>((IWebDriver web)) => {
                Assert.AreEqual(title.Text, "Make your calculation here:");
            }

            // Title
            wait.Until(waitForTitle);

            // Sum
            Driver.FindElement(By.Id("field1")).Clear();
            Driver.FindElement(By.Id("field2")).Clear();
            Driver.FindElement(By.Id("result"));

            Driver.FindElement(By.Id("field1")).SendKeys("5");
            Driver.FindElement(By.Id("field2")).SendKeys("3");
            Driver.FindElement(By.Id("sum")).Click();

            string result = "";

            Func<IWebDriver, bool>

            Assert.AreEqual(result.Text, "8");

            // Substraction
            Driver.FindElement(By.Id("field1")).Clear();
            Driver.FindElement(By.Id("field2")).Clear();
            Driver.FindElement(By.Id("result"));

            Driver.FindElement(By.Id("field1")).SendKeys("5");
            Driver.FindElement(By.Id("field2")).SendKeys("3");
            Driver.FindElement(By.Id("substraction")).Click();

            result = Driver.FindElement(By.Id("result"));

            Assert.AreEqual(result.Text, "2");

            // Division
            Driver.FindElement(By.Id("field1")).Clear();
            Driver.FindElement(By.Id("field2")).Clear();
            Driver.FindElement(By.Id("result"));

            Driver.FindElement(By.Id("field1")).SendKeys("6");
            Driver.FindElement(By.Id("field2")).SendKeys("3");
            Driver.FindElement(By.Id("division")).Click();

            Func<IWebDriver, bool> waitForDiv = new Func<IWebDriver, bool>((IWebDriver Web)) => {
                result
            }

            Assert.AreEqual(result.Text, "2");

            // Multiplication
            Driver.FindElement(By.Id("field1")).Clear();
            Driver.FindElement(By.Id("field2")).Clear();
            Driver.FindElement(By.Id("result"));

            Driver.FindElement(By.Id("field1")).SendKeys("5");
            Driver.FindElement(By.Id("field2")).SendKeys("3");
            Driver.FindElement(By.Id("multiplication")).Click();

            result = Driver.FindElement(By.Id("result"));

            Assert.AreEqual(result.Text, "15");

        }
       
    }
}
