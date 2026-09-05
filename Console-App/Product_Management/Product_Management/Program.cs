using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ProductManagement
{
    // User class to store user information (for login)
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }

        // A static list to store predefined users
        public static List<User> Users = new List<User>
        {
            new User { Username = "admin", Password = "admin123" },
            new User { Username = "manager", Password = "manager123" }
        };

        // Method to login
        public static bool LoginUser(string username, string password)
        {
            var user = Users.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user != null)
            {
                Thread.Sleep(1000);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\t\t\t\t\t\t\t\t     Login successful.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n\t\t\t\t\t\t\t\tPress any key to continue...");
                Console.ReadKey();
                return true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\t\t\t\t\t\t\t\tInvalid username or password.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n\t\t\t\t\t\t\t\tPress any key to try again...");
                Console.ReadKey();
                return false;
            }


        }
}

    // Base class: Product
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int StockQuantity { get; set; }

        public string Brand { get; set; }

        // A static list to store all products
        public static List<Product> Products = new List<Product>();

        // Method to add a product
        public static void AddProduct(int productId, string name, double price, int stockQuantity, string brand)
        {
            Products.Add(new Product { ProductId = productId, Name = name, Price = price, StockQuantity = stockQuantity, Brand = brand });
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\t\t\t\t\t\t\t\tProduct added successfully.");

        }

        // Method to display all products
        public static void DisplayProducts()
        {
            if (Products.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\t\t\t\t\t\t\t\tNo products available.");

            }
            else
            {
                foreach (var product in Products)
                {

                    Console.WriteLine($"\t\t\t\t\t\t\t\t{product.ProductId} \t{product.Name} \t{product.Price}\t{product.StockQuantity}\t{product.Brand}");
                }
            }
        }

        // Method to update a product
        public static void UpdateProduct(int productId, string newName, double newPrice, int newStockQuantity, string newBrand)
        {
            var product = Products.Find(p => p.ProductId == productId);
            if (product != null)
            {
                product.Name = newName;
                product.Price = newPrice;
                product.StockQuantity = newStockQuantity;
                product.Brand = newBrand;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\t\t\t\t\t\t\t\tProduct updated successfully.");

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\t\t\t\t\t\t\t\tProduct not found.");
            }
        }

        // Method to delete a product
        public static void DeleteProduct(int productId)
        {
            var product = Products.Find(p => p.ProductId == productId);
            if (product != null)
            {
                Products.Remove(product);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\t\t\t\t\t\t\t\tProduct deleted successfully.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\t\t\t\t\t\t\t\tProduct not found.");
            }
        }

        // Method to search a product by name
        public static void SearchProduct(string name)
        {
            var product = Products.Find(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (product != null)
            {
                Console.WriteLine("\t\t\t\t\t---------------------------------------------------------------------------");
                Console.WriteLine("\t\t\t\t\t\t" + "ID" + "\t" + "Name" + "\t\t" + "Price" + "\t\t" + "Quantity" + "\t" + "Brand");
                Console.WriteLine("\t\t\t\t\t---------------------------------------------------------------------------");
                Console.WriteLine("\t\t\t\t\t\t" + product.ProductId + "\t" + product.Name + "\t" + product.Price + "\t\t" + product.StockQuantity + "\t\t" + product.Brand);
                Console.WriteLine("\t\t\t\t\t---------------------------------------------------------------------------");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\t\t\t\t\t\t\t\tProduct not found.");

            }
        }

       
    }

    // Subclass: Sale (Inherits Product)
    public class Sale : Product
    {
        public int SaleId { get; set; }
        public int ProductId { get; set; }
        public string ClientName { get; set; }
        public int QuantitySold { get; set; }
        public DateTime SaleDate { get; set; }

        // A static list to store all sales
        public static List<Sale> Sales = new List<Sale>();

        // Method to create a sale record
        public static void CreateSale(int saleId, int productId, string clientName, int quantitySold)
        {
            var product = Products.Find(p => p.ProductId == productId);
            if (product != null && product.StockQuantity >= quantitySold)
            {
                Sales.Add(new Sale { SaleId = saleId, ProductId = productId, ClientName = clientName, QuantitySold = quantitySold, SaleDate = DateTime.Now });
                product.StockQuantity -= quantitySold;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\t\t\t\t\t\t\t\tSale recorded successfully.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\t\t\t\t\t\tSale cannot be completed. Check stock or product availability.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        // Method to display all sales
        public static void DisplaySales()
        {
            if (Sales.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\t\t\t\t\t\t\t\tNo sales records available.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                foreach (var sale in Sales)
                {
                    var product = Products.Find(p => p.ProductId == sale.ProductId);
                    Console.WriteLine("\t\t\t\t---------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("\t\t\t\t" + "Sale Id" + "\t\t" + "Client Name" + "\t" + "Product" + "\t\t" + "Quantity" + "\t" + "Date and Time" + "\t\t" + "Total Price");
                    Console.WriteLine("\t\t\t\t---------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("\t\t\t\t" + sale.SaleId + "\t\t" + sale.ClientName + "\t\t" + product.Name + "\t" + sale.QuantitySold + "\t\t" + sale.SaleDate + "\t" + sale.QuantitySold * product.Price);
                    Console.WriteLine("\t\t\t\t---------------------------------------------------------------------------------------------------------");
                }
            }
        }
    }

   internal class Program
    {
       

        static void Main(string[] args)
        {

            Console.WriteLine("\t\t*----*------*-------*-------*---------*--------*--------*--------*--------*--------*--------*--------*--------*--------*");
            Console.WriteLine("\t\t*                                                                                                                      *");

            Console.WriteLine("\t\t*                              >>>>>>>  * KAMADGIRI SOFTWARE SOLUTIONS *  <<<<<<<<                                     *");
            Console.WriteLine("\t\t|                                           ------*------*-----*------                                                 |");
            Console.WriteLine("\t\t*                                                                                                                      *");
            Console.WriteLine("\t\t*                                                                                                                      *");
            Console.WriteLine("\t\t|                                       *Project Name:- PRODUCT MANAGEMENT SYSTEM.                                     |");
            Console.WriteLine("\t\t*                                                                                                                      *");
            Console.WriteLine("\t\t|                                                                                                                      |");
            Console.WriteLine("\t\t*                                                                                                                      *");
            Console.WriteLine("\t\t|\tDate:-                                                                                                         |");
            Console.WriteLine("\t\t*\tSUBMITTED BY:                                                           Submitted To:-  Satyam Sr.             *");
            Console.WriteLine("\t\t*\t--*---*---*--                                                           ----*----*--    ---*--*---             |");
            Console.WriteLine("\t\t*                                                                                                                      *");
            Console.WriteLine("\t\t*\t1.Poonam Pal-Team Leader.                                                                                      *");
            Console.WriteLine("\t\t|\t2.Maanvi                                         |");
            Console.WriteLine("\t\t*\t3.Suman                                          *");
            Console.WriteLine("\t\t|\t4.Anjali                                         |");
            Console.WriteLine("\t\t*\t5.Vandana                                        *");
            Console.WriteLine("\t\t|\t6.Sadhna                                         |");
            Console.WriteLine("\t\t*                                                                                                                      *");
            Console.WriteLine("\t\t*-----*--------*--------*---------*--------*--------*--------*--------*--------*--------*--------*--------*------*-----*\n\n");



            // Login process
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\t\t\t\t\t\t\t>>>>>>* Login Here *<<<<<<");
            Console.ForegroundColor = ConsoleColor.White;
            bool loggedIn = false;
            while (!loggedIn)
            {
                Console.Write("\n\t\t\t\t\t\t\t\t Enter Username: ");
                string username = Console.ReadLine();
                Console.Write("\t\t\t\t\t\t\t\t Enter Password: ");
                string password = Console.ReadLine();

                loggedIn = User.LoginUser(username, password);
            }

            // Adding sample products
            Console.Write("\t\t\t\t\t\t");
            Product.AddProduct(156, "Laptop    ", 1500, 20, "HP");
            Product.AddProduct(210, "Mouse     ", 1000, 30, "Dell");
            Product.AddProduct(109, "Adapter   ", 1000, 50, "Oppo");
            Product.AddProduct(112, "Android   ", 1000, 10, "Samsung");
            Product.AddProduct(199, "Bluetooth ", 1000, 05, "Boat");
            Product.AddProduct(921, "CPU       ", 1000, 09, "ASUS");
            Product.AddProduct(321, "Charger   ", 1000, 25, "Realme");

            // Menu for user interaction
            while (true)
            {

                
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t\t\t\t\t\t\t\t----------------***------------------");
                Console.WriteLine("\t\t\t\t\t\t\t\t\tProduct Management System");
                Console.WriteLine("\t\t\t\t\t\t\t\t----------------***------------------");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n\t\t\t\t\t\t\t\t|-----------------------------------|");
                Console.WriteLine("\t\t\t\t\t\t\t\t*\t1. Display All Products\t    *");
                Console.WriteLine("\t\t\t\t\t\t\t\t|-----------------------------------|");
                Console.WriteLine("\t\t\t\t\t\t\t\t*\t2. Add a New Product\t    *");
                Console.WriteLine("\t\t\t\t\t\t\t\t|-----------------------------------|");
                Console.WriteLine("\t\t\t\t\t\t\t\t*\t3. Update Product\t    *");
                Console.WriteLine("\t\t\t\t\t\t\t\t|-----------------------------------|");
                Console.WriteLine("\t\t\t\t\t\t\t\t*\t4. Delete Product\t    *");
                Console.WriteLine("\t\t\t\t\t\t\t\t|-----------------------------------|");
                Console.WriteLine("\t\t\t\t\t\t\t\t*\t5. Search Product\t    *");
                Console.WriteLine("\t\t\t\t\t\t\t\t|-----------------------------------|");
                Console.WriteLine("\t\t\t\t\t\t\t\t*\t6. Add Client Record\t    *");
                Console.WriteLine("\t\t\t\t\t\t\t\t|-----------------------------------|");
                Console.WriteLine("\t\t\t\t\t\t\t\t*\t7. Display All Sales\t    *");
                Console.WriteLine("\t\t\t\t\t\t\t\t|-----------------------------------|");
                Console.WriteLine("\t\t\t\t\t\t\t\t*\t8. Exit\t\t\t    *");
                Console.WriteLine("\t\t\t\t\t\t\t\t|-----------------------------------|");
                Console.Write("\n\t\t\t\t\t\t\t\t\tChoose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("\t\t\t\t\t\t\t---------------------------------------------------");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\t\t\t\t\t\t\t\t    >>* Product Details *<<");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\t\t\t\t\t\t\t---------------------------------------------------");

                        Console.WriteLine("\n\t\t\t\t\t\t\t-----------------------------------------------------");

                        Console.WriteLine("\t\t\t\t\t\t\t" + "Product Id" + "\t" + "Product Name" + "\t" + "Price" + "\t " + "Stock" + "\t" + "Brand");
                        Console.WriteLine("\t\t\t\t\t\t\t-------------------------------------------------------");
                        Product.DisplayProducts();
                        Console.WriteLine("\t\t\t\t\t\t\t-------------------------------------------------------");
                        break;
                    case "2":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\n\t\t\t\t\t\t\t\t    >>* Add New product *<<");
                        Console.WriteLine("\t\t\t\t\t\t\t\t     ---------------------");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("\n\t\t\t\t\t\t\t\t=> Enter Product ID: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("\t\t\t\t\t\t\t\t=> Enter Product Name: ");
                        string name = Console.ReadLine();
                        Console.Write("\t\t\t\t\t\t\t\t=> Enter Product Price: ");
                        double price = double.Parse(Console.ReadLine());
                        Console.Write("\t\t\t\t\t\t\t\t=> Enter Stock Quantity: ");
                        int stock = int.Parse(Console.ReadLine());
                        Console.Write("\t\t\t\t\t\t\t\t=> Enter Brand: ");
                        string brand = Console.ReadLine();
                        Product.AddProduct(id, name, price, stock, brand);
                        break;
                    case "3":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\n\t\t\t\t\t\t\t\t    >>* Update Product Details *<<");
                        Console.WriteLine("\t\t\t\t\t\t\t\t     ----------------------------");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("\n\t\t\t\t\t\t\t\t=> Enter Product ID To Update: ");
                        int updateId = int.Parse(Console.ReadLine());
                        Console.Write("\t\t\t\t\t\t\t\t=> New Product Name: ");
                        string newName = Console.ReadLine();
                        Console.Write("\t\t\t\t\t\t\t\t=> Enter New Product Price: ");
                        double newPrice = double.Parse(Console.ReadLine());
                        Console.Write("\t\t\t\t\t\t\t\t=> Enter New Stock Quantity: ");
                        int newStock = int.Parse(Console.ReadLine());
                        Console.Write("\t\t\t\t\t\t\t\t=> Enter New Brand: ");
                        string newBrand = Console.ReadLine();
                        Product.UpdateProduct(updateId, newName, newPrice, newStock, newBrand);
                        break;
                    case "4":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\n\t\t\t\t\t\t\t\t    >>* Manage Product *<<");
                        Console.WriteLine("\t\t\t\t\t\t\t\t     ---------------------");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("\n\t\t\t\t\t\t\t\t=> Enter Product ID to delete: ");
                        int deleteId = int.Parse(Console.ReadLine());
                        Product.DeleteProduct(deleteId);
                        break;
                    case "5":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\n\t\t\t\t\t\t\t\t    >>* Search Any Product *<<");
                        Console.WriteLine("\t\t\t\t\t\t\t\t     ------------------------");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("\n\t\t\t\t\t\t\t\t=> Enter Product Name to search: ");
                        string searchName = Console.ReadLine();
                        Product.SearchProduct(searchName);
                        break;
                    case "6":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\n\t\t\t\t\t\t\t\t    >>* Add Client Record *<<");
                        Console.WriteLine("\t\t\t\t\t\t\t\t     ---------------------");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("\n\t\t\t\t\t\t\t\t=> Enter Sale ID: ");
                        int saleId = int.Parse(Console.ReadLine());
                        Console.Write("\t\t\t\t\t\t\t\t=> Enter Product ID for Sale: ");
                        int productId = int.Parse(Console.ReadLine());
                        Console.Write("\t\t\t\t\t\t\t\t=> Enter Client Name: ");
                        string clientName = Console.ReadLine();
                        Console.Write("\t\t\t\t\t\t\t\t=> Enter Quantity Sold: ");
                        int quantitySold = int.Parse(Console.ReadLine());
                        Sale.CreateSale(saleId, productId, clientName, quantitySold);
                        break;
                    case "7":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\n\t\t\t\t\t\t\t\t      >>* All Sales *<<");
                        Console.WriteLine("\t\t\t\t\t\t\t\t     ---------------------");
                        Console.ForegroundColor = ConsoleColor.White;
                        Sale.DisplaySales();
                        break;
                    case "8":
                        return; // Exit the application
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\t\t\t\t\t\t\t\tInvalid choice. Please try again.");
                        break;
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n\t\t\t\t\t\t\t\tPress any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
