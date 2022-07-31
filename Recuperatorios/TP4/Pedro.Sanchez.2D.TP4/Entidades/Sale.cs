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
        private string saleProducts;

        public int Id { get { return id; } set { id = value; } }
        public DateTime DateSale { get { return dateSale; } set { dateSale = value; } }
        public float Price { get { return price; } set { price = value; } }
        public string SaleProducts { get { return saleProducts; } set { if (!string.IsNullOrEmpty(value)) { saleProducts = value; } else { throw new Exception("Error a la hora de construir el objeto"); } } }

        public Sale()
        { 
        
        }

        public Sale(float price, string saleProducts)
        {
            try
            {
                this.id = 0;
                this.dateSale = DateTime.Now;
                this.price = price;
                this.SaleProducts = saleProducts;
            }
            catch (Exception)
            {
                throw new Exception("Error a la hora de guardar una Sale");
            }
        }
        public Sale(DateTime dateSale, float price, string saleProducts)
        {
            try
            {
                this.dateSale = dateSale;
                this.price = price;
                this.saleProducts = saleProducts;
                if (price <= 0 || string.IsNullOrEmpty(saleProducts))
                {
                    throw new Exception("Error en la informacion");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string ProductsSold(List<Product> cartProducts)
        {
            StringBuilder sb = new StringBuilder();
            if (cartProducts != null)
            {
                foreach (Product item in cartProducts)
                {
                    sb.AppendLine(item.Description + " x " + item.Quantity.ToString());
                }
            }

            return sb.ToString();
        }
        public static int CountQuantitySales()
        {
            List<Sale> ventasdeBBDD = DataBase.GetSales();
            return ventasdeBBDD.Count;
        }
        public static float CountRaised()
        {
            float accumulator = 0;
            List<Sale> ventasdeBBDD = DataBase.GetSales();
            foreach (Sale item in ventasdeBBDD)
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
            sb.AppendLine($"{this.saleProducts}");
            sb.AppendLine($" Precio de cobro por Producto: ${this.price}");

            return sb.ToString();
        }
    }
}
