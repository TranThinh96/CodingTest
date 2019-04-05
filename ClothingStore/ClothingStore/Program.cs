using ClothingStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore
{
    class Program
    {
        static List<Size> sizes = new List<Size>()
        {
            new Size() { Id = 1, Name = "S" }, new Size() { Id = 2, Name = "M" }
        };

        static List<Color> colors = new List<Color>()
        {
            new Color() { Id = 1, Name = "Red" },
            new Color() { Id = 2, Name = "Blue" }
        };

        static List<User> users = new List<User>()
        {
            new User() { Id = 1, Name = "Guest" }
        };

        static List<TypeProduct> typeProducts = new List<TypeProduct>()
        {
            new TypeProduct() { Id = 1, Name = "Shirt" }
        };

        static List<Product> products = new List<Product>()
        {
            new Product() { Id = 1, Name = "T-Shirt", IdType = 1, ImportPrice = 6, Price = 12 },
            new Product() { Id = 2, Name = "Dress Shirt", IdType = 1, ImportPrice = 8, Price = 20 },
        };

        static List<ProductDetail> productDetails = new List<ProductDetail>()
        {
            new ProductDetail() { Id = 1, IdProduct = 1, IdColor = 1, IdSize = 1, Quantity = 5 },
            new ProductDetail() { Id = 2, IdProduct = 1, IdColor = 1, IdSize = 2, Quantity = 5 },
            new ProductDetail() { Id = 3, IdProduct = 1, IdColor = 2, IdSize = 1, Quantity = 5 },
            new ProductDetail() { Id = 4, IdProduct = 2, IdColor = 1, IdSize = 1, Quantity = 5 },
            new ProductDetail() { Id = 5, IdProduct = 2, IdColor = 1, IdSize = 2, Quantity = 5 },
            new ProductDetail() { Id = 6, IdProduct = 2, IdColor = 2, IdSize = 1, Quantity = 5 },
            new ProductDetail() { Id = 7, IdProduct = 2, IdColor = 2, IdSize = 2, Quantity = 5 },
        };

        static List<TypeOrder> typeOrders = new List<TypeOrder>()
        {
            new TypeOrder() { Id = 1, Name = "Sell" },
            new TypeOrder() { Id = 2, Name = "Buy" }
        };

        static List<Order> orders = new List<Order>();
        static List<OrderDetail> orderDetails = new List<OrderDetail>();

        static Store store;


        static void BuyProduct()
        {
            List<Product> list = store.GetProductList();
            Console.WriteLine("------------List of import products------------");
            int i = 1;
            list.ForEach(item =>
            {
                Console.WriteLine("{0}. {1}: ${2}", i++, item.Name, item.ImportPrice);
            });
        }

        static void SellProduct()
        {
            List<Product> list = store.GetProductList();
            Console.WriteLine("------------List of sell products------------");
            list.ForEach(item =>
            {
                Console.WriteLine("{0}. {1}: ${2}", item.Id, item.Name, item.Price);
            });

            string key;
            do
            {
                Console.Write("Choose product by index(if stop enter 0): ");
                key = Console.ReadLine();

                int index = list.FindIndex(item => item.Id.ToString() == key);

                if (index != -1)
                {
                    List<ProductDetail> productDetails = store.GetProductDetailById(list[index].Id);
                    if (productDetails.Count == 0)
                    {
                        Console.WriteLine("This product is out");
                    }
                    else
                    {
                        Console.WriteLine("---------List of size and color product----------");
                        productDetails.ForEach(item =>
                        {
                            Console.WriteLine("{0}. {1} - {2}", item.Id, store.GetNameSizeById(item.IdSize), store.GetNameColorById(item.IdColor));
                        });
                    }
                }
                
            } while (key != "0");
        }


        static void Main(string[] args)
        {
            string i;
            store = new Store(sizes, colors, typeProducts, products, productDetails, orders, typeOrders, orderDetails, users);

            Console.WriteLine("--------------Menu-------------");
            Console.WriteLine("1. Buy clothing");
            Console.WriteLine("2. Cell clothing");
            Console.WriteLine("0. Exit");
            Console.Write("Choose: ");

            do
            {
                i = Console.ReadLine();

                switch(i)
                {
                    case "1":
                        BuyProduct();
                        break;

                    case "2":
                        SellProduct();
                        break;
                    default:
                        Console.WriteLine("--------------Menu-------------");
                        Console.WriteLine("1. Buy clothing");
                        Console.WriteLine("2. Cell clothing");
                        Console.Write("Choose: ");
                        break;
                }
                

            } while (i != "0");
            
            Console.ReadKey();
        }
    }
}
