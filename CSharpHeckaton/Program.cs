// See https://aka.ms/new-console-template for more information
using System.Collections;
using System.IO.Pipes;

var iphone14 = new Product()
{
    Id = 1,
    Name = "iPhone14"
};
var iphone15 = new Product()
{
    Id = 2,
    Name = "iPhone 15"
};

var inventoryMashhad = new Inventory();

inventoryMashhad.AddProduct(iphone14);
inventoryMashhad.AddProduct(iphone15);
inventoryMashhad.AddProduct(iphone14);
inventoryMashhad.AddProduct(iphone14);

var inventoryShiraz = new Inventory();

inventoryShiraz.AddProduct(iphone15);
inventoryShiraz.AddProduct(iphone15);
inventoryShiraz.AddProduct(iphone15);
inventoryShiraz.AddProduct(iphone14);

var inventoryTehran = new Inventory();

inventoryTehran.AddProduct(iphone15);
inventoryTehran.AddProduct(iphone15);
inventoryTehran.AddProduct(iphone14);

var resultInventory = inventoryShiraz + inventoryMashhad + inventoryTehran;

foreach (var product in resultInventory.GetProducts())
{
    Console.WriteLine($"Product Id: {product.Id}, Product Name: {product.Name}");
}




class Inventory
{
    List<Product> Products;
    public Inventory()
    {
        Products = new List<Product>();
    }

    public List<Product> GetProducts()
    {
        return Products;
    }

    public void AddProduct(Product product)
    {
        Products.Add(product);
    }

    public int CountOfProduct(int productId)
    {
        return Products.Where(p => p.Id == productId).Count();
    }

    public static Inventory operator + (Inventory a , Inventory b)
    {
        Inventory result = new Inventory();
        foreach (var product in a.Products)
        {
            result.AddProduct(product);
        }
        foreach (var product in b.Products)
        {
            result.AddProduct(product);
        }
        return result;
    }
}

public class Product
{
    public int Id { get; set; }
    public string Name{ get; set; }
}