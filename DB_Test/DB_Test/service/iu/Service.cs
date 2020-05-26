using DB_Test.business_object;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DB_Test.service.iu
{
    public class Service
    {
        
        public static EditPage EditPage (Product product, IWebDriver driver, WebDriverWait wait)
        {
            MainPage mainPage = new MainPage(driver, wait);
            AllProductsPage allProductsPage = mainPage.AllProductsLink();
            return allProductsPage.ClickOn(product.ProductName);
        }    

        public static AllProductsPage CreateNew (Product product, IWebDriver driver, WebDriverWait wait)
        {
            MainPage mainPage = new MainPage(driver, wait);
            AllProductsPage allProductsPage = mainPage.AllProductsLink();
            EditPage editPage = allProductsPage.ClickOn("Create new");
            editPage.Select("ProductName", product.ProductName);
            editPage.ToDropDown("CategoryId", product.CategoryId);
            editPage.ToDropDown("SupplierId", product.SupplierId);
            editPage.Select("UnitPrice", product.UnitPriceToInput);
            editPage.Select("QuantityPerUnit", product.QuantityPerUnit);
            editPage.Select("UnitsInStock", product.UnitsInStock);
            editPage.Select("UnitsOnOrder", product.UnitsOnOrder);
            editPage.Select("ReorderLevel", product.ReorderLevel);
            editPage.DiscontinuedCheck();
            return editPage.Submit();
        }
        public static AllProductsPage DeletePage (Product product, IWebDriver driver, WebDriverWait wait)
        {
            MainPage mainPage = new MainPage(driver, wait);
            AllProductsPage allProductsPage = mainPage.AllProductsLink();
            allProductsPage.RemoveProduct(product.ProductName);
            return new AllProductsPage(driver, wait);
        }


    }
}
