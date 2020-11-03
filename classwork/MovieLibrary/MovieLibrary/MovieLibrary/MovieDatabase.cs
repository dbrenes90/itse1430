using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//Abstract class required if any member is abstract
// 1. Cannot be instantiated
// 2. Must derive from it
// 3. Must implement all abstract members

namespace MovieLibrary
{
    public abstract class MovieDatabase : IMovieDatabase
    {
        //Default constructor to seed database
        protected MovieDatabase ()
        {
            //Not needed here- clears all items from list
            // _movies.Clear();

            //Seed database
            // Object initializer (syntax) - only usable on new operator
            // Limitations
            //     1. Can only set properties with setters
            //     2.  Can set properties that are themselves new'ed up but cannot set child properties
            //        Position = new Position () { Name = "Boss" }; allowed
            //            Position.Title = "Boss"; not allowed
            //     3. Properties cannot rely on other properties
            //         Description = "blah",
            //         FullDescription = Description

            //Collection initializer syntax. compiler can infer the type based on the types in the initializer (only arrays)
            var items = new[] { //new Movie[] {
                new Movie() {
                    Name = "Jaws",
                    ReleaseYear = 1977,
                    RunLength = 190,
                    Description = "Shark movie",
                    IsClassic = true,
                    Rating = "PG",  // Can have a comma at end
                },
                new Movie() {
                    Name = "Jaws 2",
                    ReleaseYear = 1979,
                    RunLength = 195,
                    Description = "Shark movie",
                    IsClassic = true,
                    Rating = "PG-13",
                },
                new Movie() {
                    Name = "Dune",
                    ReleaseYear = 1985,
                    RunLength = 220,
                    Description = "Based on book",
                    IsClassic = true,
                    Rating = "PG",
                }
            };
            foreach (var item in items)
                Add(item, out var error);


        }
        //Not on interface    
        //Array - Type[]
        //public Movie[] Items { get; set; }
        public Movie Add ( Movie movie, out string error )
        {
            //Added this after adding interfaces, IValidatableObject
            var results = new ObjectValidator().TryValidateFullObject(movie);
            if (results.Count() > 0)
            {
                foreach (var result in results)
                {
                    error = result.ErrorMessage;
                    return null;
                }
            }
            //TODO: Movie is valid

            // Movie name is unique
            var existing = FindByName(movie.Name);
            if (existing != null)
            {
                error = "Movie must be unique";
                return null;
            }
            //error = "";//commented out after ivalidatable     
            //Clone so argument can be modified without impacting our array
            //var item = CloneMovie(movie);

            //set a unique ID
            //item.Id = _id++;

            //add movie to array
            //_movies.Add(item);  // Movie is a ref type thus movie and _movies[index] reference the same instance

            //Set ID on original object and return
            //movie.Id = item.Id;
            error = null;
            return AddCore(movie);

            //TODO: No more room
            // error = "No more room";
            //return null;
        }

        protected abstract Movie AddCore ( Movie movie );

        protected abstract void DeleteCore ( int id );
        

        protected virtual Movie FindByName ( string name )
        {
            foreach ( var movie in GetAll())
            {
                if (String.Compare(movie.Name, name, true) == 0)
                    return movie;
             };

            return null;
        }

        public void Delete ( int id )
        {

            var movie = GetById(id);
            if (movie!= null)
            {
                //mus tus the same instance that is stored in the list so ref equality works
                _movies.Remove(movie);
            };
            /* foreach (var movie in _movies)
             {
                 if (movie.Id==id)
                 {
                     //Must use the same instance that is stored in the list so ref equality works
                     _movies.Remove(movie);
                     return;
                 };
             };*/
            //TODO: Validate Id
            //for (var index = 0; index<_movies.Count; ++index)
            // {
            //_movies.Remove();
            // Array element access ::= V{int}
            //if (_movies[index] != null && _movies[index].Id == id )
            // if (_movies[index]?.Id == id) // null conditional ?. if instance != null, access the member otherwise skip
            //  {
            //      _movies[index] = null;   // Movie is a ref type thus movie and _movies[index] reference the same instance
            //     return;

            //   };
            // };

        }
        //Use IEnumerable<T> for readonly lists of items
        // public Movie[] GetAll()
        public IEnumerable<Movie> GetAll ()
        {
            //DONT DO THIS
            //  1. Expose underlying movie items
            //  2. Callers add/remove movies
            //return _movies;

            //TODO: Determine how many movies we're storing
            //For each one create a cloned copy
            // return _movies;
            //var items = new Movie[_movies.Count];
            //var index = 0;

            //Foreach equivalent
            // var enumerator = _movies.GetEnumerator();
            // while (enumerator.Next())
            // {S* }

            //iterator IEnumerable<T>
            // yield return T
            foreach (var movie in _movies) // relies on IEnumerator<T>
                                           // items[index++] = CloneMovie(movie);
                yield return CloneMovie(movie);
                ;
            //return items;
        }

        public Movie Get ( int id )
        {
            var movie = GetById(id);

            //Clone movie if we found it
            return (movie!=null) ? CloneMovie(movie) : null;
        }

        private Movie GetById ( int id )
        {
            // foreach ( var id in array) Statement
            //for (var index = 0; index<_movies.Length; ++index)
            foreach (var movie in _movies)
            {
                //movie == _movies[index]
                //Restrictions:
                //    1. movie is readonly             //movie = new Movie();
                //    2. _movies cannot change, immutable
                if (movie?.Id == id)   // null conditional ?. if instance != null access the member           
                    return movie;
            };

            return null;
        }

        public string Update ( int id, Movie movie )
        {
            //TODO: Validate Id
            // Movie exists

            var existing = GetById(id);
            if (existing == null)
                return "Movie not found";

            // updated movie is valid
            // updated movie name is unique

            CopyMovie(existing, movie);

            /* for (var index = 0; index<_movies.Length; ++index)
             {
                 // Array element access ::= V{int}
                 //if (_movies[index] != null && _movies[index].Id == id )
                 if (_movies[index]?.Id == id) // null conditional ?. if instance != null, access the member otherwise skip
                 {

                     //Just because we are doing this in memory (reference type)
                     movie.Id = id;
                     _movies[index] = movie;   // Movie is a ref type thus movie and _movies[index] reference the same instance
                     return "";
                     // Add movie to array
                 }
             };*/

            return "";

        }
      //  private void CopyMovie ( Movie target, Movie source )
       // {
            //var item = new Movie();
            //item.Id = movie.Id;
       //     target.Name = source.Name;
         //   target.Rating = source.Rating;
        //    target.ReleaseYear = source.ReleaseYear;
        //    target.RunLength = source.RunLength;
        //    target.IsClassic = source.IsClassic;
        //    target.Description = source.Description;
       // }
        //private Movie CloneMovie ( Movie movie )
       // {
       //     var item = new Movie();
        //    item.Id = movie.Id;
        //    CopyMovie(item, movie);




         //   return item;
//
      //  }

        //Only store cloned copies of movies here!!
        //private Movie[] _movies = new Movie[100];
        //private List<Movie> _movies = new List<Movie>(); // Generic list of Movies (dynamically resizable array (storing set of items, number of items not known))
        //private Collection<Movie> _temp;       // Public read-writeable lists    must add using System.Collections.ObjectModel;
        //private int _id = 1;

        //Non-generic 
        //   ArrayList - list of objects
        //Generic Types
        //   List <T> where T is any type 
    }

}
