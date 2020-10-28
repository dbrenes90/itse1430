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
    //ICloneable - clone objects, but doesn't actually work
    // IValidateObject - validates objects

    /// <summary>Provides an interaface for storing and retrieving movies.</summary>
    public interface IMovieDatabase
    {
        Movie Add ( Movie movie, out string error );
        void Delete ( int id );
        Movie Get ( int id );
        IEnumerable<Movie> GetAll ();
        string Update ( int id, Movie movie );
    }
}