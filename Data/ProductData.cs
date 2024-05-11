using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ProductData
    {

 
            string connectionString = "Data Source=LAB1504-24\\SQLEXPRESS;Initial Catalog=FacturaDB; User Id=User01;Password=123456";

            public List<Product> Get()
            {
                List<Product> products = new List<Product>();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("ListarProductos", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = command.ExecuteReader();
                        
                            while (reader.Read())
                            {
                                Product product = new Product();
                                product.ProductID = Convert.ToInt32(reader["Product_id"]);
                                product.Name = reader["Name"].ToString();
                                product.Price = Convert.ToDecimal(reader["Price"]);
                                product.Stock = Convert.ToInt32(reader["Stock"]);
                                products.Add(product);
                            }
                            reader.Close();
                        
                        return products;
                    }
                }
            }
            
            public void Insert(Product product)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("InsertarProductos", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Name", product.Name);
                        command.Parameters.AddWithValue("@Price", product.Price);
                        command.Parameters.AddWithValue("@Stock", product.Stock);

                        command.ExecuteNonQuery();
                    }
                }
            }
        
        public void Insert(string name)
        {
        }
        public void Update()
        {
        }
        public void Delete()
        {
        }
    }
}
