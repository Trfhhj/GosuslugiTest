using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace GosuslugiTest
{
    public class Tests
    {
        private IWebDriver driver;

        private readonly By _signInButton = By.XPath("//button[text() = 'Войти']");
        private readonly By _loginTroubleButton = By.XPath("//button[contains(text(), 'Не удаётся войти?')]");
        private readonly By _passwordRecoveryButton = By.XPath("//button[contains(text(), 'восстановления пароля')]");

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.gosuslugi.ru/");
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1()
        {
            ClickAndWait(_signInButton);
            ClickAndWait(_loginTroubleButton);
            ClickAndWait(_passwordRecoveryButton);
        }
        private void ClickAndWait(By locator)
        {
            var element = WaitUntilElementIsClickable(locator);
            element.Click();
        }

        private IWebElement WaitUntilElementIsClickable(By locator)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            return wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

       
    }
}
