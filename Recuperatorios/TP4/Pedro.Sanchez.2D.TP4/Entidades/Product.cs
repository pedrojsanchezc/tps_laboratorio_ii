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
        public event EndProduct endProduct;


        public int Id { get { return id; } set { id = value; } }
        public ProducType Type { get { return type; } set { type = value; } }
        public string Description { get { return description; } set { description = value; } }
        public float Price { get { return unitPrice; } set { unitPrice = value; } }
        public int Quantity { get { return quantity; } set { quantity = value; } }

        public Product()
        { 
        
        }

        public Product(ProducType type, string description, float unitPrice, int quantity)
        {
            try
            {
                this.id = 0;
                this.type = type;
                this.description = description;
                this.unitPrice = unitPrice;
                this.quantity = quantity;
                if (!Enum.IsDefined(typeof(ProducType), type) || string.IsNullOrEmpty(description) || unitPrice <= 0 || quantity < 0)
                {
                    throw new Exception("Error");
                }
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
            Product productToSale = null;
            int index;
            if (cart != null && this.Quantity > 0)
            {
                index = cart.FindIndex((x) => x.Id == this.Id);
                if (index == -1)
                {
                    productToSale = new Product(this);
                    cart.Add(productToSale);
                }
                else
                {
                    cart[index].quantity++;
                }

                return true;
            }

            return false;
        }
        public static void ReturnProduct(List<Product> cart)
        {
            try
            {
                List<Product> listProductsBBDD = DataBase.GetProducts();
                if (cart != null && cart.Count > 0)
                {
                    foreach (Product itemCart in cart)
                    {
                        foreach (Product itemStock in listProductsBBDD)
                        {
                            if (itemStock.id == itemCart.id)
                            {
                                itemStock.quantity += itemCart.quantity;
                                DataBase.ModifyProductQuantity(itemStock.Id, itemStock.Quantity);
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al devolver los productos", ex);
            }
        }
        public void RestarStock(int quantityToDelete)
        {
            if (quantityToDelete >= this.Quantity)
            {
                this.Quantity = 0;
                endProduct?.Invoke(this.Description);
            }
            else
            {
                this.Quantity -= quantityToDelete;
            }
        }
        public static void DeleteProductToCart(Product product, List<Product> cart)
        {
            if (product != null)
            {
                List<Product> listProductsBBDD = DataBase.GetProducts();
                product.Quantity--;
                foreach (Product item in listProductsBBDD)
                {
                    if (item.Id == product.Id)
                    {
                        item.Quantity++;
                        DataBase.ModifyProductQuantity(item.Id, item.Quantity);
                        break;
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

            sb.AppendLine($"Tipo de Producto: {this.Type}");
            sb.AppendLine($"Descripcion del Producto: {this.Description}");
            sb.AppendLine($"Precio del Producto: ${this.Price}");
            sb.AppendLine($"Cantidad del Producto disponible: {this.Quantity}");

            return sb.ToString();
        }
    }
}
