using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Alura.ByteBank.WebApp.Testes;
public class NavegandoNaPaginaHome
{
    private IWebDriver driver;
    public NavegandoNaPaginaHome()
    {
        driver = new ChromeDriver(Path.GetDirectoryName(
            Assembly.GetExecutingAssembly().Location));
    }

    [Fact]
    public void CarregaPaginaHomeEVerificaTituloDaPagina()
    {
        //arrange
        IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        //act
        driver.Navigate().GoToUrl("https://localhost:44309");
        //assert
        Assert.Contains("WebApp", driver.Title);
    }

    [Fact] 
    public void CarregaPaginaHomeEVerificaSeExisteOLinkLoginEHome()
    {
        //arrange
        IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        //act
        driver.Navigate().GoToUrl("https://localhost:44309");
        //assert
        Assert.Contains("Login", driver.PageSource);
        Assert.Contains("Home", driver.PageSource);

    }

    [Fact]
    public void ValidaLinKDeLoginNaHome()
    {
        driver.Navigate().GoToUrl("https://localhost:44309/");
        var linkLogin = driver.FindElement(By.LinkText("Login"));

        //Act
        linkLogin.Click();

        //Assert
        Assert.Contains("img", driver.PageSource);
    }

    [Fact]
    public void TentaAcessarPaginaSemEstarLogado()
    {
        //Arrange
        //Act    
        driver.Navigate().GoToUrl("https://localhost:44309/Agencia/Index");

        //Assert
        Assert.Contains("401", driver.PageSource);
    }

    [Fact]
    public void AcessaPaginaSemEstarLogadoVerificaURL()
    {
        //Arrange
        //Act
        driver.Navigate().GoToUrl("https://localhost:44309/Agencia/Index");

        //Assert
        Assert.Contains("https://localhost:44309/Agencia/Index", driver.Url);
        Assert.Contains("401", driver.PageSource);
    }
}
