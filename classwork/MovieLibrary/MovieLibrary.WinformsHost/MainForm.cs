using System; // DO NOT DELETE
using System.Linq;
using System.Windows.Forms;

using MovieLibrary.IO;
using MovieLibrary.Memory;

namespace MovieLibrary.WinformsHost
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            // Type = Movie
            // Variable = movie
            // Value = instance (or an object) (must create the instance)
            Movie movie;
            movie = new Movie(); // Create an instance ::= new T()
            
            //label2.Text = "A label";

            // var movie2 = new Movie(); // New instance
            
            //member access operator ::= Expression.Membername
            movie.Name = "Jaws";
            movie.Description = "Shark movie";
         
            // var str = movie.description;
            // Capital letters are either types or namespaces
            // Lowercase = local variables first (camelCase)

            // Hooks up an event handler to an event (+=) event context only , add to an event operator
            // Event += method
            // Event -= method
            _miMovieAdd.Click += OnMovieAdd;
            _miMovieEdit.Click += OnMovieEdit;
            _miMovieDelete.Click += OnMovieDelete;
            _miHelpAbout.Click += OnHelpAbout;
        }

        protected override void OnLoad ( EventArgs e)
        {
            base.OnLoad(e);

            int count = RefreshUI();
            if (count == 0)
            {
                //Seed database if empty
                if (MessageBox.Show(this, "No movies found. Do you want to add some example movies?", "Database empty", MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.Yes)
                {
                    //var seed = new SeedMovieDatabase();
                    //seed.Seed(_movies);
                    //SeedMovieDatabase.Seed(_movies);
                    _movies.Seed();
                    RefreshUI();
                };

            };

        }
        private void OnHelpAbout ( object sender, EventArgs e )
        {
            var about = new AboutBox();

            about.ShowDialog(this);
        }

        //Event - a notification to interested parties that something has happened (decoupling mechanism)

        //Array = T[] array of movies
        //  Instantiate ::= new Type[integer expression] (no fixed size)
        //  Index : 0 to Size -1
        // private Movie[] _movies = new Movie[100]; //0.99

        private IMovieDatabase _movies = new Sql.SqlMovieDatabase(_connectionString);

        //Normally don't put this in code - put in a configuration file
        private const string _connectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=MovieDb;Integrated Security=True;";

        // private IMovieDatabase _movies = new IO.FileMovieDatabase("movies.csv");

        // private Movie[] _emptyMovies = new Movie[0]; // empty arrays and nulls to be equivalent so always use empty array instead of null

        private void AddMovie ( Movie movie)
        {
            _movies.Add(movie);
            // var newMovie = _movies.Add(movie, out var message);
            //if (newMovie == null)
           // {
            //    MessageBox.Show(this, message, "Add Failed", MessageBoxButtons.OK);
            //    return;
            //};

            RefreshUI();
            //Find first empty spot in array
            // for ( Ei; EC; EU) S ;
            //     EI::= initializer expression (runs once before loop executes)
            //     EC::= conditional expresssion => boolean (executes before loop statement is run, aborts if condition is false)
            //     EU::= update expression ( runs at end of current iteration)
            // Length -> int (# of rows in the array)
            //for (var index = 0; index<_movies.Length; ++index)
           // {
                // Array element access ::= V{int}
            //    if (_movies[index] == null)
             //   {
            //        _movies[index] = movie;   // Movie is a ref type thus movie and _movies[index] reference the same instance
             //       return;
                       // Add movie to array
             //   }
          //  };

           // MessageBox.Show(this, "No more room for movies", "Add Failed", MessageBoxButtons.OK);
                

        }
        private void DeleteMovie ( int id )
        {
            _movies.Delete(id);
            RefreshUI();
           /*for (var index = 0; index<_movies.Length; ++index)
            {
                // Array element access ::= V{int}
                //if (_movies[index] != null && _movies[index].Id == id )
                if (_movies[index]?.Id == id ) // null conditional ?. if instance != null, access the member otherwise skip
                {
                    _movies[index] = null;   // Movie is a ref type thus movie and _movies[index] reference the same instance
                    return;
                    // Add movie to array
                }
            };*/

        }
        private void EditMovie (int id, Movie movie )
        {
            _movies.Update(id, movie);
            RefreshUI();
            //if (String.IsNullOrEmpty(error))
            //{
             //   RefreshUI();
              //  return;
           // };
            /*for (var index = 0; index<_movies.Length; ++index)
            {
                // Array element access ::= V{int}
                //if (_movies[index] != null && _movies[index].Id == id )
                if (_movies[index]?.Id == id) // null conditional ?. if instance != null, access the member otherwise skip
                {
                    //Just because we are doing this in memory (reference type)
                    movie.Id = id;
                    _movies[index] = movie;   // Movie is a ref type thus movie and _movies[index] reference the same instance
                    return;
                    // Add movie to array
                }
            };*/

            //MessageBox.Show(this, /*"Cannot find movie"*/error, "Edit Movie", MessageBoxButtons.OK);
        }

        private Movie GetSelectedMovie()
        {
            return _lstMovies.SelectedItem as Movie;            
        }
        private int RefreshUI ()
        {
            //ToArray => extension method
            //  Allows us to call a method like an instance method  on a type that does not actually implement it
            // Adding functionality to type
            //   1. Open type and add new instance method - only works if you own the type
            //   2. Inherit from type - if base type allows inheritance and you are OK using the derived type
            //   3. Extension method - works with any type
            // Calling an extension method
            //  1. Just like an instance method
            //System.Collections.Generic.IEnumerable<Movie> movies = _movies.GetAll();
            var items = _movies.GetAll()
                                   .OrderBy(x => x.Name).ThenBy(x => x.ReleaseYear)
                                   .Select(x => x) //Transform
                                   .ToArray();   
            //var items = movies.ToArray();

            //_lstMovies.DisplayMember = nameof(Movie.Name); //nameof provides type equivalent of the member name ("Name")

            _lstMovies.DataSource = items;
            // _lstMovies.DataSource = null;
            // _lstMovies.DataSource = _movies.GetAll();
            return items.Length;
            

        }
        private void OnMovieAdd ( object sender, EventArgs e)
        {
            var form = new MovieForm();

            do
            {
                // Can show two different ways
                // ShowDialog - modal :: user must interact with child form, cannot access parent
                // Show - modeless :: multiples windows open and accessible at the same time
                var result = form.ShowDialog(this); //Blocks until form is dismissed/
                if (result == DialogResult.Cancel)
                    return;

                //Handle errors
                // try-catch ::= try-block catch-statement
                // try-block ::= try S
                // catch-block ::= catch-conditional-block* [catch-block]
                // catch-conditional-block ::= catch (T id) S

                // Save movie
                try
                {
                    //Try to do this
                    AddMovie(form.Movie);
                    //AddMovie(null);
                    return;
                } catch (InvalidOperationException ex)
                {
                    MessageBox.Show(this, ex.Message, "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } catch (ArgumentException ex)
                {
                    MessageBox.Show(this, ex.Message, "Bad Argument", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } catch (Exception ex) // Equivalent to catch 
                {
                    //Handle errors
                    MessageBox.Show(this, ex.Message, "Add Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                };
                //_movie = form.Movie;
            } while (true);
        }
        
        private void OnMovieDelete ( object sender, EventArgs e )
        {
            var movie = GetSelectedMovie();
            if (movie == null)
                return;

            // DialogResult 
            switch (MessageBox.Show(this, $"Are you sure you want to delete '{movie.Name}'?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes: break;
                case DialogResult.No: return;
            }
            
            try
            {
                DeleteMovie(movie.Id);
            } catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
        }

        private void OnMovieEdit ( object sender, EventArgs e )
        {
            var movie = GetSelectedMovie();
            if (movie == null)
                return;
          
            //Object creation
            // 1. Allocate memory for instance, zero initialized
            // 2. Initialize fields 
            // 3. Constructor (finish initialization)
            // 4. Return new instance
            var form = new MovieForm(movie, "Edit Movie");

            //form.Movie = _movie;

            var result = form.ShowDialog(this); //Blocks until form is dismissed
            if (result == DialogResult.Cancel)
                return;

            try
            {
                EditMovie(movie.Id, form.Movie);
            } catch (InvalidOperationException ex)
            {
                MessageBox.Show(this, ex.Message, "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } catch (ArgumentException ex)
            {
                MessageBox.Show(this, ex.Message, "Bad Argument", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Edit Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //Rethrow exception
                throw;
            };

        }

    }
}
