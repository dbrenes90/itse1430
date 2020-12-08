/* Daniel Brenes
 * Lab 4
 * 12/5/2020
 * ITSE 1430
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Nile
{
    //Static class
    // 1. Cannot be instantiated
    // 2. Cannot contain instance members
    public static class ObjectValidator
    {
        //Make static because it doesn't use any instance data
        public static IEnumerable<ValidationResult> TryValidateFullObject (IValidatableObject value)
        {
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(value, new ValidationContext(value), validationResults, true);

            return validationResults;
        }
        public static void ValidateFullObject ( IValidatableObject value )
        {            
            Validator.ValidateObject(value, new ValidationContext(value), true);           
        }
    }
}