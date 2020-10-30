/*
 * ITSE 1430
 * Daniel Brenes
 * Class work Movie Library
 */

//StringBuilder, Regular expressions, Encoding will use System.Text;
//using System.Text;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieLibrary
{
    //Type 
    // Pascal cased, do not use camel case
    // Noun
    // Singular (generally) unless they represent a collection of things
    // {access} class identifier {}   class declaration

    // doctags (document tags) every class should have these

    /// <summary>Represents a movie.</summary>
    /// <remarks>
    /// A paragraph of information.
    /// Another set of information.
    /// Certain rules that we need to follow should be documented
    /// </remarks>

    public class Movie : IValidatableObject
    {

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
        public const int MaximumNameLength = 50;

        // Read Only (instead of constants)
        // {access} readonly Type identifier;
        // 1. Any type
        // 2. Must be initialized once either in initializer expression or at instance creation
        // 3. Allowed to have different "readonly" values for each instance.
        // 4. Is not baked into source code
        public readonly int MaximumDescriptionLength = 200;



        //private int _runLength; // = 0;
        //private bool _isClassic; // = false;
        //private int _releaseYear = 1900;

        // Commented out because of the auto properties methods

        //Not a field. becase:
        // 1. User can not write
        // 2. Calculated
        //public int Age;

        //Not a method, because:
        // 1. Not functionality
        // 2. Complex Syntax compared to fields
        // 3. Get/Set is in name (type) method shouldn't have Get or Set
        // public int GetAge () {}

        public int Age
        {
            // Calculated property
            // Read only property because // set is commented out
            get { return DateTime.Now.Year - ReleaseYear; }
            //set { }
        }

        // Mixed accessibility - using a different access on either getter or setter
        // 1. Only 1 method can have access modifier    
        // 2. Always more restrictive 
        public int Id { get; set; }

        // Properties - Methods that have field-like syntax
        // full-property ::= {access} Type identifier {getter setter}
        // getter ::= get {Statement*}
        // setter ::= set {Statement*}
        // auto-property ::= {access} T identifier {get;}
        // properties do not store data in a class, only member in a class that can store data is a field.
        // Properties returning arrays or strings should not return null
        public string Name
        {
            //getter T get_Name()
            
            get 
            {
                //Coalesce - scanning a series of expressions looking for non-NULL
                // Expression ?? Expression (boolean operator takes two expressions)
                // if E1 is not null then return E1
                // else return E2
                //return _name;
                // if (_name == null)
                // return "";
                // else return _name;

                return _name ?? "";
            }

            //setter only allowed for properties, 2 statements.
            // void set_Name ( T value )
            set 
            {
                _name = value;
            }
        }
        private string _name = "";

        /// <summary>Gets or sets the movie description.</summary>
        public string Description
        {
            get { return _description ?? ""; }
            set { _description = value; }
        }
        private string _description = "";

        /// <summary>Gets or sets the rating. </summary>
        public string Rating
        { 
            get { return _rating ?? ""; }
            set { _rating = value; }
        }
        private string _rating;
        /// <summary>Gets or sets the run length in minutes.</summary>
        public int RunLength { get; set; } //auto property, used for ints not for strings
        /*{
            get {return _runLength; }
            set { _runLength = value; }
        }*/

        /// <summary>Gets or sets the release year.</summary>
        /// <value>Default value is 1900.</value>
        public int ReleaseYear { get; set; } = 1900;
        /*{
            get { return _releaseYear; }
            set { _releaseYear = value; }
        }*/
        //private int _releaseYear = 1900;

        public bool IsClassic { get; set; }
        /*{
            get { return _isClassic;}
            set { _isClassic = value;}
        }*/

    


        // Functionality - functions you want to expose

        /// <summary>Validates the movie instance.</summary>
        /// <returns>The error message, if any.</returns>
        //public string Validate (/*Movie this*/ )
        //public string Validate (/*Movie this*/)
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
        public override string ToString ()
        {
            return Name;
        }

        public IEnumerable<ValidationResult> Validate ( ValidationContext validationContext )
        {
            //When you are using the iterator syntax then all the return statements must be yield return

            //Name is required
            if (String.IsNullOrEmpty(Name))
                yield return new ValidationResult("Name is required", new[] { nameof(Name) });
                        //Yield returning new validation result with message and string array (collection init syntax) containing a single string with name of Name

            //Run length must be >= 0
            if (RunLength < 0)
                yield return new ValidationResult("Run Length must be greater than or equal to 0", new[] { nameof(RunLength) });

            //Release Year must be >= 1900
            if (ReleaseYear < 1900)
                yield return new ValidationResult("Release Year must be at least 1900", new[] { nameof(RunLength) });

           
        }
    }
    // Accessibility - the visibility of an identifier to other code, compile time only, determines who can see what at compilation
    // public - everyone has access (least control) 
    // private - only the owning type (default for members)
}
