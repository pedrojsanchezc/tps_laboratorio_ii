using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Entidades
{
    public class Sale : IInformationData
    {
        private int id;
        private DateTime dateSale;
        private float price;
        private List<string> saleProducts;

        public int Id { get { return id; } set { id = value; } }
        public DateTime DateSale { get { return dateSale; } set { dateSale = value; } }
        public float Price { get { return price; } set { price = value; } }

        public List<string> SaleProducts { get { return saleProducts; } set { saleProducts = value; } }

        public Sale()
        { 
        
        }

        public Sale(float price, List<string> saleProducts)
        {
            try
            {
                this.id = Sale.GetId();
                this.dateSale = DateTime.Now;
                this.price = price;
                this.saleProducts = saleProducts;
                Sale.IncrementId(this.id);
            }
            catch (Exception)
            {
                throw new Exception("Error a la hora de guardar una Sale");
            }
        }
        public static List<string> ProductsSold(List<Product> cartProducts)
        {
            List<string> listProducts = null;
            StringBuilder sb = new StringBuilder();
            if (cartProducts != null)
            {
                listProducts = new List<string>();

                foreach (Product item in cartProducts)
                {
                    sb.AppendLine(item.Description + " x " + item.Quantity.ToString());
                }

                listProducts.Add(sb.ToString());
            }

            return listProducts;
        }
        public static int CountQuantitySales()
        {
            return Store.listSaleRecord.Count;
        }
        public static float CountRaised()
        {
            float accumulator = 0;
            foreach (Sale item in Store.listSaleRecord)
            {
                accumulator += item.Price;
            }

            return accumulator;
        }
        private static int GetId()
        {
            try
            {
                string id = String.Empty;
                id = File<string>.ReadFileTxt("ultimoIdVenta");
                return int.Parse(id);
            }
            catch (FileException ex)
            {
                throw new FileException("Error a la hora de obtener un ID", ex);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString(), ex);
            }
        }
        private static void IncrementId(int id)
        {
            try
            {
                id += 1;
                File<string>.WriteFileTxt("ultimoIdVenta", id.ToString());
            }
            catch (FileException ex)
            {
                throw new Exception("Error a la hora de asignar un ID", ex);
            }
        }
        public string ShowInfoData()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Fecha del Producto: {this.dateSale}");
            sb.AppendLine("");
            sb.AppendLine($"Productos comprados:");
            foreach (string item in this.saleProducts)
            {
                sb.AppendLine(item);
            }
            sb.AppendLine($" Precio de cobro por Producto: ${this.price}");

            return sb.ToString();
        }
    }
}
