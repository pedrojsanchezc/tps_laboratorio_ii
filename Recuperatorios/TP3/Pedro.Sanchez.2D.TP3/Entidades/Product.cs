using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Entidades
{
    public class Product : IInformationData
    {
        public enum ProducType
        { 
            Madera, Acero, Otros
        }
        private int id;
        private ProducType type;
        private string description;
        private float unitPrice;
        private int quantity;

        public int Id { get { return id; } set { id = value; } }
        public ProducType Type { get { return type; } set { type = value; } }
        public string Description { get { return description; } set { description = value; } }
        public float Price { get { return unitPrice; } set { unitPrice = value; } }
        public int Quantity { get { return quantity; } set { quantity = value; } }

        static Product()
        {
            string fileName = "ListadodeProductos";
            string routeFile = AppDomain.CurrentDomain.BaseDirectory + fileName + ".json";
            if (!File.Exists(routeFile))
            {
                Product.IncreaseId(0);
            }
        }

        public Product()
        { 
        
        }

        public Product(ProducType type, string description, float unitPrice, int quantity)
        {
            try
            {
                this.id = Product.GetId();
                this.type = type;
                this.description = description;
                this.unitPrice = unitPrice;
                this.quantity = quantity;
                Product.IncreaseId(this.id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error a la hora de guardar un producto", ex);
            }
        }
        private Product(Product product)
        {
            this.id = product.Id;
            this.type = product.type;
            this.description = product.description;
            this.unitPrice = product.unitPrice;
            this.quantity = 1;
        }
        public override string ToString()
        {
            return $"{this.description} -- {this.quantity} x ${this.unitPrice} = ${this.quantity * this.unitPrice}";
        }
        private static int GetId()
        {
            try
            {
                string id = String.Empty;
                id = File<string>.ReadFileTxt("ultimoIdProducto");
                return int.Parse(id);
            }
            catch (FileException ex)
            {
                throw new FileException("Error al momento de leer el ultimo ID", ex);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString(), ex);
            }
        }
        private static void IncreaseId(int id)
        {
            try
            {
                id += 1;
                File<string>.WriteFileTxt("ultimoIdProducto", id.ToString());
            }
            catch (FileException ex)
            {
                throw new Exception("Error a la hora de leer el ultimo ID", ex);
            }
        }
        public bool AddProductToCart(List<Product> cart)
        {
            Product productToSell  = null;
            int index;
            if (cart != null && this.Quantity > 0)
            {
                index = ProductInCart(cart, this.id);
                if (index == -1)
                {
                    productToSell = new Product(this);
                    cart.Add(productToSell);
                }
                else
                {
                    cart[index].quantity++;
                }

                return true;
            }

            return false;
        }
        public int ProductInCart(List<Product> cart, int idProduct)
        {
            if (cart != null && idProduct > 0)
            {
                foreach (Product item in cart)
                {
                    if (item.id == idProduct)
                    {
                        return cart.IndexOf(item);
                    }
                }
            }

            return -1;
        }
        public static void ReturnProduct(List<Product> cart)
        {
            if (cart != null && cart.Count > 0)
            {
                foreach (Product item in cart)
                {
                    foreach (Product item2 in Store.listProducts)
                    {
                        if (item2.id == item.id)
                        {
                            item2.quantity += item.quantity;
                            break;
                        }
                    }
                }
            }
        }
        public static void DeleteProductToCart(Product product, List<Product> cart)
        {
            if (product != null)
            {
                product.Quantity--;
                foreach (Product item in Store.listProducts)
                {
                    if (product.Id == item.Id)
                    {
                        item.Quantity++;
                    }
                }

                if (product.Quantity == 0)
                {
                    cart.Remove(product);
                }
            }
        }
        public string ShowInfoData()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"ID DE PRODUCTO: {this.Id}");
            sb.AppendLine($"Tipo de Producto: {this.Type}");
            sb.AppendLine($"Descripcion del Producto: {this.Description}");
            sb.AppendLine($"Precio del Producto: ${this.Price}");
            sb.AppendLine($"Cantidad del Producto disponible: {this.Quantity}");

            return sb.ToString();
        }
    }
}
