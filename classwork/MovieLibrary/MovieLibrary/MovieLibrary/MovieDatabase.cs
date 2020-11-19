﻿using System;
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
        //Array - Type[]
        //public Movie[] Items { get; set; }
        public Movie Add ( Movie movie )
        {
            // Exception type is the base type of all exceptions 
            // Arguments should always fail with Argument exceptions
            // Exception -> generic expression with a message
            //      ArgumentException -> generic argument exception
            //      ArgumentNullException -> argument is null and it shouldn't be
            //      ArgumentOutOfRangeException -> argument is outside excepted range (generally numeric)
            //       ValidationException -> IValidatableObject fails
            //      InvalidOperationException -> The operation is not currently valid but may be in the future
            //       SystemException -> Only generated by runtime
            //           NullReferenceException -> null is on left side of member access (null.???)
            //           StackOverflowException -> Stack overflowed
            //           OutOfMemoryException -> Out of memory 

            // Throw an exception using throw expression
            //      throw-expression ::= throw E
            //                           E must be exception
            // Movie is not null
            if (movie == null)
                throw new ArgumentNullException(nameof(movie)); //Argument is null and it shouldn't be, pretty much all reference types
            
            ObjectValidator.ValidateFullObject(movie);
            //if (results.Count() > 0)
            //{
             //   foreach (var result in results)
              //  {
                //    error = result.ErrorMessage;
                 //   return null;
                //};
            //};
            //TODO: Movie is valid

            // Movie name is unique
            var existing = GetByName(movie.Name);
            if (existing != null)
                throw new InvalidOperationException("Movie must be unique");

            // Throw expression ::= E ?? throw E
            //var existing = GetByName(movie.Name) ?? throw new InvalidOperationException("Movie must be unique");     

            //error = "";//commented out after ivalidatable     
            //Clone so argument can be modified without impacting our array
            //var item = CloneMovie(movie);

            //set a unique ID
            //item.Id = _id++;

            //add movie to array
            //_movies.Add(item);  // Movie is a ref type thus movie and _movies[index] reference the same instance

            //Set ID on original object and return
            //movie.Id = item.Id;

            //TODO: Generalize errors
            try
            {
                return AddCore(movie);
            } catch (Exception e)
            {
                //Throwing a new exception 
                throw new InvalidOperationException("Add Failed", e);
            };

            //TODO: No more room
            // error = "No more room";
            //return null;
        }

        protected abstract Movie AddCore ( Movie movie );

        protected abstract void DeleteCore ( int id );
        

        protected virtual Movie GetByName ( string name )
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
            // Validate Id > 0
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than zero");

            try
            {
               DeleteCore(id);
            } catch (Exception e)
            {
                //Throwing a new exception 
                throw new InvalidOperationException("Add Failed", e);
            }; 

            //var movie = GetById(id);
            //if (movie!= null)
            //{
                //mus tus the same instance that is stored in the list so ref equality works
              //  _movies.Remove(movie);
            //};
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
            //object value = null;
            //value.ToString();

            try
            {
                return GetAllCore();
            } catch (Exception e)
            {
                //Throwing a new exception 
                throw new InvalidOperationException("GetAll Failed", e);
            }; 

            //iterator IEnumerable<T>
            // yield return T
         //   foreach (var movie in _movies) // relies on IEnumerator<T>
                                           // items[index++] = CloneMovie(movie);
               // yield return CloneMovie(movie);
             //   ;
            //return items;
        }
        protected abstract IEnumerable<Movie> GetAllCore ();

        public Movie Get ( int id )
        {
            //TODO: id >= 0
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than zero");

            
            try
            {
                return GetByIdCore(id);
            } catch (Exception e)
            {
                //Throwing a new exception 
                throw new InvalidOperationException("Get Failed", e);
            };
            //var movie = GetById(id);

            //Clone movie if we found it
            //return (movie!=null) ? CloneMovie(movie) : null;
        }
        protected abstract Movie GetByIdCore ( int id );
        

        public void Update ( int id, Movie movie )
        {
            //TODO: Validate Id
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than zero");
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            // Movie exists //TODO: Movie is valid
             ObjectValidator.ValidateFullObject(movie);
           
           

            // Movie name is unique
            var existing = GetByName(movie.Name);
            if (existing != null && existing.Id != id)
                throw new InvalidOperationException("Movie must be unique");           
                       
            try
            {
                UpdateCore(id, movie);
            } catch (Exception e)
            {
                //Throwing a new exception 
                throw new InvalidOperationException("Update Failed", e);
            };

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
        }
        protected abstract void UpdateCore ( int id, Movie movie );

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
