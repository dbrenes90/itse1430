using System;
using System.Collections.Generic;
using System.Text;

namespace MovieLibrary
{
    public static class SeedMovieDatabase
    {
        //Make static because it does not reference any instance data
        //nor does it really need to be created
        //Converting to an extension method
        //  1. Must be in a static class (public or internal) [extension methods do not work outside of static class]
        //  2. Must accept as a first parameter the type to extend
        //  3. First parameter must be preceded by keyword 'this'
        //  4. (optional) Change first parameter to 'source'
        public static void Seed (this IMovieDatabase source)   //database.Seed() 
        {
                //Extension methods - DO NOT check for null
            
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
            
                //TODO: FIX error handling
                foreach (var item in items)
                    source.Add(item);


            }

        }
    }

