using System;
using System.Collections.Generic;
using System.Text;

namespace MovieLibrary.Sql
{
    public class SqlMovieDatabase : MovieDatabase
    {
        
        protected override Movie AddCore ( Movie movie )
        {            
            var item = CloneMovie(movie);

            //set a unique ID
            item.Id = _id++;

            //add movie to array
            _movies.Add(item);  // Movie is a ref type thus movie and _movies[index] reference the same instance

            //Set ID on original object and return
            movie.Id = item.Id;

            return movie;
        }
        //public void Delete ( int id )
        protected override void DeleteCore ( int id )
        {     
            var movie = FindById(id);
            if (movie != null)
            {                
                _movies.Remove(movie);
            };

        }
        //Use IEnumerable<T> for readonly lists of items        
        protected override IEnumerable<Movie> GetAllCore ()
        {         
            foreach (var movie in _movies) 
                yield return CloneMovie(movie);
            ;           
        }
        
        protected override Movie GetByIdCore ( int id)
        {
            var movie = FindById(id);
            return (movie != null) ? CloneMovie(movie) : null;
        }      

        private Movie FindById ( int id )
        {            
            foreach (var movie in _movies)
            {                
                if (movie?.Id == id)           
                    return movie;
            };

            return null;
        }
               
        protected override void UpdateCore (int id, Movie movie)
        {
            var existing = FindById(id);
            CopyMovie(existing, movie);                  
        }
        protected override Movie GetByName ( string name )
        {
            foreach (var movie in _movies)
            {
                if (String.Compare(movie.Name, name, true) == 0)
                    return CloneMovie(movie);
            };

            return null;
        }
        private void CopyMovie ( Movie target, Movie source )
        {
            //var item = new Movie();
            //item.Id = movie.Id;
            target.Name = source.Name;
            target.Rating = source.Rating;
            target.ReleaseYear = source.ReleaseYear;
            target.RunLength = source.RunLength;
            target.IsClassic = source.IsClassic;
            target.Description = source.Description;
        }
        private Movie CloneMovie ( Movie movie )
        {
            var item = new Movie();
            item.Id = movie.Id;
            CopyMovie(item, movie);
            return item;
        }

        //Only store cloned copies of movies here!!
        //private Movie[] _movies = new Movie[100];
        private List<Movie> _movies = new List<Movie>();    //Generic list of movies, use for fields
        private int _id = 1;
    }
}
