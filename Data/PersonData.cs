using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class PersonData
    {
        string connectionString = "Data Source=LAB1504-29\\SQLEXPRESS;Initial Catalog=FacturaDB; User Id=User01;Password=123456";
        public List<Person> Get()
        {
            List<Person> people = new List<Person>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("USP_ListProduct", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Person person = new Person();
                            person.PersonID = Convert.ToInt32(reader["PersonID"]);
                            person.FirstName = reader["FirstName"].ToString();
                            person.LastName = reader["LastName"].ToString();
                            person.Age = Convert.ToInt32(reader["Age"]);
                            people.Add(person);
                        }
                        reader.Close();
                    }
                    return people;
                }
            }
        }
    
        public void Insert()
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
