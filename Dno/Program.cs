using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
//include webdriver libraries
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Dno
{
    class Program
    {
        static void Main(string[] args)
        {
            //initialize webdriver 
            IWebDriver driver;
            using (driver = new ChromeDriver(@"C:\Selenium\"))
            {
                driver.Navigate().GoToUrl("http://checkenbespaar.nl");
                //wait for element menu Smartphones
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
                IWebElement mainMenu = wait.Until<IWebElement>((d) =>
                {
                    return d.FindElement(By.ClassName("art-menu-btn"));
                });
                Console.WriteLine("Main menu is displayed: " + mainMenu.Displayed.ToString());
                mainMenu.Click();
                //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
                IWebElement menuSmartphones = wait.Until<IWebElement>((d) =>
                {
                    return d.FindElement(By.XPath("//a[@title='Smartphones']"));
                });
                
                Console.WriteLine("menuSmartphones is displayed: " + menuSmartphones.Displayed.ToString());
                menuSmartphones.Click();
                //wait for 500 ms
                Thread.Sleep(500);
                
                //check if we are moved to correct URL
                Console.WriteLine("Current url: " + driver.Url);
                
                //set filers
                setFilters(driver);
                
            }
            //close driver and flush memory
            driver.Dispose();
            driver.Quit();
            
            Console.ReadKey();
            

        }

        public static void setFilters(IWebDriver driver_)
        {
            WebDriverWait wait = new WebDriverWait(driver_, TimeSpan.FromSeconds(15));
            IWebElement providerFilter = wait.Until<IWebElement>((d) =>
            {
                return d.FindElement(By.ClassName("daisyconProvider"));
            });
            SelectElement providerFilterList = new SelectElement(providerFilter);
            providerFilterList.SelectByIndex(1);
            //providerFilter.Click();
            Thread.Sleep(8000);
            //return true;
            //new Select(driver.findElement(By.id("gender"))).selectByVisibleText("Germany");
        }
    }
}
