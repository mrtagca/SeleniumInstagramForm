using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeleniumInstagramForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IWebDriver driver = new ChromeDriver(); //Google Chrome’un açılması için yapıyoruz. Aynı zamanda driver diye nesne tanımlamış olduk. Bu nesne üzerinden işlemleri yapacağız.
            driver.Navigate().GoToUrl("https://www.instagram.com/accounts/login/?next=%2Flogin%2F&source=desktop_nav");//Bu driver nesnesi ile gitmek istediğimiz sayfayı göstereceğiz.

            Thread.Sleep(1000);
            driver.FindElement(By.Name("username")).SendKeys("meertagca"); //Thread.Sleep(2000);
            driver.FindElement(By.Name("password")).SendKeys("636358Ma"); //Thread.Sleep(2000);
            driver.FindElement(By.XPath("//button[@class='sqdOP  L3NKy   y3zKF     ']")).Click();
            Console.WriteLine("Yazdığım yazı ekrana geldi."); //İşlem gerçekleşirse oluşacak çıktıyı buraya yazıyoruz.
            //driver.Quit(); //Açtığımız Google Chrome’u kapattık ve test işlemini sona erdirdik.

            //test
            Thread.Sleep(3500);
            driver.Navigate().GoToUrl("https://www.instagram.com/explore/tags/computerprogramming/"); Thread.Sleep(1000);


            List<ReadOnlyCollection<IWebElement>> webElementList = new List<ReadOnlyCollection<IWebElement>>();

            //for (int i = 0; i < 10; i++)
            //{
                ReadOnlyCollection<IWebElement>  webElements = driver.FindElements(By.XPath("//div[@class='Nnq7C weEfm']//a"));
                webElementList.Add(webElements);

                
                ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight)"); Thread.Sleep(2500);
            //}

            List<ReadOnlyCollection<IWebElement>> webElementList2 = webElementList.Distinct().ToList(); 

            Thread.Sleep(10000);
            //Nnq7C weEfm

            foreach (var div in webElementList)
            {
                foreach (var button in div)
                {
                    button.Click(); Thread.Sleep(2000);
                    driver.FindElement(By.XPath("//span[@class='fr66n']//button")).Click(); Thread.Sleep(2000); //like button
                    driver.FindElement(By.XPath("//div[@class='                    Igw0E     IwRSH      eGOV_         _4EzTm                                                                                  BI4qX            qJPeX            fm1AK   TxciK yiMZG']//button[@class='wpO6b ']")).Click(); //exit button

                }

            }





            //for (int i = 0; i < webElements.Distinct().ToList().Count - 1; i++)
            //{
            //    webElements[i].Click(); Thread.Sleep(2000);

            //    driver.FindElement(By.XPath("//span[@class='fr66n']//button")).Click(); Thread.Sleep(2000);

            //    driver.FindElement(By.XPath("//div[@class='                    Igw0E     IwRSH      eGOV_         _4EzTm                                                                                  BI4qX            qJPeX            fm1AK   TxciK yiMZG']//button[@class='wpO6b ']")).Click();

            //}

        }
    }
}
