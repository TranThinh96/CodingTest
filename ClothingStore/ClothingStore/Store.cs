using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Model
{
    public class Store
    {
        private List<Size> Sizes;

        private List<Color> Colors;

        private List<TypeProduct> TypeProducts;

        private List<Product> Products;

        private List<ProductDetail> ProductDetails;

        private List<TypeOrder> TypeOrders;

        private List<Order> Orders;

        private List<User> Users;

        private List<OrderDetail> OrderDetails;

        public Store(List<Size> sizes, List<Color> colors, List<TypeProduct> typeProducts, List<Product> products, List<ProductDetail> productsDetails, List<Order> orders, List<TypeOrder> typeOrders, List<OrderDetail> orderDetails, List<User> users)
        {
            Sizes = sizes;
            Colors = colors;
            TypeProducts = typeProducts;
            Products = products;
            ProductDetails = productsDetails;
            Orders = orders;
            TypeOrders = typeOrders;
            OrderDetails = orderDetails;
            Users = users;
        }


        public void CreateTypeProducts()
        {
            string name;
            int id;

            Console.Write("Enter type name: ");
            name = Console.ReadLine();
            id = TypeProducts.Last().Id + 1;

            TypeProducts.Add(new TypeProduct() { Id = id, Name = name });

            Console.WriteLine("Create success!!!");
        }

        public List<Product> GetProductList()
        {
            return Products;
        }

        public List<ProductDetail> GetProductDetailById(int id)
        {
            return ProductDetails.Where(item => item.IdProduct == id).ToList();
        }

        public string GetNameSizeById(int id)
        {
            return Sizes.Single(item => item.Id == id).Name;
        }

        public string GetNameColorById(int id)
        {
            return Colors.Single(item => item.Id == id).Name;
        }
    }
}
