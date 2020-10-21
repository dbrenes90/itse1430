using System;
using System.Collections.Generic;
using System.Text;

namespace MovieLibrary
{
    class MovieDatabase
    {
        //Array - Type[]
        //public Movie[] Items { get; set; }
        public void Add ( Movie movie )
        {
            //Find first empty spot in array
            // for ( Ei; EC; EU) S ;
            //     EI::= initializer expression (runs once before loop executes)
            //     EC::= conditional expresssion => boolean (executes before loop statement is run, aborts if condition is false)
            //     EU::= update expression ( runs at end of current iteration)
            // Length -> int (# of rows in the array)
            for (var index = 0; index<_movies.Length; ++index)
            {
                // Array element access ::= V{int}
                if (_movies[index] == null)
                {
                    _movies[index] = movie;   // Movie is a ref type thus movie and _movies[index] reference the same instance
                    return;
                    // Add movie to array
                }
            };

            //TODO: MessageBox.Show(this, "No more room for movies", "Add Failed", MessageBoxButtons.OK);


        }
        public void Delete ( int id )
        {
            for (var index = 0; index<_movies.Length; ++index)
            {
                // Array element access ::= V{int}
                //if (_movies[index] != null && _movies[index].Id == id )
                if (_movies[index]?.Id == id) // null conditional ?. if instance != null, access the member otherwise skip
                {
                    _movies[index] = null;   // Movie is a ref type thus movie and _movies[index] reference the same instance
                    return;
                    // Add movie to array
                }
            };

        }
        public void Update ( int id, Movie movie )
        {
            for (var index = 0; index<_movies.Length; ++index)
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
            };

           //TODO: MessageBox.Show(this, "Cannot find movie", "Edit Movie", MessageBoxButtons.OK);
        }
        private Movie[] _movies = new Movie[100];
    }

}
