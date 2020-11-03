using System;
using System.Collections.Generic;

namespace MovieLibrary
{
    // Interface
    //    interface-declaration::= {access} interface { identifier-member*}
    //    interface-member ::= property  | method  |  event
    //              1.  No access modifiers  (always public)
    //              2.  No implementation of anything
    //      Cannot instantiate an interface

    //Common interfaces
    // IEnumerable<T>, IEnumerator<T>
    // IList<T>, IReadOnlyList<T>
    // IComparer<T> - relational comparison, StringComparer
    // ICloneable - clone objects, but doesn't actually work
    // IValidatableObject - validates objects

    // Abstract Class: Class - Interface - Abstract. 

    /// <summary>Provides an interaface for storing and retrieving movies.</summary>
    public interface IMovieDatabase
    {
        /// <summary>
        /// Adds a movie to the database.summary>
        /// <param name="movie">The movie to add.</param>
        /// <param name="error">The error message, if any.</param>
        /// <returns>The new movie.</returns>
        /// error: Movie is invalid
        /// error: Movie already exists
        Movie Add ( Movie movie, out string error );
        /// <summary>
        /// Deletes a movie from the database.</summary>
        /// <param name="id">The movie to delete.</param>
        /// error: Id is less than zero.
        void Delete ( int id );
        Movie Get ( int id );
        IEnumerable<Movie> GetAll ();
        string Update ( int id, Movie movie );
    }
}