using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nile.Stores
{
    public class SqlProductDatabase : ProductDatabase
    {
        public SqlProductDatabase ( string connectionString)
        {
            _connectionString = connectionString;
        }

        private readonly string _connectionString;

        protected override Product AddCore(Product product)
        {
            using (var connection = OpenConnection())
            {
                var command = connection.CreateCommand();
                command.CommandText = "AddProduct";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@name", product.Name);
                command.Parameters.AddWithValue("@description", product.Description);
                command.Parameters.AddWithValue("@price", product.Price);
                command.Parameters.AddWithValue("@isDiscontinued", product.IsDiscontinued);

                object result = command.ExecuteScalar();
                var id = Convert.ToInt32(result);

                product.Id = id;
                return product;
            };
        }

        protected override void RemoveCore( int id)

        {
            using (var connection = OpenConnection())
            {
                
                var command = connection.CreateCommand();
                command.CommandText = "RemoveProduct";
                command.CommandType = CommandType.StoredProcedure;

                //Add Parameters
                command.Parameters.AddWithValue("@id", id);
                
                command.ExecuteNonQuery();

            };

        }

       
        protected override IEnumerable<Product> GetAllCore()
        {
            var ds = new DataSet();

            
            using (var connection = OpenConnection())
            {
                
                var command = new SqlCommand("GetAllProducts", connection);
                command.CommandType = CommandType.StoredProcedure;

                
                var da = new SqlDataAdapter()
                {
                    SelectCommand = command
                };
                
                da.Fill(ds);
            };
            
            var table = ds.Tables.Count > 0 ? ds.Tables[0] : null;
            if (table != null)
            {
               
                foreach (var row in table.Rows.OfType<DataRow>())
                {
                    

                    yield return new Product()
                    {

                        Id = Convert.ToInt32(row[0]),
                        Name = row["name"].ToString(),

                        Description = row.IsNull("Description") ? null : row.Field<string>("description"),
                        Price = row.Field<decimal>("Price"),               
                        IsDiscontinued = row.Field<bool>("IsDiscontinued"),
                    };
                };

            };

        }

               

       
        protected override Product UpdateCore(Product existing, Product product)
        {
            using (var connection = OpenConnection())
            {
                //Provider-agnostic way to create command
                var command = connection.CreateCommand();
                command.CommandText = "UpdateProduct";
                command.CommandType = CommandType.StoredProcedure;               

                command.Parameters.AddWithValue("@name", product.Name);
                command.Parameters.AddWithValue("@description", product.Description);
                command.Parameters.AddWithValue("@price", product.Price);
                command.Parameters.AddWithValue("@isDiscontinued", product.IsDiscontinued);
                command.Parameters.AddWithValue("@id", product.Id);


                command.ExecuteNonQuery();

            };
            return CopyProduct(product);
        }
        protected override Product GetCore(int id)
        {
            /* using (var connection = OpenConnection())
             {
                 var command = connection.CreateCommand();
                 command.CommandText = "GetProduct";
                 command.CommandType = CommandType.StoredProcedure;

                 command.Parameters.AddWithValue("@id", id);

                 using (var reader = command.ExecuteReader())
                 {
                     while (reader.Read())
                     {
                         var productId = reader.GetInt32(0);
                         if (productId == id)
                         {                       

                             return new Product()
                             {
                                 Id = productId,
                                 Name = reader.GetString(1),
                                 Description = reader.GetString(2),                                
                                 Price = reader.GetFieldValue<decimal>(3),                                
                                 IsDiscontinued = reader.GetFieldValue<bool>(4)

                             };
                         };
                     };
                 };
             };
             return null;
            */
            var product = FindProduct(id);

            return (product != null) ? CopyProduct(product) : null;
        }
        private Product CopyProduct(Product product)
        {
            var newProduct = new Product();
            newProduct.Id = product.Id;
            newProduct.Name = product.Name;
            newProduct.Description = product.Description;
            newProduct.Price = product.Price;
            newProduct.IsDiscontinued = product.IsDiscontinued;

            return newProduct;
        }
        private SqlConnection OpenConnection()
        {
            var conn = new SqlConnection(_connectionString);

            conn.Open();

            return conn;
        }
   
        private Product FindProduct(int id)
        {
            foreach (var product in _products)
            {
                if (product.Id == id)
                    return product;
            };

            return null;
        }

        private List<Product> _products = new List<Product>();
        private int _nextId = 1;
    }
}
