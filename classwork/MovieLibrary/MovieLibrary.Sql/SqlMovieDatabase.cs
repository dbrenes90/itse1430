﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MovieLibrary.Sql
{
    //ADO.NET
    // Provider specific types: (Provider) - 
    //     System.Data.(Provider)Client
    // Connection ::= Logical connection to a database
    // Command ::= Represents action to take (DML - data manipulation lang vs DDL - data definition lang)
    // -Reader ::= Reads data as a stream
    // DataAdapter ::= Reads data as a buffer
    // Transaction ::= Multiple commands
    public class SqlMovieDatabase : MovieDatabase
    {
        public SqlMovieDatabase ( string connectionString )
        {
            //Should probably validate
            _connectionString = connectionString;
        }

        //Make readonly as it is only set in constructor
        private readonly string _connectionString;
        protected override Movie AddCore ( Movie movie )
        {
            using (var connection = OpenConnection())
            {
                //Provider-agnostic way to create command
                var command = connection.CreateCommand();
                command.CommandText = "AddMovie";
                command.CommandType = CommandType.StoredProcedure;

                //Add parameters
                //    1. Create parameter and add manually
                var parmName = new SqlParameter("@name", movie.Name);
                command.Parameters.Add(parmName);

                //   2. Create parameter using command
                var parmDescription = command.CreateParameter();
                parmDescription.ParameterName = "@description";
                parmDescription.Value = movie.Description;
                parmDescription.SqlDbType = SqlDbType.NVarChar;
                command.Parameters.Add(parmDescription);

                //   3. (SQL Server) AddWithValue (Preferred when SQL)
                command.Parameters.AddWithValue("@rating", movie.Rating);
                command.Parameters.AddWithValue("@releaseYear", movie.ReleaseYear);
                command.Parameters.AddWithValue("@runLength", movie.RunLength);
                command.Parameters.AddWithValue("@isClassic", movie.IsClassic);

                //Execute command
                //   ExecuteNonQuery ::= Returns (or don't care about) nothing - DELETE, UPDATE
                //   ExecuteScalar ::= Returns the first value of the first row, if any - INSERT
                //   ExecuteReader  ::= Returns results (streaming)
                object result = command.ExecuteScalar();
                var id = Convert.ToInt32(result);

                //Finish out method
                movie.Id = id;
                return movie;
            };
        }
        //public void Delete ( int id )
        protected override void DeleteCore ( int id )
        {

            using (var connection = OpenConnection())
            {
                //Provider-agnostic way to create command
                var command = connection.CreateCommand();
                command.CommandText = "DeleteMovie";
                command.CommandType = CommandType.StoredProcedure;

                //Add Parameters
                command.Parameters.AddWithValue("@id", id);

                //Execute command
                //   ExecuteNonQuery ::= Returns (or don't care about) nothing - DELETE, UPDATE
                //   ExecuteScalar ::= Returns the first value of the first row, if any - INSERT
                //   ExecuteReader  ::= Returns results (streaming)
                command.ExecuteNonQuery();

            };
        }
        //Use IEnumerable<T> for readonly lists of items        
        protected override IEnumerable<Movie> GetAllCore ()
        {   
            
            var ds = new DataSet();

            //IDisposable so always wrap in a using
            using (var connection = OpenConnection())
            {
                //Provider-specific way
                //Note: IDisposable but no existing implementation needs it
                var command = new SqlCommand("GetMovies", connection);
                command.CommandType = CommandType.StoredProcedure;

                //Execute the command - using the buffered approach
                var da = new SqlDataAdapter() {
                    SelectCommand = command
                };

                //Retrieve data (buffered)
                da.Fill(ds);
            };
                //Get table, if any
                var table = ds.Tables.Count > 0 ? ds.Tables[0] : null;
                if (table != null)
                {
                    //Enumerate the rows
                    // Convert IEnumerable to IEnumerable<DataRow> using OfType<>
                    //    foreach (var item in table.Rows) {if (item is DataRow row) yield return row}
                    foreach (var row in table.Rows.OfType<DataRow>())
                    {
                        //Access fields
                        // Get specific column
                        //  # - by ordinal (0 based index)
                        //  name - by column name
                        // Get typed value
                        //   Convert.ToInt32(row[#]) ::= Object to Int32
                        //   row[].ToString() ::= To a string [Preferred approach]
                        // DBNull.Value - NULL in database

                        // Is Null?
                        //var isNull = row["ReleaseYear"] == DBNull.Value;
                        //row.IsNull("ReleaseYear");  True or False

                        yield return new Movie() {

                            Id = Convert.ToInt32(row[0]),
                            Name = row["name"].ToString(),

                            Description = row.IsNull("Description") ? null : row.Field<string>("description"),
                            Rating = row.Field<string>("Rating"),

                            ReleaseYear = row.IsNull("ReleaseYear") ? 1900 : row.Field<int>("ReleaseYear"),
                            RunLength = row.IsNull("RunLength") ? 0 : row.Field<int>("RunLength"),
                            IsClassic = row.Field<bool>("IsClassic"),
                        };
                    };

                };      
               
        }
        
        protected override Movie GetByIdCore ( int id)
        {
            using (var connection = OpenConnection())
            {
                var command = connection.CreateCommand();
                command.CommandText = "GetMovie";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@id", id);

                //Stream data using reader
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var movieId = reader.GetInt32(0);
                        if (movieId == id)
                        {
                            //Read using either
                            //  Get(Primitive)
                            //  GetFieldValue<T>
                            // Warning:
                            //   Use Ordinal - string column names require extra code
                            //    ** Boolean doesn't work, ** Null doesn't work
                            //   var ordinal = reader.GetOrdinal("Name");
                            //   reader.GetString(ordinal);

                            //int? nullableInt = 10;
                            //nullableInt = null;

                            return new Movie() {
                                Id = movieId,
                                Name = reader.GetString(1),
                                Description = reader.IsDBNull(2) ? null : reader.GetString(2),
                                Rating = reader.GetFieldValue<string>(3),
                                ReleaseYear = reader.IsDBNull(4) ? 1900 : reader.GetFieldValue<int>(4),
                                RunLength = reader.IsDBNull(5) ? 0 : reader.GetFieldValue<int>(5),
                                IsClassic = reader.GetFieldValue<bool>(6)

                            };
                        };
                    };
                };
            };
            return null;
        }           
               
        protected override void UpdateCore (int id, Movie movie)
        {
            using (var connection = OpenConnection())
            {
                //Provider-agnostic way to create command
                var command = connection.CreateCommand();
                command.CommandText = "UpdateMovie";
                command.CommandType = CommandType.StoredProcedure;

                //Add parameters
                //    1. Create parameter and add manually
                var parmName = new SqlParameter("@name", movie.Name);
                command.Parameters.Add(parmName);

                //   2. Create parameter using command
                var parmDescription = command.CreateParameter();
                parmDescription.ParameterName = "@description";
                parmDescription.Value = movie.Description;
                parmDescription.SqlDbType = SqlDbType.NVarChar;
                command.Parameters.Add(parmDescription);

                //   3. (SQL Server) AddWithValue (Preferred when SQL)
                command.Parameters.AddWithValue("@rating", movie.Rating);
                command.Parameters.AddWithValue("@releaseYear", movie.ReleaseYear);
                command.Parameters.AddWithValue("@runLength", movie.RunLength);
                command.Parameters.AddWithValue("@isClassic", movie.IsClassic);
                command.Parameters.AddWithValue("@id", id);
                //Execute command
                //   ExecuteNonQuery ::= Returns (or don't care about) nothing - DELETE, UPDATE
                //   ExecuteScalar ::= Returns the first value of the first row, if any - INSERT
                //   ExecuteReader  ::= Returns results (streaming)
                command.ExecuteNonQuery();            
                                                
            };
        }
        protected override Movie GetByName ( string name )
        {
            var movies = GetAllCore();
            //foreach (var movie in movies)
            //{
            //   if (String.Compare(movie.Name, name, true) == 0)
            //       return movie;
            //};

            //Delegate (treat function as data)
            //PredicateDelegate predicate = MovieHasName;

            //Use an anonymous method 
            //   parameters => expression

            //1. Using delegate
            //Func<Movie, bool> predicate = movie => MovieHasName(movie, name);
            //IEnumerable<Movie> filteredMovies = movies.Where(predicate);

            //2. Use directly
            //var filteredMovies = movies.Where(movie => MovieHasName(movie, name));

            //3. Use without method
            // Parameters on left provided by Where method call
            // Expression on right returned by function 
            // () => E
            // (p1, p2) => E
            //var filteredMovies = movies.Where(movie => String.Compare(movie.Name, name, true) == 0);       

            return movies.FirstOrDefault(movie => String.Compare(movie.Name, name, true) == 0);
                               

            //return null;
            
        }

        //delegate bool PredicateDelegate ( Movie movie, string name );
        //private bool MovieHasName ( Movie movie, string name)
        //{
        //    return String.Compare(movie.Name, name, true) == 0;
        //}
        private SqlConnection OpenConnection()
        {
            //Connect to database using connection string
            var conn = new SqlConnection(_connectionString);

            //SqlException if something goes wrong
            conn.Open();

            return conn;
        }        
        
        // Dataset vs DataReader (buffered vs streamed)
        //
        // Dataset: (Loads database info then disconnect) 
        //   A. Disconnected from database
        //   A. Discoverable - column names, types, nullables and relationships 
        //   A. Pre-defined business objects (DataRow)
        //   A. Modifiable 
        //   D. High memory overhead (< 1k) (magnitudes greater)
        //
        // Data readers:  [Use for Lab 4]
        //   A. No memory overhead
        //   A. Fast
        //   A. Store in your business objects
        //   D. Must know the data
        //   D. Cannot modify data [read-only] 

        // Use a data reader unless you absolutely need a feature not available in a data reader
        // Use a dataset when you need very small sets of fixed data where no business logic is needed

        //Only store cloned copies of movies here!!
        //private Movie[] _movies = new Movie[100];
        private List<Movie> _movies = new List<Movie>();    //Generic list of movies, use for fields
        private int _id = 1;
    }
}
