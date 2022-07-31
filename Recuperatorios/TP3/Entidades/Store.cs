using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Store
    {
        public static List<Product> listProducts;
        public static List<Sale> listSaleRecord;

        static Store()
        {
            listProducts = new List<Product>();
            listSaleRecord = new List<Sale>();
        }

        public static void AddProducts()
        {
            try
            {
                string fileName = "ListadodeProductos";
                string fileRoute = AppDomain.CurrentDomain.BaseDirectory + fileName + ".json";
                if (File.Exists(fileRoute))
                {
                    listProducts = File<List<Product>>.ReadJson(fileName);
                }
                else {
                    //Madera, Acero, Otros
                    listProducts.Add(new Product(Product.ProducType.Madera, "Escritorio de Madera 40x60cm", 100, 50));
                    listProducts.Add(new Product(Product.ProducType.Madera, "Mesa Plegable de Madera 100x130cm", 120, 50));
                    listProducts.Add(new Product(Product.ProducType.Madera, "Tablas de Madera para Pisos Flotantes", 200, 50));
                    listProducts.Add(new Product(Product.ProducType.Acero, "Lamina de Acero 1Pulgada", 100, 50));
                    listProducts.Add(new Product(Product.ProducType.Acero, "Tuberia de Acero ", 130, 50));
                    listProducts.Add(new Product(Product.ProducType.Acero, "Cadenas de Acero", 100, 50));
                    listProducts.Add(new Product(Product.ProducType.Otros, "Aguarras", 80, 50));
                    listProducts.Add(new Product(Product.ProducType.Otros, "Balde Plastico", 200, 50));
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR!! Al momento de hacer un alta de Productos", ex);
            }
        }
        public static void UploadSales()
        {
            try
            {
                string fileName = "ListadodeVentas";
                string routeFile = AppDomain.CurrentDomain.BaseDirectory + fileName + ".xml";

                if (File.Exists(routeFile))
                {
                    listSaleRecord = File<List<Sale>>.ReadXml(fileName);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error a la hora de cargar las ventas", ex);
            }
        }
    }
}
