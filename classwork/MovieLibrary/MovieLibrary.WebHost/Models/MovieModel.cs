/*
 * ITSE 1430
 * Daniel Brenes
 * Class work Movie Library
 */

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieLibrary.WebHost.Models
{
    
    /// </remarks>

    public class MovieModel // : IValidatableObject
    {    
        public MovieModel ()
        { }

        public MovieModel ( Movie movie )
        {
            //Transform from business object to model
            Id = movie.Id;
            Name = movie.Name;
            Description = movie.Description;
            Rating = movie.Rating;
            RunLength = movie.RunLength;
            IsClassic = movie.IsClassic;
        }

        public Movie ToMovie ()
        {
            return new Movie() {
                Id = Id,
                Name = Name,
                Description = Description,
                Rating = Rating,
                RunLength = RunLength,
                ReleaseYear = ReleaseYear,
                IsClassic = IsClassic,
            };
        }
        //Metadata - data about data      
               
        public int Id { get; set; }

        // Properties - Methods that have field-like syntax
        // full-property ::= {access} Type identifier {getter setter}
        // getter ::= get {Statement*}
        // setter ::= set {Statement*}
        // auto-property ::= {access} T identifier {get;}
        // properties do not store data in a class, only member in a class that can store data is a field.
        // Properties returning arrays or strings should not return null

        //Attributes are metadata 
        // [][] or [,] for multiple attributes
        // [XAttribute()], [XAttribute], [X]
        // Attribute may be limited to certain types or members

        // Required - value cannot be null
        //[RequiredAttribute()]
        //[RequiredAttribute]
        [Required(AllowEmptyStrings = false)]
        [StringLength(Movie.MaximumNameLength)]
        public string Name { get; set; }
        //{
        //    get => _name ?? "";
        //    set => _name = value;
        //}
       // public string Name
        //{
            //getter T get_Name()
            
            //get 
           // {
        //Coalesce - scanning a series of expressions looking for non-NULL
                // Expression ?? Expression (boolean operator takes two expressions)
                // if E1 is not null then return E1
                // else return E2
                //return _name;
                // if (_name == null)
                // return "";
                // else return _name;

             //   return _name ?? "";
          //  }

            //setter only allowed for properties, 2 statements.
            // void set_Name ( T value )
           // set 
           // {
           //     _name = value;
           // }
       // }
        //private string _name = "";

        [StringLength(Movie.MaximumNameLength)]
        public string Description { get; set; }
        //{
        //    get => _description ?? "";
        //    set => _description = value;
        //}
        //private string _description = "";

        
        public string Rating { get; set; }
        //{ 
        //    get { return _rating ?? ""; }
        //    set { _rating = value; }
        //}
        //private string _rating;
        
        
        //Range enforces a min, max value
        [Range(0, Int32.MaxValue, ErrorMessage = "Run length must be greater than or equal to 0.")]
        public int RunLength { get; set; } //auto property, used for ints not for strings
        /*{
            get {return _runLength; }
            set { _runLength = value; }
        }*/

        
        
        
        [Range(1900, 2100)]
        public int ReleaseYear { get; set; } 
        /*{
            get { return _releaseYear; }
            set { _releaseYear = value; }
        }*/
        

        public bool IsClassic { get; set; }
        /*{
            get { return _isClassic;}
            set { _isClassic = value;}
        }*/

        // Functionality - functions you want to expose                     
        
        /*
        {
            //this is reference to current instance, rarely needed
            //var name = this.Name; allowed inside of methods, refers to the instance 

            //Only 2 cases where 'this' is needed
            // 1. scoping issue -> fix the issue
            //          fields are _id
            //          locals are id
            //      ex: var Name = "";
            //          Name = Name; //WRONG
            //          this.Name = Name; // Correct
            // 2. passing the entire object to another method/function

            //Name is required
            if (String.IsNullOrEmpty(Name))
                return "Name is required";

            //Run length must be >= 0
            if (RunLength < 0)
                return "Run Length must be greater than or equal to 0";

            //Release Year must be >= 1900
            if (ReleaseYear < 1900)
                return "Release Year must be at least 1900";

            return null;
        }
        */
        //public override string ToString () => Name;
        //{
         //   return Name;
        //}

        //public IEnumerable<ValidationResult> Validate ( ValidationContext validationContext )
        //{
        //    //When you are using the iterator syntax then all the return statements must be yield return
            //    //Name is required
        //    //if (String.IsNullOrEmpty(Name))
        //    //    yield return new ValidationResult("Name is required", new[] { nameof(Name) });
        //    //Yield returning new validation result with message and string array (collection init syntax) containing a single string with name of Name

        //    //Run length must be >= 0
        //    //if (RunLength < 0)
        //    //    yield return new ValidationResult("Run Length must be greater than or equal to 0", new[] { nameof(RunLength) });

        //    //Release Year must be >= 1900
        //    //if (ReleaseYear < 1900)
        //    //    yield return new ValidationResult("Release Year must be at least 1900", new[] { nameof(RunLength) });
        //    return null;
           
        //}
    }
    // Accessibility - the visibility of an identifier to other code, compile time only, determines who can see what at compilation
    // public - everyone has access (least control) 
    // private - only the owning type (default for members)

    //Type 
    // Pascal cased, do not use camel case
    // Noun
    // Singular (generally) unless they represent a collection of things
    // {access} class identifier {}   class declaration

    // doctags (document tags) every class should have these

    // Static vs instance members
    // Instance members are tied to the instance they are called on
    //      Fields - data in the instance (instance._id, instance._name)
    //      Methods - requires an instance to execute (instance.method()) (instance.ToString)
    //   Static members are global to all instances (Type.Member)
    //      Fields - equivalent to global variable 
    //      Method - equivalent to a global function (static method does not have instance access), no this parameter (Int32.TryParse)
    /// <summary>Represents a movie.</summary>
    /// <remarks>
    /// A paragraph of information.
    /// Another set of information.
    /// Certain rules that we need to follow should be documented
    /// 
    // Data -  data to store

    //Fields - where the data is stored
    // Should always be private
    // Named using camel case and start with underscore
    //string name   default is private string name;
    //Fields work identical to variables 
    //Named as nouns, no abbreviations and no generic names

    //Only time public fields allowed is for read only data. Show data to user but they cannot change it
    // Constants
    // {access optional} const T idneitifier = E;
    // 1. must be a primitive type
    // 2. must have an intiliaizer expression
    // 3. must recompile all code if value changed
}
