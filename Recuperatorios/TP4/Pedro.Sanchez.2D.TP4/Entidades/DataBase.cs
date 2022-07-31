using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Entidades
{
    public static class DataBase
    {
        static SqlConnection connection;
        static SqlCommand command;

        static DataBase()
        {
            connection = new SqlConnection(@"Data Source=.;Initial Catalog=TP4_2D_PedroSanchez;Integrated Security=True");
            command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = connection;
        }
        public static List<Product> GetProducts()
        {
            try
            {
                List<Product> listProducts = new List<Product>();

                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }
                command.CommandText = "SELECT * FROM dbo.Products";
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        Product ProductDesdeBase = new Product(
                            (Product.ProducType)Convert.ToInt32(dataReader["ProducType"]),
                                dataReader["Description"].ToString(),
                                float.Parse(dataReader["Price"].ToString()),
                                Convert.ToInt32(dataReader["Quantity"]));

                        ProductDesdeBase.Id = Convert.ToInt32(dataReader["ID"]);
                        listProducts.Add(ProductDesdeBase);
                    }
                    return listProducts;
                }
            }
            catch (Exception ex)
            {
                if (System.Threading.Thread.CurrentThread.ManagedThreadId == 0)
                {
                    throw new Exception("Error el traer lista de Products desde BBDD", ex);
                }
                else
                {
                    return null; 
                }
            }
            finally
            {
                connection.Close();
            }
        }
        public static void ModifyProductPrice(int idProduct, float newPrice)
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }
                command.Parameters.Clear();
                command.CommandText = "UPDATE dbo.Products SET Price = @price WHERE ID = @id";
                command.Parameters.AddWithValue("@price", newPrice);
                command.Parameters.AddWithValue("@id", idProduct);

                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new Exception("Error al modificar la lista de Products a la BBDD");
            }
            finally
            {
                connection.Close();
            }
        }
        public static void ModifyProductQuantity(int idProduct, int newQuantity)
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }
                command.Parameters.Clear();
                command.CommandText = "UPDATE dbo.Products SET Quantity = @quantity WHERE ID = @id";
                command.Parameters.AddWithValue("@quantity", newQuantity);
                command.Parameters.AddWithValue("@id", idProduct);

                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new Exception("Error al modificar la lista de Products a la BBDD");
            }
            finally
            {
                connection.Close();
            }
        }
        public static void DeleteProduct(int idProduct)
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }
                command.Parameters.Clear();
                command.CommandText = "DELETE FROM dbo.Products WHERE ID = @id";
                command.Parameters.AddWithValue("@id", idProduct);

                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new Exception("Error al eliminar un Product de la BBDD");
            }
            finally
            {
                connection.Close();
            }
        }
        public static void AddProduct(Product product)
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }
                command.Parameters.Clear();
                command.CommandText = "INSERT INTO dbo.Products (ProducType, Description, Price, Quantity) " +
                    "VALUES (@ProducType, @description, @price, @quantity)";
                command.Parameters.AddWithValue("@ProducType", (int)product.Type);
                command.Parameters.AddWithValue("@description", product.Description);
                command.Parameters.AddWithValue("@price", product.Price);
                command.Parameters.AddWithValue("@quantity", product.Quantity);
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new Exception("Error al agregar un Product a la BBDD");
            }
            finally
            {
                connection.Close();
            }
        }
        public static void AddSale(Sale sale)
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }
                command.Parameters.Clear();
                command.CommandText = "INSERT INTO dbo.Sales (DateSale, Price, SaleProducts) " +
                    "VALUES (@dateSale, @price, @SaleProducts)";
                command.Parameters.AddWithValue("@dateSale", sale.DateSale);
                command.Parameters.AddWithValue("@price", sale.Price);
                command.Parameters.AddWithValue("@SaleProducts", sale.SaleProducts);

                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new Exception("Error al agregar una Sale a la BBDD");
            }
            finally
            {
                connection.Close();
            }
        }
        public static List<Sale> GetSales()
        {
            try
            {
                List<Sale> listSales = new List<Sale>();

                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }
                command.CommandText = "SELECT * FROM dbo.Sales";
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        Sale sale = new Sale(DateTime.Parse(dataReader["DateSale"].ToString()),
                                float.Parse(dataReader["Price"].ToString()),
                                dataReader["SaleProducts"].ToString());

                        sale.Id = Convert.ToInt32(dataReader["Id"]);
                        listSales.Add(sale);
                    }
                    return listSales;
                }
            }
            catch (Exception)
            {
                throw new Exception("Error el traer lista de Sales desde BBDD");
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
